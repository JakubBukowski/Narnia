using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narnia
{
    internal class Dam
    {
        private int flaga = 0;
        private int potions = 2;
        private MainCharacter character;
        public Dam(MainCharacter character)
        {
            this.character = character;
        }
        private void Hello()
        {
            flaga++;
            Console.WriteLine("Nagroda za pierwszą wizytę.");
            character.AddExpirience(40);
            Console.WriteLine("Docierasz do tamy bobrów i pukasz do drzwi. Otwiera Pani Bobrowa.");
            Thread.Sleep(2000);
            Console.WriteLine("Pani Bobrowa: Witaj, jak dawno cię nie widziałam.");
            Thread.Sleep(2000);
            Console.WriteLine("Ty: Dobrze cię znowu widzieć.");
            Thread.Sleep(2000);

        }

        private void NextVisit()
        {
            Console.WriteLine("Docierasz do tamy. Pukasz do drzwi. Otwiera Pani Bobrowa.");
            Thread.Sleep(2000);
            Console.WriteLine("Pani Bobrowa: O! To znowu ty, dobrze cię widzieć!");
            Thread.Sleep(2000);
            Console.WriteLine("Ty: Ciebie również!");
            Thread.Sleep(2000);
        }

        private void Healing()
        {
            if(potions > 0)
            {
                Console.WriteLine("Pani Bobrowa: Może masz ochotę coś zjeść?");
                Thread.Sleep(2000);
                Console.WriteLine("INFO: zjedzenie obiadu przywraca ci całe zdrowie. \n" +
                    "Pozostała ci następująca liczba posiłków: " + potions);
                string choice = Choices.Choice();
                if(choice == "1")
                {
                    potions--;
                    character.Health = 20;
                    Console.WriteLine("Zjadasz obiad przygotowany przez Panią Bobrową.");
                    Thread.Sleep(2000);
                    Console.WriteLine("Ty: Dziękuję za posiłek, wyruszam w dalszą drogę.");
                    Thread.Sleep(2000);
                    Console.WriteLine("Pani Bobrowa: Mam nadzieję, że się szybko zobaczymy.");
                    Thread.Sleep(2000);

                }
                else
                {
                    Console.WriteLine("Ty: Może następnym razem. Odpocznę chwilę i ruszam w dalszą trasę.");
                    Thread.Sleep(3000);
                    Console.WriteLine("Po krótkim pdpoczynku kontynuujesz przygodę.");
                }
            }
            else
            {
                Console.WriteLine("Pani Bobrowa: Chciałabym cię czymś poczęstować, " +
                    "ale przez Białą Czarownicę " +
                    "nie mamy już nic do jedzenia.\n" +
                    "Jak sobie radzisz?");
                Thread.Sleep(3000);
                Console.WriteLine("Ty: Nawet nieźle. Odpocznę chwilę i będę ruszał w trasę. " +
                    "Nie macie nic przeciwko?");
                Thread.Sleep(3000);
                Console.WriteLine("Pani Bobrowa: Jak najbardziej możesz się u nas zatrzymać.");
                Thread.Sleep(2000);
                Console.WriteLine("Po krótkim pdpoczynku wyruszasz kontynuować przygodę.");
                Thread.Sleep(2000);
            }

        }

        public void StoryLine()
        {
            if(flaga==0)
            {
                Hello();
            }
            else
            {
                NextVisit();
            }
            Healing();
        }
    }
}
