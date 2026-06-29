using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml.Linq;

namespace TankBattle.Classes
{
    abstract class Tank
    {
        public int MaxHP { get; protected set; }
        public int HP { get; set; }
        public float DodgeChance { get; protected set; }

        public Armor Armor { get; set; }
        public List<Weapon> Weapons { get; set; } = new();
        public List<Ammo> Ammunition { get; set; } = new();

        public Tactic Strategy { get; set; }

        public bool IsAlive => HP > 0;

        public abstract void Attack(List<Tank> enemies);

        public bool DodgeAttac()
        {
            return Random.Shared.NextDouble() < DodgeChance;
        }

        /*
            Легкий танк - 400 HP, повышенный шанс уклонения (15%);
            Средний танк - 550 HP, шанс уклонения 7%;
            Тяжелый танк - 750 HP, шанс уклонения 0%, может иметь 2 орудия (стреляет дважды за ход);
         */

        /*
            - орудие (3 вида с разными характеристиками);
	        - броня (3 вида с разными характеристиками);
	        - боеприпасы (3 вида с разными характеристиками);   
        */
    }
}
