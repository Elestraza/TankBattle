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
    private static void Main()
    {
        BattleSimulator battleSimulator = new BattleSimulator();
        WhereHouse whereHouse = new();

        DamageCalculations damageCalculations = new();
       
        TeamCreator teamCreator = new();

        HeavyTank heavyTank = new();
        MediumTank mediumTank = new();
        LightTank lightTank = new();

        List<Tank> tanksList = [heavyTank, mediumTank, lightTank];
        List<Team> teamsList = new();
        Int32 teamCapasity = Random.Shared.Next(1, 6);
        Int32 teamQuantity = Convert.ToInt32(Console.ReadLine());
        teamCreator.GetTeam(tanksList, teamCapasity, teamsList, teamQuantity);
        teamCreator.GearRandomizer(whereHouse.Weapons, whereHouse.Ammos, whereHouse.Armors, teamsList);

        foreach (Team team in teamsList)
        {
            Console.WriteLine("Команда " + team.Name);
            foreach (Tank tank in team.Tanks.Where(t => t.IsAlive))
            {
                Console.WriteLine(tank.Name + " - " + tank.TankType);
            }
        }

        Console.WriteLine("____________________БОЙ___________________");
        AliveTeams aliveTeams = new AliveTeams();
        aliveTeams.Teams.AddRange(from team in teamsList.Where(t => !t.IsDefeated)
                            select team);
        Console.WriteLine(aliveTeams.Teams);
        battleSimulator.Game(aliveTeams);
    }
}