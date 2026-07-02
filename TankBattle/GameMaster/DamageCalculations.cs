using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using TankBattle.Classes;

namespace TankBattle.GameMaster
{
    class DamageCalculations
    {
        public void ApplyDamage(List<DamageHolder> damageList)
        {
            if (damageList == null)
                return;

            foreach (var damage in damageList)
            {
                if (damage?.Reciever == null)
                    continue;   // skip invalid entries

                if (!damage.Reciever.IsAlive || damage.RecievingDamage == 0)
                {
                    damage.Reciever.HitRegister(0);
                } else
                {
                    Double reducedDamage = damage.Reciever.Armor.ReduceDamage(damage.RecievingDamage, damage.AttackerAmmo);
                    damage.Reciever.HitRegister(reducedDamage);
                }
            }
        }

        public DamageHolder Attack(Tank attacker, List<Tank> enemies, Team team)
        {
            if (attacker.Ammunition.Count == 0)
            {
                Console.WriteLine($"У {attacker.Name} кончились снаряды.");
                attacker.RecieveAmmo();
                return null;
            }

            Tank target = team.Strategy.SelectTarget(attacker, enemies);
            if (target == null)
            {
                Console.WriteLine($"{attacker.Name} не может выбрать цель.");
                return null;
            }

            Ammo usedAmmo = attacker.Ammunition.First();
            Double damage = attacker.Weapons.Shoot(attacker, attacker.Weapons.Accuracy);

            return new DamageHolder
            {
                Reciever = target,
                Attacker = attacker,
                AttackerAmmo = usedAmmo,
                RecievingDamage = damage
            };
        }
    }
}