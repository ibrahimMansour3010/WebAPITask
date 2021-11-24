using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IMainRepo<T>
    {
        IQueryable<T> Get();
        T Get(int id);
        void Add(T Entity);
        void Edit(T Entity);
        void Delete(T Entity);
    }
}
