using System;
namespace AppShared.Entities
{
    public class CandidateJobMatch
    {
        public int CandidateJobMatchId { get; set; }
        public int CandidateId { get; set; }
        public int JobId { get; set; }
        public Candidate Candidate { get; set; }
        public Job Job { get; set; }
    }
}
