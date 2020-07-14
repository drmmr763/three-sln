using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppApi.Requests.Candidate;
using Microsoft.AspNetCore.Mvc;
using AppShared.Entities;
using AppShared.Repositories;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AppApi.Controllers
{
    // routes:
    // - GET /candidates
    // - POST /candidate
    // - GET /candidate/{candidateId}
    
    [ApiController]
    [Route("[controller]")]
    public class CandidatesController : ControllerBase
    {
        private CandidateRepository _candidateRepository;

        private EntityContext _context;
        
        public CandidatesController(EntityContext entityContext, CandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
            _context = entityContext;
        }
        
        [HttpGet]
        public async Task<IEnumerable<Candidate>> Index()
        {
            var candidates = await _candidateRepository.ListAsync();
            return candidates.ToList();
        }
        
        [HttpPost]
        public async Task<IActionResult> Store([FromBody] CandidateSaveRequest request)
        {
            var Candidate = new Candidate
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DisciplineId = request.DisciplineId,
                PhoneNumber = request.PhoneNumber
            };
        
            // use context to attach to ef
            await _context.AddAsync(Candidate);
        
            // persist
            await _context.SaveChangesAsync();
        
            // load the discipline object
            await _context.Entry(Candidate).Reference(c => c.Discipline).LoadAsync();
        
            return CreatedAtRoute(nameof(Show), new { candidateId = Candidate.CandidateId },Candidate);
        }
        
        // Show a specific candidate by id
        // note: uses route binding to pass candidateId to the method -- these names must match
        [HttpGet("{candidateId}", Name = "Show")]
        public async Task<ActionResult<Candidate>> Show(int candidateId)
        {
            if (!ModelState.IsValid) return BadRequest("Couldn't load the candidate");
            
            var candidate = await _context.Candidates.FindAsync(candidateId);
            await _context.Entry(candidate).Reference(c => c.Discipline).LoadAsync();
            
            return Ok(candidate);
        }
    }
}