using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.EntityModels
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        public string  Details { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int AreaTagId { get; set; }
        public AreaTag AreaTag { get; set; }
        public bool AdminRead { get; set; }
    }
}
