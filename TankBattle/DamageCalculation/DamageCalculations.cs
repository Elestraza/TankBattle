using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using TankBattle.Classes;

namespace TankBattle.DamageCalculation
{
    class DamageCalculations
    {
        public void Attack(Tank attacker, List<Tank> enemies, Team team)
        {
            
            for (int i = 0; i < attacker.GunsQuantity; i++)
            {
                if (attacker.Ammunition.Count > 0)
                {
                    attacker.CurrentAmmo--;
                    var reciever = team.Strategy.SelectTarget(attacker, enemies);
                    var attackerAmmo = attacker.Ammunition[0];
                    int damage = attacker.Weapons.Shoot(attacker.Ammunition[0], attacker.Weapons.Accuracy);
                    HitRegister(reciever, damage, attacker.Ammunition[0]);
                } else
                {
                    Console.WriteLine("У Танка " + attacker.Name + " кончились снаряды.");
                    attacker.RecieveAmmo();
                }
            }
        }

        public void HitRegister(Tank tank, int damage, Ammo ammo)
        {
            if (!(Random.Shared.NextDouble() < tank.DodgeChance))
            {
                tank.HP -= tank.Armor.ReduceDamage(damage, ammo);
                Console.WriteLine("Танк " + tank.Name + " получил урон " + damage);
                if (!tank.IsAlive)
                    tank.DeathMessage();
            } else
                Console.WriteLine("Танк увернулся от попадания");
        }
    }
}
