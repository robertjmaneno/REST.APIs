using REST.APIs.Models.Domain;

namespace REST.APIs.Repositories
{
    public interface IImageRepository
    {
        Task<Image> UploadImage(Image image);
    }
}
