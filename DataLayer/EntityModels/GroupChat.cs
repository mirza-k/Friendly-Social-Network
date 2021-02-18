using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.EntityModels
{
    public class GroupChat
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        public string Title { get; set; }
        public int CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        public IList<ApplicationUserGroupChat> Users { get; set; }
        public IList<Message> Messages { get; set; }
    }
}
