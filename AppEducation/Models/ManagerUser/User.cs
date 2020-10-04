using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AppEducation.Models.Account;

namespace AppEducation.Models.MangerUser {
    public class User {
        public long Id { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Tên không được vượt quá 50 kí tự")] 
        public string FirstName { get; set; } 
        [Required, MaxLength(50, ErrorMessage = "Tên không được vượt quá 50 kí tự")] 
        public string LastName { get; set; }  
       
        [Required]
        public Grade? Grade { get; set; }
        public string PhotoPath { get; set; }
        public long IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set;}
    }
}