using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UniteOfWork : IUnitOfWork
    {
        DbContext Context;
        IMainRepo<User> UserRepo;
        public UniteOfWork(IContextFactory contextFactory,
            IMainRepo<User> _UserRepo)
        {
            Context = contextFactory.GetContext();
            UserRepo = _UserRepo;
        }

        public IMainRepo<User> GetUserRepo()
        {
            return UserRepo;
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
