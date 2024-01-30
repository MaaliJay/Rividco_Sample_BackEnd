using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Sample_BackEnd.Models.Domain
{
    public class TaskList
    {
        [Key]
        public string TaskId { get; set; }

        public string CompanyId { get; set; }
        public string Category { get; set; }
        public string RequestedBy { get; set; }
        public string AddedBy { get; set; }
        public string AddedDate { get; set; } = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
        public string? AssignTo { get; set; }
        public string UrgencyLevel { get; set; }
        public string Status { get; set; }
        public string? ProjectIdentificationNumber { get; set; }
        public string? CallBackNumber { get; set; }
        public string? ChatLink { get; set;}
        public string? Description { get; set; }
        public string? Comment { get; set; }
    }
}
