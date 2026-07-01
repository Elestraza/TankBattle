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
                Random index = new(enemies.Count);

                Tank[] aliveEnemies = enemies.Where(t => t.IsAlive && t.IsTarget == false).ToArray();
                return aliveEnemies[index.Next(0, aliveEnemies.Length)];

            }
            var enemy = enemies.Where(t => t.IsTarget && t.IsAlive == true).First();
            Console.WriteLine($"{attacker.Name} атакует Танк {enemy.Name}");
            return enemy; 
        }
    }
}
