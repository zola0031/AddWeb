using AddWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddWebAPI.Dto
{
    public class CreateExperienceDto
    {
        public String Position { get; set; }
        public String CompanyName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public Guid UserId { get; set; }
    }

    public class ExperienceDto : CreateExperienceDto
    {
        public Guid Id { get; set; }
    }

}
