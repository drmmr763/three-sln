using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppShared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppShared.Repositories
{
    public class CandidateRepository : BaseRepository<Candidate>
    {
        public CandidateRepository(EntityContext context) : base(context) {}

        public async Task<IEnumerable<Candidate>> ListAsync()
        {
            return await _context.Candidates.AsNoTracking().ToListAsync();
        }
    }
}