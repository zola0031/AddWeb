using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddWebAPI.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Email { get; set; }

        public String Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<Experience> Experiences { get; set; }
    }
}
