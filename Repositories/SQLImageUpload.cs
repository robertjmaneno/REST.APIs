using REST.APIs.Data;
using REST.APIs.Models.Domain;

namespace REST.APIs.Repositories
{
    public class SQLImageUpload : IImageRepository
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ApplicationDbContext applicationDbContext;

        public SQLImageUpload(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, ApplicationDbContext applicationDbContext)
        {
            _webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<Image> UploadImage(Image image)
        {
            var localPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images",
                $"{image.FileName} {image.FileExtension}");


            //Uplaod image to local file

            using var stream = new FileStream(localPath, FileMode.Create);
            await image.File.CopyToAsync(stream);


            var imageurl = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}/{image.FileExtension}";
            var imagePath = imageurl;

            //add imagepath to the db
            await applicationDbContext.AddAsync(image);
            await applicationDbContext.SaveChangesAsync();    

            return image;



        }
    }
}
