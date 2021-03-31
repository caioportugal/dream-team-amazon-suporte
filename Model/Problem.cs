using Amazon.Suporte.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace Amazon.Suporte.Model
{
    public class Problem
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        [Required]
        public StatusEnum Status { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public string ProblemIdentificator { get; set; }
        public void CreateIdentificator() => ProblemIdentificator = Guid.NewGuid().ToString("N");
    }
}