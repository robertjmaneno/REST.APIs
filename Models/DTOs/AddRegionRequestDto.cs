using System.ComponentModel.DataAnnotations;

namespace REST.APIs.Models.DTOs
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage ="Code has to be a minimum of 3")]
        [MaxLength(5, ErrorMessage ="Code has to be a maximum of 5")]
        public string Code { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage ="The name should not be more than 10 characters")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
