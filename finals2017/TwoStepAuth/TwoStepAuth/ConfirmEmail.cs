using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoStepAuth
{
   public class ConfirmEmail : IConfirmationChannel
    {
       public void SendConfirmationCode(User user, string code)
        {
            Console.WriteLine($"Email sent to {user.Email} with code {code}");
        }
    }
}
