using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narnia
{
    internal class Tower
    {

        private Enemy wolf = new Enemy(8, "Wilk");
        private Enemy maugrim = new Enemy(9, "Maugrim");
        private MainCharacter character;
        private Enemy jadis;

        public Tower(MainCharacter character, Enemy jadis)
        {
            this.character = character;
            this.jadis = jadis;
        }

        public void Hello() 
        {
            Console.WriteLine("Stoisz u progu zamku Białej Czarownicy. " +
                "Jeśli tam wejdziesz nie będzie już odwrotu. Czy na pewno chcesz to zrobić?");
            string choice = Choices.Choice();
            if(choice == "1")
            {
                Wolfies();
                FinallFight();
            }
            else
            {
                Console.WriteLine("Wróć gdy będziesz gotowy.");
            }
        }

        private void Wolfies()
        {
            Console.WriteLine("Otwierasz drzwi, powoli idziesz szerokim korytarzem. " +
                "Nagle słyszysz lekki szmer. Dostrzegasz Wilka na środku korytarza, który biegnie " +
                "prosto w twoją stronę. Nie masz gdzie uciekać, musisz walczyć.");
            Thread.Sleep(10000);
            Fight fight1 = new Fight(character, wolf);
            fight1.NoFight();

            Console.WriteLine("Inny wilk zaniepokojony odgłosami walki przybiega. Robi się coraz groźniej" +
                ". Musisz jak najszybciej znaleźć Białą Czarownicę, ale najpierw trzeba poradzić sobie " +
                "z tą bestią.");
            Thread.Sleep(10000);
            Fight fight2 = new Fight(character, maugrim);
            fight2.NoFight();
        }

        private void FinallFight()
        {
            Console.WriteLine("Wchodzisz do komnaty Białej Czarownicy.");
            Thread.Sleep(2000);
            Console.WriteLine("Jadis: Witaj " + character.Name + " Czekałam na ciebie. ");
            Thread.Sleep(2000);
            Console.WriteLine("Ty: Raz już zostałaś pokonana, teraz będzie podobnie.");
            Thread.Sleep(2000);
            Console.WriteLine("Jadis: Nie wydaje mi się, jestem zdecydowanie potężniejsza.");
            Thread.Sleep(2000);
            Console.WriteLine("Chcesz teraz zaatakować?");
            Thread.Sleep(2000);
            string choice = Choices.Choice();
            if (choice == "1")
            {
                Console.WriteLine("Jadis dostrzega jak wyciągasz broń i " +
                    "rzuca w ciebie sztyletem.\nTracisz 20% aktualnego zdrowia.");
                character.Health = (int)(0.8*character.Health);
            }
            else
            {
                Console.WriteLine("Ty: Nie wydaje mi się.");
                Thread.Sleep(2000);
                Console.WriteLine("Jadis zaczyna się irytować");
                Thread.Sleep(2000);
                Console.WriteLine("Jadis: Pokaż co potrafisz.");
                Thread.Sleep(2000);
                Console.WriteLine("Ty: Nie muszę ci nic udowadniać wiedźmo... ");
                Thread.Sleep(2000);
                Console.WriteLine("Jadis: Giń!!!!");
                Thread.Sleep(2000);
            }
            Fight fight = new Fight(character, jadis);
            fight.NoFight();
            Thread.Sleep(5000);
        Console.WriteLine("Gratulacje! Wygrałeś! Udało ci się pokonać Białą Czarownicę i uratować Narnię.\n" +
            "Dziękuję za grę!");
        Thread.Sleep(4000);
        Environment.Exit(0);
            
        }

    }
}
