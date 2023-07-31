using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narnia
{
    internal class Choices
    {
        public static string Choice()
        {
            string userInput = string.Empty;
            while (userInput != "1" && userInput != "2")
            {
                Console.WriteLine("1.Tak 2.Nie ");
                userInput = Console.ReadLine();

                if (userInput != "1" && userInput != "2")
                {
                    Console.WriteLine("Opcja o takim numerze nie istnieje\nWybierz poprawną opcję:");
                }
            }
            return userInput;
        }
    }
}
