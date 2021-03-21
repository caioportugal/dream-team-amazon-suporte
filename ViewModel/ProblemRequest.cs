using System.ComponentModel.DataAnnotations;

namespace Amazon.Suporte.ViewModel
{
    public class ProblemRequest
    {
        [Required]
        [MaxLength(50,ErrorMessage ="Title must a maximum length of 50 characters")]
        public string Title { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Description must a maximum length of 250 characters")]
        public string Description { get; set; }
    }
}
