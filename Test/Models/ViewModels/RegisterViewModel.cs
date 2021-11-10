//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Test.Models.ViewModels
//{
//    public class RegisterViewModel
//    {
//        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
//        public int idUser { get; set; }

//        public string FirstName { get; set; }

//        public string LastName { get; set; }

//        public string Pass { get; set; }

//        public string Address { get; set; }

//        public string Degree { get; set; }

//        public string NationalCode { get; set; }

//        public string Email { get; set; }

//        [NotMapped]
//        [Required]
//        [System.ComponentModel.DataAnnotations.Compare("Pass")]
//        public string ConfirmPassword { get; set; }

//    }
//}
