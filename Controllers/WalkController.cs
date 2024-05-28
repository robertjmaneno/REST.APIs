﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST.APIs.Models.Domain;
using REST.APIs.Models.DTOs;
using REST.APIs.Repositories;
using System.Runtime.CompilerServices;

namespace REST.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkController(IWalkRepository walkRepository) : ControllerBase
    {
        private readonly IWalkRepository _walkRepository = walkRepository;

        [HttpPost]
        public async Task<IActionResult> CreateWalks([FromBody] Walk walk)
        {
            await _walkRepository.CreateWalksAsync(walk);


            var walkDto = new Walk
            {  
                Name = walk.Name,
                Description = walk.Description,
                LengthInKm = walk.LengthInKm,
                WalkImageUrl = walk.WalkImageUrl,
                DifficuiltyId = walk.DifficuiltyId,
                RegionId = walk.RegionId,
            };

            
            
            return Ok(walkDto);
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllWalks()
        {
            var walksDomainModel = await _walkRepository.GetAllWalksAsync();
            var walksDtoModel = new List<WalksDto>();

            foreach (var walk in walksDomainModel)
            {
                var walksDto = new WalksDto
                { 
                    Id = walk.Id,
                    Name = walk.Name,
                    Description = walk.Description,
                    WalkImageUrl = walk.WalkImageUrl,
                    LengthInKm = walk.LengthInKm,
                    RegionDto = new RegionDto {
                        Id = walk.Region.Id,
                        Code = walk.Region.Code,
                        Name = walk.Region.Name,
                        RegionImageUrl = walk.Region.RegionImageUrl,
                    },
                    DifficuiltyDto = new DifficuiltyDto
                    {   Id = walk.Difficuilty.Id,                     
                        Name = walk.Difficuilty.Name,
                        
                    }
                };
                walksDtoModel.Add(walksDto);
            }

            return Ok(walksDtoModel);
        }

        [HttpGet("{id:Guid}")]

        public async Task<IActionResult> GetWalkById([FromRoute] Guid id)
        {
            var walkDomainModel  = await _walkRepository.GetWalkById(id);
            var walkDto = new WalksDto
            {  Id = walkDomainModel.Id,
                Name = walkDomainModel.Name,
                Description = walkDomainModel.Description,
                WalkImageUrl = walkDomainModel.WalkImageUrl,
                LengthInKm = walkDomainModel.LengthInKm,
                RegionDto = new RegionDto
                {
                    Id = walkDomainModel.Region.Id,
                    Code = walkDomainModel.Region.Code,
                    Name = walkDomainModel.Region.Name,
                },
                DifficuiltyDto = new DifficuiltyDto
                {
                    Id = walkDomainModel.Difficuilty.Id,
                    Name = walkDomainModel.Difficuilty.Name

                }

            };
           

            return Ok(walkDto);



    }

    }


}
