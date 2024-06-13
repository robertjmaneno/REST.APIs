using System.ComponentModel.DataAnnotations;

namespace REST.APIs.Models.DTOs
{
    public class UploadImageRequestDto
    {
        [Required]
        public IFormFile File { get; set; }

        [Required]
        public string FileName { get; set; }

        public string? FileDescription { get; set; }

    }
}
