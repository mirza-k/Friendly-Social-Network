using DataLayer.EntityModels;
using FriendlyRS1.Repository.RepostorySetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendlyRS1.Repository.Repositories
{
    public class AreaTagRepository:Repository<AreaTag>
    {
        public AreaTagRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
