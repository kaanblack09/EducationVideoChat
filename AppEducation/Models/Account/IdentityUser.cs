
using System;
using System.ComponentModel.DataAnnotations;
using AppEducation.Models.MangerUser;

namespace AppEducation.Models.Account {
    public class IdentityUser  {
        public long Id { get; set; }    
        [Required]    
        public string UserName { get; set; }
        [Required]    
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$")]
        public string Birthday { get; set; }

        [Required]
        public bool Sex { get; set;}
        [Required]
        [Display(Name = "Gmail or Email")] 
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage = "Không đúng định dạng")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        
        [Required]        
        public string Job { get; set;}
        
        public User UserInformation { get; set; }
    }
}