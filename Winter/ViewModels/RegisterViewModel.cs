﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Winter.ViewModels
{
    public class RegisterViewModel
    {
        //[Required]
        //[Display(Name = "Name ")]
        //public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Passwords do not match")]
        public string ConfirmPassword { get; set; }

        public string Name { get; set; }

    }

    public class EditUserViewModel
    {
        //public EditUserViewModel()
        //{
        //    Claims = new List<string>();
        //    Roles = new List<string>();
        //}

        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Name { get; set; }

        //public List<string> Claims { get; set; }
        //public IList<string> Roles { get; set; }
    }
}
