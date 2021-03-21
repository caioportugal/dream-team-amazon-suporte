using Amazon.Suporte.Enum;
using System;

namespace Amazon.Suporte.Model
{
    public class Problem
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
