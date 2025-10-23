using System.ComponentModel.DataAnnotations;

namespace LMS.DTO
{
    public class CourseResponse
    {
        [Required]
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
