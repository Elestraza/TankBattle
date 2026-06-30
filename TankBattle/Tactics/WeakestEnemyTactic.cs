using System.Linq;
using TankBattle.Classes;
using static System.Net.Mime.MediaTypeNames;

namespace TankBattle.Tactics
{
    class WeakestEnemyTactic : Tactic
    {
        public override void SelectTarget(Tank attacker, List<Tank> enemies)
        {
            int damage = attacker.Weapons.Shoot(attacker.Ammunition[0], attacker.Weapons.Accuracy);
            var enemy = enemies.Where(t => t.IsAlive).OrderBy(t => t.HP).Last();
            Console.WriteLine("Танк " + attacker.Name + " атакует Танк " + enemy.Name);
            enemy.HitRegister(damage, attacker.Ammunition[0]);
        }
    }
}
