using System;
using System.Collections.Generic;
using System.Text;
using TankBattle.Classes;

namespace TankBattle.GameMaster
{
    class BattleSimulator
    {
        private static String GameOver(List<Team> aliveTeams)
        {
            if (aliveTeams == null || aliveTeams.Count == 0)
            {
                return "НИЧЬЯ! Танки всех команд уничтожены!";
            }

            return $"ПОБЕДИЛА КОМАНДА {aliveTeams.First().Name}!";
        }
        public void Game(AliveTeams aliveTeams)
        {
            DamageCalculations damageCalculations = new DamageCalculations();
            Int32 roundCounter = 1;
            while (aliveTeams.Teams.Count > 1)
            {
                DamageHolder damageHolder = new DamageHolder();
                List<DamageHolder> damageList = new List<DamageHolder>();
                Console.WriteLine($"___________________Ход {roundCounter}__________________");
                foreach (Team team in aliveTeams.Teams)
                {
                    foreach (Tank tank in team.Tanks.Where(t => t.IsAlive))
                    {
                        Console.Write($"{team.Name} ");
                        damageHolder = damageCalculations.Attack(tank, team.Tanks, team);
                        if (damageHolder != null)
                            damageList.Add(damageHolder);
                    }

                }
                Console.WriteLine("___________________УРОН___________________");

                damageCalculations.ApplyDamage(damageList);
                aliveTeams.Teams.RemoveAll(t => t.IsDefeated);

                Console.WriteLine("__________________________________________");
                roundCounter++;
            }
            Console.WriteLine(GameOver(aliveTeams.Teams));
        }
    }
}
