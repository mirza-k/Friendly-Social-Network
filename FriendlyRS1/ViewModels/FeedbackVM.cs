using DataLayer.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FriendlyRS1.ViewModels
{
    public class FeedbackVM
    {
        [Required]
        public int areaTagId{ get; set; }
        [Required]
        public string Details { get; set; }
        public List<SelectListItem> areaTagList { get; set; }
    }
}
