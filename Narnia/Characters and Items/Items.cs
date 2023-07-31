using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narnia
{
    internal class Items
    {
        public string Name { get; set; }
        public int BonusAttack { get; set; }
        public int BonusDefence { get; set; }
        public int BonusIntelligence { get; set; }

        public Items(string name, int bonusattack, int bonusdefence, int bonusintelligence) 
        {
            Name = name;
            BonusAttack = bonusattack;
            BonusDefence = bonusdefence;
            BonusIntelligence = bonusintelligence;
        }
        public void Info()
        {
            Console.WriteLine(Name + "\n Bonus do ataku: +" +  BonusAttack + "%\n Bonus do obrony: +" 
                + BonusDefence + "%\n Bonus do inteligencji +" + BonusIntelligence + "%");
        }
    }
}
