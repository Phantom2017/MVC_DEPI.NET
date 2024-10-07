﻿using System.ComponentModel.DataAnnotations;

namespace MVC_Day1.ViewModels
{
    public class RegisterVM
    {
        public int Id { get; set; }
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
    }
}
