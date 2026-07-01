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
            return "ПОБЕДИЛА КОМАНДА " + aliveTeams.First().Name;
        }
        public void Game(AliveTeams aliveTeams)
        {
            DamageCalculations damageCalculations = new DamageCalculations();
            Int32 roundCounter = 1;
            while (aliveTeams.Teams.Count > 0)
            {
                DamageHolder damageHolder = new DamageHolder();
                List<DamageHolder> damageList = new List<DamageHolder>();
                Console.WriteLine("___________________Ход " + roundCounter + "__________________");
                foreach (Team team in aliveTeams.Teams)
                {
                    foreach (Tank tank in team.Tanks.Where(t => t.IsAlive))
                    {
                        Console.Write(team.Name + " ");
                        damageCalculations.Attack(tank, team.Tanks, team, damageHolder);
                        //damageList.Add(damageCalculations.Attack(tank, team1.Tanks, team2));
                    }

                }
                Console.WriteLine("___________________УРОН___________________");
                if (damageHolder != null)
                    damageList.Add(damageHolder);
                damageCalculations.ApplyDamage(damageList);

                //var deadTeam = aliveTeams.Teams.Where(t => t.IsDefeated);
                //aliveTeams.Teams.Remove(deadTeam);
                
                Console.WriteLine("__________________________________________");
                roundCounter++;
            }
            Console.WriteLine(GameOver(aliveTeams.Teams));
        }
    }
}
