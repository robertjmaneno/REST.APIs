namespace REST.APIs.Models.DTOs
{
    public class WalksDto
    {

        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public required RegionDto RegionDto { get; set; }
        public required DifficuiltyDto DifficuiltyDto { get; set;}
    }
}
