using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.EntityModels;

namespace FriendlyRS1.ViewModels
{
    public class GroupChatVM
    {
        public GroupChat groupChat { get; set; }
        public ApplicationUser User { get; set; }
        public List<ApplicationUserGroupChat> Participants { get; set; }
        public List<Message> Messages { get; set; }
    }
}
