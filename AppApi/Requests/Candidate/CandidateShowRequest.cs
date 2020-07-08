using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AppApi.Requests.Candidate
{
    public class CandidateShowRequest
    {
        [BindRequired]
        public int CandidateId { get; set; }
    }
}