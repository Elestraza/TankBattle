using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml.Linq;
using TankBattle.Inventory;

namespace TankBattle.Classes
{
    abstract class Tank
    {
        public String Name { get; set; }
        public Int32 MaxHP { get; protected set; }
        public Int32 HP { get; set; }
        public Int32 MaxWeight { get; protected set; }
        public Int32 Weight { get; set; }
        public float DodgeChance { get; protected set; }

        public Armor Armor { get; set; }
        public Weapon Weapons { get; set; }
        public List<Ammo> Ammunition { get; set; } = new();
        public Int32 MaxAmmo { get; protected set; }
        public Int32 CurrentAmmo { get; set; }

        public Int32 GunsQuantity { get; protected set; }
        public Tactic Strategy { get; set; }

        public Boolean IsAlive => HP > 0;

        public Boolean IsTarget = false;
        

        public void Attack(List<Tank> enemies)
        {
            for (int i = 0; i < GunsQuantity; i++)
            {
                if (Ammunition.Count > 0)
                {
                    CurrentAmmo--;
                    Strategy.SelectTarget(this, enemies);
                } else
                {
                    Console.WriteLine("У Танка " + Name + " кончились снаряды.");
                    RecieveAmmo();
                }
            }
        }

        public void HitRegister(int damage, Ammo ammo) 
        {
            if (!(Random.Shared.NextDouble() < DodgeChance))
            {
                HP -= Armor.ReduceDamage(damage, ammo);
                Console.WriteLine("Танк " + Name + " получил урон " + damage);
                if (!IsAlive)
                    DeathMessage();
            } else
                Console.WriteLine("Танк увернулся от попадания");
        }

        public void DeathMessage()
        {
            Console.WriteLine("Танк " + Name + " уничтожен");
        }

        public void RecieveAmmo()
        {
            WhereHouse inventory = new();
            inventory.GiveAmmo(this, Ammunition, (MaxAmmo - CurrentAmmo));
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
