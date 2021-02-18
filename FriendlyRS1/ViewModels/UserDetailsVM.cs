using DataLayer.EntityModels;
﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FriendlyRS1.ViewModels
{
    public class UserDetailsVM
    {
        public int UserId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Birth date")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name ="Phone number")]
        public  string PhoneNumber { get; set; }
        [Display(Name = "Gender")]
        public char Gender { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public bool Me { get; set; } = false;
        public int ConnectionsCount { get; set; }
        public int HobbiesCount { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
        public string GetAge()
        {

            var today = DateTime.Today;

            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (this.DateOfBirth.Year * 100 + this.DateOfBirth.Month) * 100 + this.DateOfBirth.Day;

            return $"{(a - b) / 10000} years";
        }
        public byte[] ProfileImage { get; set; }
    }
}
