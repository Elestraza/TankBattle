using System;
using System.Collections.Generic;
using System.Text;

namespace TankBattle.Classes
{
    abstract class Tactic
    {
        //public abstract Tank SelectTarget(Tank attacker, List<Tank> enemies, Team friendlyTeam);
        public abstract void SelectTarget(Tank attacker, List<Tank> enemies);
        /*
            Приказ командира - все атакуют цель, которую указал командир команды (меняется каждый ход);
            Охота на лидера - атакуют самый сильный (с максимальным HP) танк;
            Добивание - атакуют самый слабый (с минимальным HP) танк;
            Концентрация - все атакуют одного противника, пока он не уничтожен, затем переключаются на следующего (случайный выбор первого);
            По приоритету типов - каждый тип атакует определенного противника:
	            Тяжелый -> средний,
	            Средний -> легкий,
	            Легкий -> случайная цель;
         */
    }
}
