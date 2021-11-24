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
    public class MainRepo<T> : IMainRepo<T> where T : BaseModel
    {
        private DbContext Context;
        private DbSet<T> Table;

        public MainRepo(IContextFactory _Context)
        {
            Context = _Context.GetContext();
            Table = Context.Set<T>();
        }
        public void Add(T Entity)
        {
            Table.Add(Entity);
        }

        public void Delete(T Entity)
        {
            Context.Entry(Entity).State = EntityState.Deleted;
        }

        public void Edit(T Entity)
        {
            Context.Entry(Entity).State = EntityState.Modified;
        }

        public IQueryable<T> Get()
        {
            return Table;
        }

        public T Get(int id)
        {
            return Table.Where(i => i.ID == id).FirstOrDefault();
        }
    }
}
