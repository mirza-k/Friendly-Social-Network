using DataLayer.EntityModels;
using FriendlyRS1.Repository.RepostorySetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendlyRS1.Repository.Repositories
{
    public class FeedbackRepository:Repository<Feedback>
    {
        public FeedbackRepository(ApplicationDbContext context):base(context)
        {
        }
    }
}
