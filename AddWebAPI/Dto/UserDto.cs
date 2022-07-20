using AddWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddWebAPI.Dto
{
    public class CreateUserDto
    {
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Email { get; set; }

        public String Address { get; set; }

        public DateTime DateOfBirth { get; set; }
    }

    public class UserDto: CreateUserDto
    {
        public Guid Id { get; set; }
    }

    public class UserDetailDto: UserDto
    {
        public List<ExperienceDto> Experiences { get; set; } = new List<ExperienceDto>();
    }
}
