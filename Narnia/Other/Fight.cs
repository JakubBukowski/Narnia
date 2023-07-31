using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narnia
{
    internal class Fight
    {
        private MainCharacter character1;
        private Enemy character2;

        public Fight(MainCharacter character1, Enemy character2)
        {
            this.character1 = character1;
            this.character2 = character2;
        }

        public void NoFight()
        {
            character2.ShowStats();
            Thread.Sleep(4000);
            Random random = new Random();
            int randomNumber = random.Next(1, 101);
            if (randomNumber <= (int)(character1.Intelligence + (character1.Intelligence *
                    character1.Item.BonusIntelligence / 100)))
            {
                Console.WriteLine("Dzięki inteligencji udało ci się przechytrzyć przeciwnika bez walki.");
                character1.AddExpirience(60);
                Thread.Sleep(2000);

            }
            else
            {
                StartFight();
            }

            Console.WriteLine("Twoje aktualne zdrowie wynosi: " + character1.Health + "pkt.");
        }
        public void StartFight()
        {
            Console.WriteLine($"Walka {character1.Name} kontra {character2.Name} rozpoczyna się!");

            int damage1 = CalculateDamage(character1.Attack + (character1.Attack*character1.Item.BonusAttack/100), 
                character2.Defence);
            int damage2 = CalculateDamage(character2.Attack, character1.Defence + (character1.Defence * character1.Item.BonusDefence / 100));

            Console.WriteLine($"{character1.Name} zadaje {damage1} obrażeń {character2.Name}.");
            Thread.Sleep(3000);
            Console.WriteLine($"{character2.Name} zadaje {damage2} obrażeń {character1.Name}.");
            Thread.Sleep(3000);

            if (damage1 > damage2)
            {
                Console.WriteLine($"{character1.Name} wygrywa walkę!");
                Health(damage2);
                Thread.Sleep(3000);
                Console.WriteLine("To było wspaniałe zwycięstwo. Gratulacje!");
                character1.AddExpirience(70);
                Thread.Sleep(1000);
            }
            else if (damage1 < damage2)
            {
                Console.WriteLine($"{character2.Name} wygrywa walkę!");
                if (character2.Name == "Jadis")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Zostałeś pokonany przez Białą Czarownicę" +
                        ".\nPrzegrałeś\nDziękuję za grę!");
                    Thread.Sleep(3000);
                    Environment.Exit(0);
                }
                Health(damage2);
                Thread.Sleep(3000);
                Console.WriteLine("Nie zawsze się wygrywa. Zbierz siły na nowo, " +
                    "może następnym razem będzie lepiej");
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("Walka zakończona remisem!");
                if(character2.Name == "Jadis")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Było tak blisko, ale niestety zabrakło ci sił, żeby" +
                        "przechylić szalę zwycięstwa na swoją stronę.\nPrzegrałeś\nDziękuję za grę!");
                    Thread.Sleep(3000);
                    Environment.Exit(0);
                }
                Health(damage2);
                Thread.Sleep(3000);
                Console.WriteLine("Nikt nie wygrał, ale zawsze to cenne doświadczenie.");
                Thread.Sleep(1000);
                character1.AddExpirience(35);
                Thread.Sleep(1000);


            }
        }
        private int CalculateDamage(int attack, int defence)
        {
            int damage = attack - defence;
            return Math.Max(0, damage);
        }

        private void Health(int damage)
        {
            character1.Health = character1.Health - damage;
            if (character1.Health < 0)
            {
                Thread.Sleep(3000);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Niestety obrażenia otrzymane w walce okazały się za ciężkie.\n" +
                    "Twoja postać umarła. Przegrałeś\nDziękuję za grę!");
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
        }
    }
}
