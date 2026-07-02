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

            int targetId = 0;
            foreach (Tank tank in enemies.Where(t => t.IsAlive))
            {
                if (tank.IsTarget == false)
                    targetId++;
            }
            if (targetId > 0)
            {
                Tank[] aliveEnemies = enemies.Where(t => t.IsAlive && t.IsTarget == false).ToArray();
                var randomEnemyFlag = aliveEnemies[0];
                randomEnemyFlag.IsTarget = true;
                return randomEnemyFlag;

            }
            var enemy = enemies.Where(t => t.IsTarget && t.IsAlive == true).First();
            Console.WriteLine($"{attacker.Name} атакует {enemy.Name}");
            return enemy; 
        }
    }
}
