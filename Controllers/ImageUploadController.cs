using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST.APIs.Models.Domain;
using REST.APIs.Models.DTOs;
using REST.APIs.Repositories;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace REST.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImageUploadController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [HttpPost]
        [Route("Upload")]
        [DisableCors]
        public async Task<IActionResult> UploadImage([FromForm] UploadImageRequestDto uploadImageRequestDto)
        {
            ValidateImage(uploadImageRequestDto);

            if (ModelState.IsValid)
            {
                // Converting DTO to model
                var ImageDomainModel = new Image
                {
                    File = uploadImageRequestDto.File,
                    FileExtension = Path.GetExtension(uploadImageRequestDto.File.FileName).Trim(),
                    FieSizeInBytes = uploadImageRequestDto.File.Length,
                    FileName = uploadImageRequestDto.File.FileName,
                    FileDescription = uploadImageRequestDto.FileDescription,
                };

                // Using repository uploading the image
                var imageModel = await imageRepository.UploadImage(ImageDomainModel);
                return Ok(imageModel);
            }

            return BadRequest();
        }

        // Validating the image upload
        private void ValidateImage(UploadImageRequestDto uploadImageRequestDto)
        {
            var allowedExtension = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtension.Contains(Path.GetExtension(uploadImageRequestDto.File.FileName).ToLower()))
            {
                ModelState.AddModelError("file", "Unsupported file format");
            }

            if (uploadImageRequestDto.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "The image size is too big");
            }
        }
    }
}
