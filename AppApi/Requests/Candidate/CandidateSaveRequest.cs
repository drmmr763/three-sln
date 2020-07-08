using System.ComponentModel.DataAnnotations;

namespace AppApi.Requests.Candidate
{
    public class CandidateSaveRequest
    {
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string PhoneNumber { get; set; }
        
        [Required]
        public int DisciplineId { get; set; }
    }
}