using System;
using System.Collections.Generic;
using System.Text;
using TankBattle.Ammunitions;
using TankBattle.Armors;
using TankBattle.Classes;
using TankBattle.Tactics;
using TankBattle.Tanks;
using TankBattle.Weapons;

namespace TankBattle.GameMaster
{
    class WhereHouse
    {
        public List<Weapon> Weapons { get; set; } = new(); // [autoWeapon, rifledWeapon, smoothBarrelWeapon];
        public List<Ammo> Ammos { get; set; } = new(); // [armorPearcing, cumulative, highExplosive];
        public List<Armor> Armors { get; set; } = new(); // [compositeArmor, dinamicArmor, homogeneous];
        public List<Tactic> Tactics { get; set; } = new();
        public List<String> TeamNames { get; set; } = new();
        public WhereHouse() 
        {
            AutoWeapon autoWeapon = new();
            RifledWeapon rifledWeapon = new();
            SmoothBarrelWeapon smoothBarrelWeapon = new();

            ArmorPearcing armorPearcing = new();
            Cumulative cumulative = new();
            HighExplosive highExplosive = new();

            CompositeArmor compositeArmor = new();
            DinamicArmor dinamicArmor = new();
            RolledHomogeneous homogeneous = new();

            CaptainOrderTactic captainOrderTactic = new(); // Тестовый вариант
            HeathiestEnemyTactic heathiestEnemyTactic = new();
            PursuitTactic pursuitTactic = new();
            TypePriorityTactic typePriorityTactic = new();
            WeakestEnemyTactic weakestEnemyTactic = new();
            Tactics = [captainOrderTactic, heathiestEnemyTactic, pursuitTactic, typePriorityTactic, weakestEnemyTactic];

            TeamNames = ["СССР", "США", "Китай", "Япония", "Парагвай", "Британия"];
            Weapons = [autoWeapon, rifledWeapon, smoothBarrelWeapon];
            Ammos = [armorPearcing, cumulative, highExplosive];
            Armors = [compositeArmor, dinamicArmor, homogeneous];
        }

        public void GiveAmmo(Tank reciever, List<Ammo> ammoType, Int32 quantity)
        {
            ArmorPearcing armorPearcing = new();
            Cumulative cumulative = new();
            HighExplosive highExplosive = new();
            List<Ammo> ammos = [armorPearcing, cumulative, highExplosive];

            for (int i = 0; i < quantity; i++)
            {
                if (reciever.Weight < reciever.MaxWeight)
                {
                    Random index = new(ammos.Count);

                    Ammo[] aliveEnemies = ammos.ToArray();
                    Ammo selectedAmmo = aliveEnemies[index.Next(0, aliveEnemies.Length)];
                    reciever.Ammunition.Add(selectedAmmo);
                    reciever.Weight += selectedAmmo.AmmoWeight;
                } else
                {
                    Console.WriteLine("Превышенна допустимая масса танка.");
                    break;
                }
            }
        }
    }
}
