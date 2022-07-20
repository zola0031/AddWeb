using AddWebAPI.Dto;
using AddWebAPI.Models;
using AddWebAPI.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AddWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ExperiencesController : ControllerBase
    {

        private readonly IExperienceRepository _experienceRepository;
        private readonly IMapper _mapper;

        public ExperiencesController(IExperienceRepository experienceRepository, IMapper mapper)
        {
            _experienceRepository = experienceRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateExperience(CreateExperienceDto createExperienceDto)
        {
            try
            {
                var experience = _mapper.Map<Experience>(createExperienceDto);
                var response = await _experienceRepository.CreateAsync(experience);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Update(Guid id, ExperienceDto experienceDto)
        {
            try
            {
                var experienceExists = await _experienceRepository.GetByIdAsync(id);
                if (experienceExists == null)
                {
                    throw new KeyNotFoundException("experience_not_found");
                }

                var user = _mapper.Map(experienceDto, experienceExists);

                await _experienceRepository.UpdateAsync(experienceExists);

                return Ok(experienceDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var userExists = await _experienceRepository.GetByIdAsync(id);
                if (userExists == null)
                {
                    throw new KeyNotFoundException("experience_not_found");
                }
                await _experienceRepository.DeleteAsync(userExists.Id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //[HttpGet("{userId}")]
        //[ProducesResponseType(typeof(List<ExperienceDto>), (int)HttpStatusCode.OK)]
        //public async Task<IActionResult> GetByUserId(Guid userId)
        //{
        //    var experience = await _experienceRepository.GetAsync();
        //    var result = _mapper.Map<List<ExperienceDto>>(experience);
        //    return Ok(result);
        //}

        [HttpGet]
        [ProducesResponseType(typeof(List<ExperienceDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var experience = await _experienceRepository.GetAsync();
            var result = _mapper.Map<List<ExperienceDto>>(experience);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ExperienceDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var experience = await _experienceRepository.GetByIdAsync(id);
            var result = _mapper.Map<ExperienceDto>(experience);
            return Ok(result);
        }
    }
}
