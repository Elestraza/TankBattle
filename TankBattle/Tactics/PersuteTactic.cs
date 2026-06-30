using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using TankBattle.Classes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TankBattle.Tactics
{
    class PersuteTactic : Tactic
    {
        public override Tank SelectTarget(Tank attacker, List<Tank> enemies)
        {
            int targetId = 0;
            foreach (Tank tank in enemies.Where(t => t.IsAlive == true))
            {
                if (tank.IsTarget == false)
                    targetId++;
            }
            if (targetId == 0)
            {
                Random index = new Random(enemies.Count());

                Tank[] aliveEnemies = enemies.Where(t => t.IsAlive == true && t.IsTarget == false).ToArray();
                Tank selectedTank = aliveEnemies[index.Next(0, aliveEnemies.Length)];
                selectedTank.IsTarget = true;
                return selectedTank;
            }
            return enemies.Where(t => t.IsTarget == true && t.IsAlive == true).First();
        }
    }
}
