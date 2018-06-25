using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TwoStepAuth.Helpers;


namespace TwoStepAuth {
    public class Authenticator {

        private const int code_lenght = 6;
        private IConfirmationChannel confirmer = new ConfirmEmail();

        private void SendSmsWithConfirmationCode(string code) {
            // Just a placeholder function
            Console.WriteLine($"Your confirmation code is {code}");
        }

        public bool CheckFirstStep(string username, string password) {
            using (UserRepository repo = new UserRepository())
            {
                var user = repo.Users.FirstOrDefault(x => x.Username == username && x.PasswordHash == GetHash(password));
                if (user == null) return false;
                else {
                    string code = GenerateConfirmationCode(code_lenght);
                    repo.UpdateCode(user, code);
                    confirmer.SendConfirmationCode( user,  code);
                    return true;
                } 
            }
        }

        public bool CheckSecondStep(string username, string code)
        {
            using (Context con = new Context())
            {
                var user = con.Users.FirstOrDefault(x => x.Username == username && x.Code == code);
                if ((user != null) && (user.CodeGenerationDt.AddMinutes(2) > DateTime.Now))
                {
                    return true;
                }
                else return false;
            }
        }
    }
}
