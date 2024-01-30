﻿namespace Sample_BackEnd.Models.DTO
{
    public class UpdateTaskRequestDTO
    {
        public string Category { get; set; }
        public string RequestedBy { get; set; }
        public string AddedBy { get; set; }
        public string? AssignTo { get; set; }
        public string UrgencyLevel { get; set; }
        public string Status { get; set; }
        public string? ProjectIdentificationNumber { get; set; }
        public string? CallBackNumber { get; set; }
        public string? ChatLink { get; set; }
        public string? Description { get; set; }
        public string? Comment { get; set; }
    }
}
