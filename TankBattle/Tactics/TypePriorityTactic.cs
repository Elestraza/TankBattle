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
        public override Tank SelectTarget(Tank attacker, List<Tank> enemies)
        {
            //int damage = attacker.Weapons.Shoot(attacker, attacker.Weapons.Accuracy);
            if (attacker is HeavyTank)
            {
                try
                {
                    var enemy = enemies.Where(t => t.IsAlive && t is MediumTank).First();
                    Console.WriteLine(attacker.Name + " атакует Танк " + enemy.Name);
                    return enemy;
                }
                catch 
                {
                    Console.WriteLine(attacker.Name + " не нашел цель.");
                }
            }
            if (attacker is MediumTank)
            {
                try
                {
                    var enemy = enemies.Where(t => t.IsAlive && t is LightTank).First();
                    Console.WriteLine(attacker.Name + " атакует Танк " + enemy.Name);
                    return enemy;
                }
                catch 
                {
                    Console.WriteLine(attacker.Name + " не нашел цель.");
                }
            }

            Random index = new(enemies.Count);
            Tank[] aliveEnemies = enemies.Where(t => t.IsAlive).ToArray();
            var rndEnemy = aliveEnemies[index.Next(0, aliveEnemies.Length)];
            Console.WriteLine(attacker.Name + " атакует Танк " + rndEnemy.Name);
            return rndEnemy;
        }
    }
}
