using System;
using System.Collections.Generic;
using System.Text;
using TankBattle.Ammunitions;
using TankBattle.Armors;
using TankBattle.Classes;
using TankBattle.Tanks;
using TankBattle.Weapons;

namespace TankBattle.Inventory
{
    class WhereHouse
    {
        public AutoWeapon autoWeapon { get; set; } = new();
        public RifledWeapon rifledWeapon { get; set; } = new();
        public SmoothBarrelWeapon smoothBarrelWeapon { get; set; } = new();

        public ArmorPearcing armorPearcing { get; set; } = new();
        public Cumulative cumulative { get; set; } = new();
        public HighExplosive highExplosive { get; set; } = new();

        public CompositeArmor compositeArmor { get; set; } = new();
        public DinamicArmor dinamicArmor { get; set; } = new();
        public RolledHomogeneous homogeneous { get; set; } = new();

        public List<Weapon> Weapons { get; set; } = new(); // [autoWeapon, rifledWeapon, smoothBarrelWeapon];
        public List<Ammo> Ammos { get; set; } = new(); // [armorPearcing, cumulative, highExplosive];
        public List<Armor> Armors { get; set; } =  new(); // [compositeArmor, dinamicArmor, homogeneous];

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
                Random index = new(ammos.Count);

                Ammo[] aliveEnemies = ammos.ToArray();
                Ammo selectedAmmo = aliveEnemies[index.Next(0, aliveEnemies.Length)];
                reciever.Ammunition.Add(selectedAmmo);
                reciever.CurrentAmmo++;
            }
        }
    }
}
