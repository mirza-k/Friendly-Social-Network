using System;
using System.Collections.Generic;
using System.Text;
using FriendlyRS1.Repository.RepostorySetup;
using DataLayer.EntityModels;

namespace FriendlyRS1.Repository.Repositories
{
    public class UserGroupChatRepository:Repository<ApplicationUserGroupChat>
    {
        public UserGroupChatRepository(ApplicationDbContext context):base(context)
        {
        }
    }
}
