using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narnia
{
    internal class MainCharacter
    {
        private int expirience = 0;

        private int lvl = 1;
        private Items item = new Items("brak", 0, 0, 0);
        public string Name { get;}
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Intelligence { get; set; }
        public int Health { get; set; } = 20;
        public Items Item
        {
            get { return item; }
            set
            {
                item = value;
                Console.WriteLine("Twoja nowa broń: " + item.Name);
            }
        }


        public MainCharacter(string name, int attack, int defence, int intelligence)
        {
            Name = name;
            Attack = attack;
            Defence = defence;
            Intelligence = intelligence;
        }

        public void AddExpirience(int exp)
        {
            expirience = expirience + exp;
            Console.WriteLine("Zdobywasz " + exp +" punktów doświadczenia.");
            if(expirience >= 100 && lvl < 5)
            {
                LvlUp(expirience-100);
            }
        }

        private void LvlUp(int extraExp)
        {
            lvl = lvl + 1;
            expirience = extraExp;
            Attack = (int)(1.1 * Attack);
            Defence = (int)(1.1 * Defence);
            Intelligence = (int)(1.1 * Intelligence);
            if(lvl == 5)
            {
                Console.WriteLine("Osiągnąłeś najwyższy level.");
            }
            Console.WriteLine("Lvl up!!!");
            Console.WriteLine("Stats +10%");
            Info();
            Thread.Sleep(4000);
        }

        public void Info()
        {
            Console.WriteLine(Name + "\n Atak: " + Attack +
                    "\n Obrona: " + Defence + "\n Inteligencja: " + Intelligence +
                    "\n Zdrowie: " + Health + "\n Broń: " + Item.Name);
        }

    }
}
