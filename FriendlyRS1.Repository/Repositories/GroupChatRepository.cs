using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.EntityModels;
using FriendlyRS1.Repository.RepostorySetup;

namespace FriendlyRS1.Repository.Repositories
{
    public class GroupChatRepository: Repository<GroupChat>
    {
        public GroupChatRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
