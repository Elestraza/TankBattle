using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml.Linq;

namespace TankBattle.Classes
{
    abstract class Tank
    {
        public String Name { get; set; }
        public Int32 MaxHP { get; protected set; }
        public Int32 HP { get; set; }
        public float DodgeChance { get; protected set; }

        public Armor Armor { get; set; }
        public Weapon Weapons { get; set; }
        public Ammo Ammunition { get; set; }

        public Tactic Strategy { get; set; }

        public Boolean IsAlive => HP > 0;

        public Boolean IsTarget = false;

        public Boolean IsHit = false;

        public abstract void Attack(List<Tank> enemies);

        public void DodgeAttac()
        {
            if (!(Random.Shared.NextDouble() < DodgeChance)) IsHit = true;

        }

        public void HitRegister(Weapon weapon, Ammo ammo, Armor armor, Weapon accuracy, int damage) 
        {
            if (IsHit = true)
                HP = HP - damage;
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
