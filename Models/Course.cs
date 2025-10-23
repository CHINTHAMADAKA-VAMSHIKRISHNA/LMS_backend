using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
