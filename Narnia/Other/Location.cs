using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narnia
{
    internal class Location
    {
        private string currentLocation;
        private Graph map;
        private List<string> list = new List<string>();

        public Location(string currentLocation, Graph map)
        {
            this.currentLocation = currentLocation;
            this.map = map;
        }
        
        public string NewLocation()
        {
            list = map.GetNeighbors(currentLocation);
            if (list.Count == 1)
            {
                currentLocation = list[0];
                return list[0];
            }
            else
            {
                if (list.Count == 2) return SmallChoice();
                else return BigChoice();
            }
        }

        private string SmallChoice() 
        {
            string userInput = string.Empty;
            while (userInput != "1" && userInput != "2")
            {
                Console.WriteLine("1. " + list[0] + " 2. " + list[1]);
                userInput = Console.ReadLine();

                if (userInput != "1" && userInput != "2")
                {
                    Console.WriteLine("Opcja o takim numerze nie istnieje");
                }
            }
            if (userInput == "1")
            {
                currentLocation = list[0];
                return list[0];
            }
            else
            {
                currentLocation = list[1];
                return list[1];
            }
        }

        private string BigChoice()
        {
            string userInput = string.Empty;
            while (userInput != "1" && userInput != "2" && userInput != "3" 
                && userInput != "4")
            {
                Console.WriteLine("1. " + list[0] + " 2. " + list[1] + " 3. " + list[2] 
                    + " 4. " + list[3]);
                userInput = Console.ReadLine();

                if (userInput != "1" && userInput != "2" && userInput != "3" 
                    && userInput != "4")
                {
                    Console.WriteLine("Opcja o takim numerze nie istnieje");
                }
            }
            return GoThere(userInput);
        }

        private string GoThere(string option)
        {
            switch (option)
            {
                case "1":
                    currentLocation = list[0];
                    return list[0];
                case "2":
                    currentLocation = list[1];
                    return list[1];
                case "3":
                    currentLocation = list[2];
                    return list[2];
                case "4":
                    currentLocation = list[3];
                    return list[3];
            }
            return "0";
        }
    }
}
