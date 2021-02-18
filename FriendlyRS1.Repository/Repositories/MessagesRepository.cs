using System;
using System.Collections.Generic;
using System.Text;
using FriendlyRS1.Repository.RepostorySetup;
using DataLayer.EntityModels;

namespace FriendlyRS1.Repository.Repositories
{
    public class MessagesRepository:Repository<Message>
    {
        public MessagesRepository(ApplicationDbContext context):base(context)
        {

        }
    }

}
