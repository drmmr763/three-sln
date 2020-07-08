using System;
namespace AppShared.Entities
{
    public class Job
    {
        public int JobId { get; set; }
        public int DisciplineId { get; set; }
        public Discipline Discipline { get; set; }
    }
}
