using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoStepAuth {
    // DO NOT EDIT
    class Program {
        static string ReadPassword() {
            StringBuilder sb = new StringBuilder();
            ConsoleKeyInfo key;
            do {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape) {
                    sb.Append(key.KeyChar);
                    Console.Write("*");
                }
                else {
                    if (key.Key == ConsoleKey.Backspace && sb.Length > 0) {
                        sb.Remove(sb.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                }
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return sb.ToString();
        }

        static void Main(string[] args) {
            Console.Write("Enter username: ");
            var username = Console.ReadLine();
            Console.Write("Enter password: ");
            var password = ReadPassword();

            var authenticator = new Authenticator();
            if (authenticator.CheckFirstStep(username, password)) {
                Console.WriteLine("Enter confirmation code: ");
                var code = Console.ReadLine();
                if (authenticator.CheckSecondStep(username, code))
                    Console.WriteLine("Success!!!");
                else
                    Console.WriteLine("Invalid confirmation code");
            }
            else {
                Console.WriteLine("Incorrect username / password");
            }
            Console.ReadKey();
        }
    }
}
