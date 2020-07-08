using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AppShared.Entities;
using AppShared.Repositories;
using CliFx;
using CliFx.Attributes;

namespace AppCli.Commands.Candidate
{
    [Command("candidate create", Description = "Create a candidate entity")]
    public class CreateCandidate : ICommand
    {
        private readonly CandidateRepository _repository;
        private readonly EntityContext _context;
        
        [CommandParameter(0, Description = "The candidate's first name")]
        public string FirstName { get; set; }
        
        [CommandParameter(1, Description = "The candidate's last name")]
        public string LastName { get; set; }
        
        [CommandParameter(2, Description = "The candidate's phone number")]
        public string PhoneNumber { get; set; }
        
        [CommandParameter(3, Description = "The discipline Id")]
        public int Discipline { get; set; }

        public CreateCandidate(EntityContext context, CandidateRepository candidateRepository)
        {
            _repository = candidateRepository;
            _context = context;
        }

        public ValueTask ExecuteAsync(IConsole console)
        {
            var candidate = new AppShared.Entities.Candidate
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                PhoneNumber = this.PhoneNumber,
                DisciplineId = this.Discipline
            };

            try
            {
                _context.Candidates.Add(candidate);
                _context.SaveChanges();

                console.Output.WriteLine("Successfully added candidate.");
                console.Output.WriteLine("CandidateID:" + candidate.CandidateId);
            }
            catch (Exception e)
            {
                console.Output.WriteLine("Failed to insert" + e.Message);
            }
            
            return default;
        }
    }
}