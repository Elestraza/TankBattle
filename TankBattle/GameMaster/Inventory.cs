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

        public Weapon GetRandomWeapon()
        {
            Type weaponType = Weapons[Random.Shared.Next(Weapons.Count)].GetType();
            return (Weapon)Activator.CreateInstance(weaponType);
        }

        public Armor GetRandomArmor()
        {
            Type armorType = Armors[Random.Shared.Next(Armors.Count)].GetType();
            return (Armor)Activator.CreateInstance(armorType);
        }

        public Ammo GetRandomAmmo()
        {
            Type ammoType = Ammos[Random.Shared.Next(Ammos.Count)].GetType();
            return (Ammo)Activator.CreateInstance(ammoType);
        }

        public Tactic GetRandomTactic()
        {
            Type tacticType = Tactics[Random.Shared.Next(Tactics.Count)].GetType();
            return (Tactic)Activator.CreateInstance(tacticType);
        }

        public String GetRandomTeamName()
        {
            if (TeamNames.Count == 0)
                return "Команда " + Random.Shared.Next(100, 999);

            int index = Random.Shared.Next(TeamNames.Count);
            String name = TeamNames[index];
            TeamNames.RemoveAt(index);
            return name;
        }

        public Int32 GiveAmmo(Tank receiver, List<Ammo> availableAmmo, Int32 quantity)
        {
            if (availableAmmo == null || availableAmmo.Count == 0)
            {
                Console.WriteLine("Нет доступных боеприпасов.");
                return 0;
            }

            Int32 added = 0;
            for (Int32 i = 0; i < quantity; i++)
            {
                if (receiver.Weight >= receiver.MaxWeight)
                    break;   // больше места нет

                Ammo chosen = availableAmmo[Random.Shared.Next(availableAmmo.Count)];
                receiver.Ammunition.Add(chosen);
                receiver.Weight += chosen.AmmoWeight;
                added++;
            }
            return added;
        }
    }
}
