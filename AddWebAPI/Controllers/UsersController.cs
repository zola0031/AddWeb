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
    public class UsersController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            try
            {
                var user = _mapper.Map<User>(createUserDto);
                var response = await _userRepository.CreateAsync(user);
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
        public async Task<IActionResult> UpdateUser(Guid id, UserDto userDto)
        {
            try
            {
                var userExists = await _userRepository.GetByIdAsync(id);
                if (userExists == null)
                {
                    throw new KeyNotFoundException("user_not_found");
                }

                var user = _mapper.Map(userDto, userExists);

                await _userRepository.UpdateAsync(userExists);

                return Ok(userDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                var userExists = await _userRepository.GetByIdAsync(id);
                if (userExists == null)
                {
                    throw new KeyNotFoundException("user_not_found");
                }
                await _userRepository.DeleteAsync(userExists.Id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<UserDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var user = await _userRepository.GetAsync();
            var result = _mapper.Map<List<UserDto>>(user);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDetailDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            var result = _mapper.Map<UserDetailDto>(user);
            return Ok(result);
        }
    }
}
