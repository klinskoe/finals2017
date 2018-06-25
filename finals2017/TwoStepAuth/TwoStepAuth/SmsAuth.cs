using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoStepAuth
{
    public class SmsAuth : IConfirmationChannel
    {
       public void SendConfirmationCode(User user, string code)
        {
            Console.WriteLine($"SMS sent to {user.Telephone} with code {code}");
        }
    }
}
