using System;
using System.Collections.Generic;
using System.Text;
using TankBattle.Classes;

namespace TankBattle.Tactics
{
    class HeathiestEnemyTactic : Tactic
    {
        public override Tank SelectTarget(Tank attacker, List<Tank> enemies)
        {
            var enemy = enemies.Where(t => t.IsAlive).OrderBy(t => t.HP).Last();
            Console.WriteLine($"{attacker.Name} атакует {enemy.Name}");
            return enemy;
        }
    }
}
