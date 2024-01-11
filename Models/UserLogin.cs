﻿using System.ComponentModel.DataAnnotations;
namespace Biblioteka.Models
{
    public class UserLogin
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Please Enter Username")]
        [Display(Name = "Please Enter Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "Please Enter Password")]
        public string passcode { get; set; }
        public int isActive { get; set; }

    }
}