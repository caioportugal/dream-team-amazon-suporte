using System;
using AmazonSuporte.Enum;

namespace AmazonSuporte.ViewModel
{
    public class ProblemResponse
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public StatusEnum Status {get;set;}
        public DateTime CreatedAt { get; set; }
    }
}