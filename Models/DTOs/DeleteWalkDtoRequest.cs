namespace REST.APIs.Models.DTOs
{
    public class DeleteWalkDtoRequest
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; }

        public Guid DifficuiltyId { get; set; }

        public Guid RegionId { get; set; }
    }
}
