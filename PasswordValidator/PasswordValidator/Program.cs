using System.Reflection.Metadata.Ecma335;
using System.Linq;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartController();
        }

        #region Controller
        static void StartController()
        {
            const int FAIL = 0;
            const int SUCCESS = 1;
            const int DOWNGRAD = 2;
            while (true)
            {
                string reason = null;
                string reason1 = "Password not between 12 and 64 characters\n";
                string reason2 = "Password does not contain both uppercase and lowercase\n";
                string reason3 = "Password does not contain a number\n";
                string reason4 = "Password does not contain minimum 1 special character\n";
                StartGUI();
                string password = Console.ReadLine();
                password.Trim();
                if (CheckLength(password) == false)
                {
                    reason += reason1;
                }
                if (CheckUpperLower(password) == false)
                {
                    reason += reason2;
                }
                if (CheckNumber(password) == false)
                {
                    reason += reason3;
                }
                if (CheckSpecial(password) == false)
                {
                    reason += reason4;
                }

                if (reason == null)
                {
                    GUI(SUCCESS);
                }
                else
                {
                    GUI(FAIL, reason);
                }

                var key = Console.ReadKey();
                if (key.Key != ConsoleKey.Enter)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                }
            }
            
        }
        #endregion Conroller

        #region GUI
        static void GUI (int input, string reason)
        {
            if (input == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fail!");
                Console.ResetColor();
                Console.WriteLine(reason);

                Console.WriteLine("\nPress enter to try again or any other key to exit");
            }

        }
        static void GUI(int output)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Success!");
            Console.ResetColor();
        }
        static void StartGUI()
        {
            Console.WriteLine("Check if a password to check if it is a valid strong password");
            Console.WriteLine("The rules are as following:");
            Console.WriteLine("The password must be between 12 - 64 characters.");
            Console.WriteLine("The password must include a mix of Upper and Lower case.");
            Console.WriteLine("The password must include a mix of letters and digits.");
            Console.WriteLine("The password must contain at least 1 special character.");
            Console.WriteLine("\nIf these are achieved, the password is OK, but can be downgraded if one of the following two is not achieved:");
            Console.WriteLine("The password must not contain 4 of the same character in a row.");
            Console.WriteLine("The password must not contain 4 consecutive digits.");
            Console.Write("Enter a password here to check if it is OK: ");
        }
        #endregion GUI

        #region Model
        static bool CheckLength(string password)
        {
            if (password.Length > 11 && password.Length < 65)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool CheckUpperLower(string password)
        {
            if (password.Any(ch => char.IsLower(ch)) && password.Any(ch => char.IsUpper(ch)))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        static bool CheckNumber(string password)
        {
            return password.Any(ch => char.IsDigit(ch));
        }
        static bool CheckSpecial(String password)
        {
            return password.Any(ch => ! char.IsLetterOrDigit(ch));
        }

        #endregion Model
    }
}