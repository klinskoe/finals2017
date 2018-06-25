using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoStepAuth {
    public class UserRepository : IDisposable {
        private Context con = new Context();

        public IEnumerable<User> Users
        {
            get
            {
                return con.Users;
            }
        }

        public  void UpdateCode(User user, string code)
        {
            user.Code = code;
            user.CodeGenerationDt = DateTime.Now;
            con.SaveChanges();
        }

        public void Dispose()
        {
            con.Dispose();
        }
    }
}
