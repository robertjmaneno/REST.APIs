using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST.APIs.Data;
using REST.APIs.Models.Domain;
using REST.APIs.Models.DTOs;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace REST.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public RegionsController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        // Get all regions
        [HttpGet]
        public IActionResult GetAll()
        {



            //getting regions from domain model
            var regionsFromDomain = _applicationDbContext.Region.ToList();
            //creting empty lost of region dto
            var regionsDtos = new List<RegionDto>();
            foreach (var region in regionsFromDomain)
            {

                var regionDto = new RegionDto
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    RegionImageUrl = region.RegionImageUrl,
                };

                regionsDtos.Add(regionDto);
            }
                
          return Ok(regionsDtos);

        }

        // Get single region
        [HttpGet("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)


        {

            //Getting region from domain model
            var regionDomain = _applicationDbContext.Region.FirstOrDefault(u => u.Id == id);

            if (regionDomain == null)
            {
                return NotFound(id);
            }

            //mapping domain model to dto

            var regionDto = new RegionDto {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl,

            };

            return Ok(regionDto);
        }


        [HttpPost]
        public IActionResult Create(AddRegionRequestDto addRegionRequestDto)
        {
            var regionDomain = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl,
            };
             
            _applicationDbContext.Region.Add(regionDomain);
            _applicationDbContext.SaveChanges();

            var regionDto = new AddRegionRequestDto
            {
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl,
            };

            return CreatedAtAction(nameof(GetById), new {Id = regionDomain.Id}, regionDto);

        }
    }

}
