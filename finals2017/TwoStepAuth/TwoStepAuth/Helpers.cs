using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TwoStepAuth {
    // DO NOT EDIT
    static class Helpers {
        private static Random r = new Random();

        public static string GetHash(string password) {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }
        
        public static string GenerateConfirmationCode(int length) {
            var sb = new StringBuilder();
            for (int i = 0; i < length; i++) {
                sb.Append((char)('0' + r.Next(10)));
            }
            return sb.ToString();
        }
    }
}
