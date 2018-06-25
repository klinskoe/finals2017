using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoStepAuth
{
    class Context : DbContext 
    {
        public DbSet<User> Users { get; set; }

        public Context() : base("exam")
        {

        }
    }
}
