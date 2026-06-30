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

            if (attacker is HeavyTank)
                return enemies.Where(t => t is MediumTank).First();
            if (attacker is MediumTank)
                return enemies.Where(t => t is LightTank).First();
            
            // if attacker is LightTank
            Random index = new(enemies.Count);

            Tank[] aliveEnemies = enemies.Where(t => t.IsAlive && t.IsTarget == false).ToArray();
            Tank selectedTank = aliveEnemies[index.Next(0, aliveEnemies.Length)];
            selectedTank.IsTarget = true;
            return selectedTank;
        }
    }
}
