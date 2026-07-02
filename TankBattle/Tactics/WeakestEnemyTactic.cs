using System.Linq;
using TankBattle.Classes;
using static System.Net.Mime.MediaTypeNames;

namespace TankBattle.Tactics
{
    class WeakestEnemyTactic : Tactic
    {
        public override Tank SelectTarget(Tank attacker, List<Tank> enemies)
        {
            var enemy = enemies.Where(t => t.IsAlive).OrderBy(t => t.HP).First();
            Console.WriteLine($"{attacker.Name} атакует {enemy.Name}");
            return enemy;
        }
    }
}
