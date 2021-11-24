using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataAccessLayer
{
    public class MyContext:DbContext
    {
        public MyContext() : base("WebApiTest")
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
