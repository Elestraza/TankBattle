using System;
using System.Collections.Generic;
using System.Text;
using TankBattle.Classes;

namespace TankBattle.Tactics
{
    class CaptainOrderTactic : Tactic
    {
        public override Tank SelectTarget(Tank attacker, List<Tank> enemies)
        {
            Random index = new(enemies.Count);

            Tank[] aliveEnemies = enemies.Where(t => t.IsAlive && t.IsTarget == false).ToArray();
            Tank selectedTank = aliveEnemies[index.Next(0, aliveEnemies.Length)];
            selectedTank.IsTarget = true;
            return selectedTank;
        }
    }
}
