using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class User /*: IdentityUser*/
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required]
        public string Pass { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        
        public int NationalCode { get; set; }
      
    }
}
