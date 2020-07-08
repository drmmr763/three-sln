using System.Threading.Tasks;
using AppShared.Repositories;
using CliFx;
using CliFx.Attributes;

namespace AppCli.Commands.Candidate
{
    [Command("candidate list", Description = "List candidates")]
    public class ListCandidates : ICommand
    {
        private readonly CandidateRepository _candidates;
        
        public ListCandidates(CandidateRepository candidateRepository)
        {
            _candidates = candidateRepository;
        }
        
        public async ValueTask ExecuteAsync(IConsole console)
        {
            var candidates = await _candidates.ListAsync();
            
            await console.Output.WriteLineAsync("Listing out the candidates");
            int count = 0;
            
            foreach (var candidate in candidates)
            {
                count++;
                await console.Output.WriteLineAsync($"Candidate #{count}: {candidate.FirstName} {candidate.LastName}");
            }
            
            await console.Output.WriteLineAsync("Completed");
        }
    }
}