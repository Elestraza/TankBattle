using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using TankBattle.Classes;

namespace TankBattle.DamageCalculation
{
    class DamageCalculations
    {

        /*
        public void Attack(Tactic strategy, List<Tank> enemies)
        {
            if (Tank.Ammunition.Count > 0)
            {
                CurrentAmmo--;
                strategy.SelectTarget(this, enemies);
            } else
            {
                Console.WriteLine("У Танка " + Name + " кончились снаряды.");
                RecieveAmmo();
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
        */
    }
}
