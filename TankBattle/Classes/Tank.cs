using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml.Linq;
using TankBattle.GameMaster;
using static System.Net.Mime.MediaTypeNames;

namespace TankBattle.Classes
{
    abstract class Tank
    {
        public String Name { get; set; }
        public Int32 MaxHP { get; protected set; }
        public Double HP { get; set; }
        public Int32 MaxWeight { get; protected set; }
        public Int32 Weight { get; set; }
        public float DodgeChance { get; protected set; }
        public String TankType { get; protected set; }
        public Armor Armor { get; set; }
        public Weapon Weapons { get; set; }
        public List<Ammo> Ammunition { get; set; } = new();
        public Int32 MaxAmmo { get; protected set; }
        public Int32 CurrentAmmo { get; set; }

        public Int32 GunsQuantity { get; protected set; }

        public Boolean IsAlive => HP > 0;

        public Boolean IsTarget = false;

        public void HitRegister(Double damage)
        {
            if (!(Random.Shared.NextDouble() < DodgeChance))
            {
                HP -= damage;
                Console.Write(Name + " получил урон " + damage + " | ");
                Console.WriteLine(" HP: " + HP);
                if (!IsAlive)
                    Console.WriteLine(Name + " уничтожен");
                //DeathMessage();
            } else
                Console.WriteLine(Name + " увернулся от попадания");
        }

        public void DeathMessage()
        {
            Console.WriteLine(Name + " уничтожен");
        }

        public void RecieveAmmo()
        {
            WhereHouse inventory = new();
            inventory.GiveAmmo(this, Ammunition, (MaxAmmo - CurrentAmmo));
        }
    }
}
