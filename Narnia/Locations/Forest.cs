using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narnia
{
    internal class Forest
    {
        private int flaga = 0;
        private Enemy firstenemy = new Enemy(2, "Wilk");
        private MainCharacter character;

        public Forest(MainCharacter character)
        {
            this.character = character;
        }
        private void Tumnus()
        {
            Console.WriteLine("Wchodzisz do szafy i nagle znajdujesz się w Narnii " + 
                "po środku lasu. Wszystko wokół jest zasypane przez śnieg. Nieufnie przebijasz się przez zaspy. " +
                "Nagle dostrzegasz z daleka znajome stworzenie - to Pan Tumnus.");
            Thread.Sleep(7000);
            Console.WriteLine("Tumnus: Witaj " + character.Name + "!");
            Thread.Sleep(2000);
            Console.WriteLine("Ty: Dobrze cię widzieć. " +
                "Ale czemu Narnia znowu jest cała pokryta śniegiem? " +
                "Biała Czarownica wróciła?");
            Thread.Sleep(5000);
            Console.WriteLine("Tumnus: Niestety tak... Wszystko wraca do czasów sprzed naszego zwycięstwa. " +
                "Jadis z każdym dniem rośnie w siłę. Pomożesz nam ją powstrzymać?");
            string choice = Choices.Choice();

            if (choice == "1")
            {
                Console.WriteLine("Dziękuję. " +
                "Postaraj się jak najlepiej przygotować do walki z Białą Czarownicą " +
                "podróżując przez Narnię, zdobywając przedmioty i doświadczenie.");
                Thread.Sleep(5000);

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Zawiodłem się na tobie... " +
                "Myślałem, że jesteś lepszym człowiekiem... Idź precz...\n\nPrzegrałeś...\nDziękuję za grę!");
                Thread.Sleep(4000);
                Environment.Exit(0);
            }
        }

        private void Dangerous()
        {
            Console.WriteLine("Dochodzisz na skraj lasu, gdzie dostrzegasz samotnego wilka. " +
                "Ze swojego doświadczenia wiesz, że wilki służą białej czarownicy. " +
                "Czy chcesz z nim zawalczyć?\nINFO: Z każdą wizytą w lesie siła wilków wzrasta");
            string choice = Choices.Choice();
            if (choice == "1")
            {
                Console.WriteLine("Zbliżasz się powoli do wilka, " +
                    "on cię zauważa i biegnie w twoją stronę.");
                Fight fight = new Fight(character, firstenemy);
                fight.NoFight();
                Thread.Sleep(3000);

            }
            else
            {
                Console.WriteLine("Skrdasz się ostrożnie, aby wilk cię nie zauważył, " +
                    "udaje ci się oddalić na bezpieczną odległość.");
                character.AddExpirience(30);
                Thread.Sleep(4000);


            }
        }

        private void Centurion()
        {
            Console.WriteLine("Rozstajesz się z Panem Tumnusem, " +
                "wyruszasz w dalszą podróż przez las. \", gdzie spotykasz centaura.\n" +
                "Centaur: Witaj, czy jesteś przyjacielem Aslana?");
            string choice = Choices.Choice();
            if (choice == "1")
            {
                Console.WriteLine("Centaur: Przekonajmy się. " +
                    "Czy Aslan był obecny od samego początku istnienia Narnii?");
                string choice2 = Choices.Choice();
                if (choice2 == "1") {
                    Console.WriteLine("Centaur: Rzeczywiście jesteś przyjacielem Aslana. " +
                    "Weź mój miecz. Za Narnieee!!!");
                    Thread.Sleep(5000);
                    Items sword = new Items("Miecz", 15, 15, 10);
                    sword.Info();
                    Thread.Sleep(3000);
                    character.Item = sword;
                    character.AddExpirience(50);
                    Thread.Sleep(3000);
                }
                else
                {
                    Console.WriteLine("Giń kłamco!\n" +
                        "Udzieliłeś niepoprawnej odpowiedzi." +
                        " Centaur bierze Cię za sojusznika Białej Czarownicy, " +
                        "ponieważ skłamałeś, że jesteś przyjacielem Aslana i cię atakuje.");
                    Thread.Sleep(5000);
                    Enemy centurion = new Enemy(5, "Centaur");
                    Fight fight = new Fight(character, centurion);
                    fight.NoFight();
                }
            }
            else
            {
                Console.WriteLine("Centaur: Zatem nie jesteś i moim przyjacielem. \n" +
                    "Centaur Odchodzi.");
                Thread.Sleep(2000);

            }
        }

        private void MeetWolf()
        {
            Console.WriteLine("Wracasz do lasu.");
            Enemy wolf = new Enemy(3*flaga+2, "Wilk");
            Console.WriteLine("Wędrując przez las zauważasz wilka. Czy chcesz z nim walczyć?");
            string choice = Choices.Choice();
            if (choice == "1")
            {
                Fight fight = new Fight(character, wolf);
                fight.NoFight();
            }
            else
            {
                Random random = new Random();
                int randomNumber = random.Next(1, 101);
                if(randomNumber <= (int)(1.5*(character.Intelligence+(character.Intelligence*
                    character.Item.BonusIntelligence/100))))
                {
                    Console.WriteLine("Udało ci się uciec.");
                    character.AddExpirience(30);
                    Thread.Sleep(2000);

                }
                else
                {
                    Console.WriteLine("Nie udało ci się uciec.");
                    Fight fight = new Fight(character, wolf);
                    fight.NoFight();
                }
            }
        }

        public void StoryLine()
        {
            if (flaga == 0)
            {
                Tumnus();
                Centurion();
                Dangerous();
                flaga++;
            }
            else
            {
                MeetWolf();
                flaga++;
            }
        }
    }
}
