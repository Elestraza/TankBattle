using TankBattle.Classes;
using System.Linq;

namespace TankBattle.Tactics
{
    class WeakestEnemyTactic : Tactic
    {
        public override Tank SelectTarget(Tank attacker, List<Tank> enemies)
        {
            var enemy = enemies.Where(t => t.IsAlive).OrderBy(t => t.HP).Last();
            Console.WriteLine("Танк " + attacker.Name + " атакует Танк " + enemy);
            return enemy;
        }
    }
}
