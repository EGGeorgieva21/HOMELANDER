using Microsoft.IdentityModel.Tokens;
using rb.bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rb.console
{
    internal class RegisterMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("Register\n");

            Console.Write("Username: ");
            string Username = Console.ReadLine();
            Console.Write("Password: ");
            string Password = Console.ReadLine();
            Console.Write("Email: ");
            string Email = Console.ReadLine();

            if(Username.IsNullOrEmpty() || Password.IsNullOrEmpty() || Email.IsNullOrEmpty())
            {
                Console.WriteLine("\nAll input required!");
                Console.ReadKey();
                Print();
            }

            UserService userService = new UserService();

            if (!userService.RegisterUser(Username, Password, Email))
            {
                Console.WriteLine("\nUsername already taken!");
                Console.ReadKey();
                Print();
            }

            Console.WriteLine("\nUser Registered");
            Console.ReadKey();
            MainMenu.Print();
        }
    }
}
