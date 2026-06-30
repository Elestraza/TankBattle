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
            int damage = attacker.Weapons.Shoot(attacker.Ammunition[0], attacker.Weapons.Accuracy);
            return enemies.Where(t => t.IsAlive).OrderBy(t => t.HP).First();
            //Console.WriteLine("Танк " + attacker.Name + " атакует Танк " + enemy.Name);
            //enemy.HitRegister(damage, attacker.Ammunition[0]);
        }
    }
}
