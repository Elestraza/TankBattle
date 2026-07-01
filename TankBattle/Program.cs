using TankBattle.Ammunitions;
using TankBattle.Armors;
using TankBattle.Classes;
using TankBattle.GameMaster;
using TankBattle.Tactics;
using TankBattle.Tanks;
using TankBattle.Weapons;
using Windows.Gaming.UI;
using System.Linq;

/*
    TODO: 
        Создать возможность одновременной игры более чем двумя командами
        Перенести логику в BattleSimulator.cs
        Null DamageHolder внутри DamageList
*/

internal class Program
{
    public static Int32 roundCounter = 1;
    public static Int32 maxRounds = 100;

    private static String GameOver(List<Team> aliveTeams)
    {
        if (aliveTeams.Count > 0 && roundCounter == maxRounds)
        {
            return "НИЧЬЯ ПО ОКОНЧАНИЮ ИГРОВОЙ СЕССИИ!";
        }
        else
        {
            return "ПОБЕДИЛА КОМАНДА " + aliveTeams.First().Name;
        }
    }
    private static void Main()
    {
        WhereHouse whereHouse = new();

        DamageCalculations damageCalculations = new();
       
        TeamCreator teamCreator = new();

        HeavyTank heavyTank = new();
        MediumTank mediumTank = new();
        LightTank lightTank = new();

        List<Tank> tanksList = [heavyTank, mediumTank, lightTank];
        AliveTeams teamsList = new();
        Int32 teamCapasity = Random.Shared.Next(1, 6);
        Int32 teamQuantity = Convert.ToInt32(Console.ReadLine());
        teamCreator.GetTeam(tanksList, teamCapasity, teamsList.Teams, teamQuantity);
        teamCreator.GearRandomizer(whereHouse.Weapons, whereHouse.Ammos, whereHouse.Armors, teamsList.Teams);

        foreach (Team team in teamsList.Teams)
        {
            Console.WriteLine("Команда " + team.Name);
            foreach (Tank tank in team.Tanks.Where(t => t.IsAlive))
            {
                Console.WriteLine(tank.Name + " - " + tank.TankType);
            }
        }

        Console.WriteLine("____________________БОЙ___________________");
        List<Team> aliveTeams = new();
        aliveTeams.AddRange(from team in teamsList.Teams.Where(t => !t.IsDefeated)
                            select team);
        while (aliveTeams.Count > 0 && roundCounter < maxRounds)
        {
            DamageHolder damageHolder = new DamageHolder();
            List<DamageHolder> damageList = new List<DamageHolder>();
            Console.WriteLine("___________________Ход " + roundCounter + "__________________");
            foreach (Team team in teamsList.Teams)
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
            Console.WriteLine("__________________________________________");
            roundCounter++;
        }
        Console.WriteLine(GameOver(aliveTeams));
    }
}