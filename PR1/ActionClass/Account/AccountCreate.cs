﻿using System.ComponentModel.DataAnnotations;

namespace PR1.ActionClass.Account
{
    public class AccountCreate
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }
        [Required]
        public string? Fname { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Sex { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
