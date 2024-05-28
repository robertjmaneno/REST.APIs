using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;
using REST.APIs.Data;
using REST.APIs.Models.Domain;
using REST.APIs.Models.DTOs;
using REST.APIs.Repositories;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace REST.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController(IRegionRepository regionRepository) : ControllerBase
    {
        
        private readonly IRegionRepository _regionRepository = regionRepository;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var regionsFromDomain =  await _regionRepository.GetAllAsync();
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


        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)


        {


            var regionDomain = await _regionRepository.GetByIdAsync(id);

            if (regionDomain == null)
            {
                return NotFound(id);
            }

            

            var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl,

            };

            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddRegionRequestDto addRegionRequestDto)
        {
            var regionDomain = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl,
            };

           await _regionRepository.CreateAsync(regionDomain);

            var regionDto = new AddRegionRequestDto
            {
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl,
            };

            return CreatedAtAction(nameof(GetById), new { Id = regionDomain.Id }, regionDto);

        }
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            var regionalModal = new Region
            {
                Code = updateRegionRequestDto.Code,
                Name = updateRegionRequestDto.Name,
                RegionImageUrl = updateRegionRequestDto.RegionImageUrl
            };

            regionalModal = await _regionRepository.UpdateAsync(id, regionalModal);
            if(regionalModal == null) { 

                return NotFound();
            }

            var regionDto = new Region
            {
                Code = regionalModal.Code,
                Name = regionalModal.Name,
                RegionImageUrl = regionalModal.RegionImageUrl,
            };

            return Ok(regionDto);

        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {

            var regionModel = await _regionRepository.DeleteAsync(id);


            if (regionModel == null)
            {
                return NotFound();
            }

            var regionDto = new Region
            {
                Code = regionModel.Code,
                Name = regionModel.Name,
                RegionImageUrl = regionModel.RegionImageUrl,
            };

            return Ok(regionDto);
        }

    }








}