using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.EntityModels
{
    public class ApplicationUserGroupChat
    {
        public DateTime JoinDate { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int GroupId { get; set; }
        public GroupChat Group { get; set; }
    }
}
