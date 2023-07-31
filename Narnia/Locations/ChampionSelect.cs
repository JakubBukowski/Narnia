using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narnia
{
    internal class ChampionSelect
    {
        private int flaga = 0;
        private List<MainCharacter> champions;

        public ChampionSelect(List<MainCharacter> champions)
        {
            this.champions = champions;
        }
        private void Introduction()
        {
            Console.WriteLine("Witaj, znajdujesz się w domu profesora. " +
                "Zaraz wejdziesz do Narnii, twoim celem będzie pokonanie Białej Czarownicy, " +
                "ale zanim to uczynisz, " +
                "wybierz swoją postać podając odpowiedni numer.");
            Console.WriteLine();
            Console.WriteLine();
            for(int i = 0; i < 4; i++) 
            {
                Thread.Sleep(4000);
                Console.Write((i + 1) + ". ");
                champions[i].Info();
                Console.WriteLine();
            }

        }

        private MainCharacter Select()
        {
            string userInput = string.Empty;

            while(userInput != "1" && userInput != "2" & userInput != "3" && userInput != "4")
            {
                Console.WriteLine("Wybierz postać: ");
                userInput = Console.ReadLine();

                if (userInput != "1" && userInput != "2" & userInput != "3" && userInput != "4")
                {
                    Console.WriteLine("Postać o takim numerze nie istnieje.");
                }
            }

            if(userInput == "1")return champions[0];
            if(userInput == "2")return champions[1];
            if(userInput == "3")return champions[2];
            if (userInput == "4") return champions[3];
            else return null;
        }

        public void Exit()
        {
            Console.WriteLine("Czy na pewno chcesz wyjść z Narnii i zakończyć przygodę?");
            string choice = Choices.Choice();

            if (choice == "1")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Dziękuję za grę!");
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
        }

        public MainCharacter StoryLine()
        {
            if(flaga == 0)
            {
                flaga++;
                Introduction();
                return Select();
            }
            else
            {
                Exit();
            }
            return null;
        }
    }

}
