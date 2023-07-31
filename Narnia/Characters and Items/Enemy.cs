using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narnia
{
    internal class Enemy
    {
        private int lvl;
        public string Name { get; }
        public int Attack { get; set; } = 25;
        public int Defence { get; set; } = 22;

        public Enemy(int lvl, string name) 
        {
            this.lvl = lvl;
            Name = name;
            NewStats(lvl);
        }

        private void NewStats(int lvl)
        {
            for(int i = 1; i < lvl; i++)
            {
                Attack = (int)(Attack * 1.10);
                Defence = (int)(Defence * 1.10);
            }
        }

        public void ShowStats()
        {
            Console.WriteLine(Name +"\n Lvl:" + lvl + "\n Atak: " + Attack + "\n Obrona: " + Defence);
        }
    }
}
