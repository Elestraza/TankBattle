using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using TankBattle.Classes;

namespace TankBattle.Tactics
{
    class PursuitTactic : Tactic
    {
        public override Tank SelectTarget(Tank attacker, List<Tank> enemies)
        {
            int damage = attacker.Weapons.Shoot(attacker.Ammunition[0], attacker.Weapons.Accuracy);

            int targetId = 0;
            foreach (Tank tank in enemies.Where(t => t.IsAlive))
            {
                if (tank.IsTarget == false)
                    targetId++;
            }
            if (targetId == 0)
            {
                Random index = new(enemies.Count);

                Tank[] aliveEnemies = enemies.Where(t => t.IsAlive && t.IsTarget == false).ToArray();
                return aliveEnemies[index.Next(0, aliveEnemies.Length)];

                //randomTank.HitRegister(damage, attacker.Ammunition[0]);
            }
            return enemies.Where(t => t.IsTarget && t.IsAlive == true).First();//.HitRegister(damage, attacker.Ammunition[0]);
        }
    }
}
