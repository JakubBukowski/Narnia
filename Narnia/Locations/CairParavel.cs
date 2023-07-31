using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narnia
{
    internal class CairParavel
    {
        private int flaga = 0;
        private Items item1 = new Items("Rhindon", 35, 25, 15);
        private Items item2 = new Items("Świetlisty Łuk", 15, 20, 40);
        private Items item3 = new Items("Zbroja", 15, 40, 20);
        private Items item4 = new Items("Magiczny Róg", 25, 25, 25);
        private MainCharacter character;
        public CairParavel(MainCharacter character)
        {
            this.character = character;
        }

        public void Visit()
        {
            Console.WriteLine("Wchodzisz do zamku Cair Paravel. " +
                "Schodzisz schodami do pomieszczenia ze skrzyniami.");
            if(flaga == 0)
            {
                Console.WriteLine("Nagroda za pierwszą wizytę");
                character.AddExpirience(40);
                Thread.Sleep(1000);

            }
            flaga++;
            Armory();
            Console.WriteLine("Czy chcesz wybrać którąś z powyższych broni?");
            string choice = Choices.Choice();
            if(choice == "1")
            {
                Console.WriteLine("Wybierz broń");
                string weapon = Choice();
                Equip(weapon);
                Console.WriteLine("Faun: Cieszymy się, że odwiedziłeś Cair Paravel. " +
                    "Mamy nadzieję, że będziesz częściej tu zalądał.");
                Thread.Sleep(4000);

            }
            else
            {
                Console.WriteLine("Faun: Cieszymy się, że odwiedziłeś Cair Paravel. " +
                    "Mamy nadzieję, że będziesz częściej tu zaglądał i " +
                    "następnym razem skorzystasz z naszej zbrojowni");
                Thread.Sleep(4000);

            }

        }

        private string Choice()
        {
            string userInput = string.Empty;

            while (userInput != "1" && userInput != "2" & userInput != "3" && userInput != "4")
            {
                userInput = Console.ReadLine();

                if (userInput != "1" && userInput != "2" & userInput != "3" && userInput != "4")
                {
                    Console.WriteLine("Broń o takim numerze nie istnieje.");
                }
            }

            return userInput;
        }
        private void Armory()
        {
            Thread.Sleep(3000);
            Console.Write("1.");
            item1.Info();
            Thread.Sleep(3000);
            Console.Write("2.");
            item2.Info();
            Thread.Sleep(3000);
            Console.Write("3.");
            item3.Info();
            Thread.Sleep(3000);
            Console.Write("4.");
            item4.Info();
        }
        private void Equip(string number)
        {
            switch (number)
            {
                case "1":
                    character.Item = item1;
                    break;
                case "2":
                    character.Item = item2;
                    break;
                case "3":
                    character.Item = item3;
                    break;
                case "4":
                    character.Item = item4;
                    break;
            }
        }
    }
}
