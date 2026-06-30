using System;
using System.Collections.Generic;
using System.Text;
using TankBattle.Classes;

namespace TankBattle.Tactics
{
    class CaptainOrderTactic : Tactic
    {
        public override void SelectTarget(Tank attacker, List<Tank> enemies)
        {
            Random index = new(enemies.Count);

            Tank[] aliveEnemies = enemies.Where(t => t.IsAlive).ToArray();
            Tank randomTank = aliveEnemies[index.Next(0, aliveEnemies.Length)];
            
            int damage = attacker.Weapons.Shoot(attacker.Ammunition[0], attacker.Weapons.Accuracy);
            randomTank.HitRegister(damage, attacker.Ammunition[0]);
            Console.WriteLine("Танк " + attacker.Name + " атакует Танк " + randomTank.Name);
        }
    }
}
