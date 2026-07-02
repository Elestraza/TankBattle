using System;
using System.Collections;
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
            DamageCalculations damageCalculations = new();
            Int32 roundCounter = 1;
            Console.WriteLine("____________________БОЙ___________________");
            while (aliveTeams.Teams.Count > 1)
            {
                DamageHolder damageHolder = new();
                List<DamageHolder> damageList = new();
                List<Team> atackingTeam = new List<Team>();

                Console.WriteLine($"___________________Ход {roundCounter}__________________");
                foreach (Team team in aliveTeams.Teams)
                {
                    var enemies = aliveTeams.Teams.Where(t => t != team).SelectMany(t => t.Tanks).ToList(); // список врагов

                    //Console.WriteLine($"__________Ход команды {team.Name} _________");
                    foreach (Tank tank in team.Tanks.Where(t => t.IsAlive))
                    {
                        var index = team.Tanks.IndexOf(tank);
                        damageHolder = damageCalculations.Attack(tank, enemies, team);
                        if (damageHolder != null)
                            damageList.Add(damageHolder);
                    }

                }
                Console.WriteLine("___________________УРОН___________________");

                damageCalculations.ApplyDamage(damageList);
                aliveTeams.Teams.RemoveAll(t => t.IsDefeated);
                roundCounter++;
            }
            Console.WriteLine(GameOver(aliveTeams.Teams));
        }
    }
}
