using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rb.console
{
    internal class MainMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");

            while(true)
            {
                var input = Console.ReadKey().KeyChar;

                switch(input)
                {
                    case '1': RegisterMenu.Print(); break;
                    case '2': LoginMenu.Print(); break;
                    default: Environment.Exit(0); break;
                }
            }
        }
    }
}
