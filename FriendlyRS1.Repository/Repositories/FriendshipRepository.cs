using DataLayer.EntityModels;
using FriendlyRS1.Repository.RepostorySetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FriendlyRS1.Repository.Repositories
{
    public class FriendshipRepository : Repository<Friendship>
    {
        private readonly ApplicationDbContext db;
        public FriendshipRepository(ApplicationDbContext context) : base(context)
        {

            db = context;
        }

        public int CountConnections(int id)
        {
            return db.Set<Friendship>().Where(x => (x.User1Id == id || x.User2Id == id) && x.Status.Status == 1).Count();
        }

        public List<TType> GetConnections<TType>(Expression<Func<Friendship, TType>> select, int id) where TType : class
        {
            List<TType> asd = db.Set<Friendship>().Where(x => (x.User1Id == id || x.User2Id == id) && x.Status.Status == 1).Select(select).ToList();
            return asd;
        }
    }
}
