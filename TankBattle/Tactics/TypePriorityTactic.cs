using System;
using System.Collections.Generic;
using System.Text;
using TankBattle.Classes;
using TankBattle.Tanks;

namespace TankBattle.Tactics
{
    class TypePriorityTactic : Tactic
    {
        /*
         По приоритету типов - каждый тип атакует определенного противника:
	        Тяжелый -> средний
	        Средний -> легкий
	        Легкий -> случайная цель
         */
        public override void SelectTarget(Tank attacker, List<Tank> enemies)
        {
            int damage = attacker.Weapons.Shoot(attacker.Ammunition[0], attacker.Weapons.Accuracy);
            if (attacker is HeavyTank)
            {
                var selectedTank = enemies.Where(t => t is MediumTank).First();
                selectedTank.HitRegister(damage, attacker.Ammunition[0]);
                Console.WriteLine("Танк " + attacker.Name + " атакует Танк " + selectedTank.Name);
            }
            if (attacker is MediumTank)
            {
                var selectedTank = enemies.Where(t => t is LightTank).First();
                selectedTank.HitRegister(damage, attacker.Ammunition[0]);
                Console.WriteLine("Танк " + attacker.Name + " атакует Танк " + selectedTank.Name);
            }
            // if attacker is LightTank
            Random index = new(enemies.Count);

            Tank[] aliveEnemies = enemies.Where(t => t.IsAlive && t.IsTarget == false).ToArray();
            Tank randomTank = aliveEnemies[index.Next(0, aliveEnemies.Length)];
            randomTank.HitRegister(damage, attacker.Ammunition[0]);
            Console.WriteLine("Танк " + attacker.Name + " атакует Танк " + randomTank.Name);
        }
    }
}
