using TankBattle.Ammunitions;
using TankBattle.Armors;
using TankBattle.Classes;
using TankBattle.GameMaster;
using TankBattle.Tactics;
using TankBattle.Tanks;
using TankBattle.Weapons;
using Windows.Gaming.UI;

/*
    TODO: 
        Создать возможность одновременной игры более чем двумя командами
        Перенести логику в BattleSimulator.cs
        Изменить MaxAmmo в наследуемых классах Tank
        Null DamageHolder внутри DamageList
*/

internal class Program
{
    public static Int32 roundCounter = 1;
    public static Int32 maxRounds = 100;

    private static String GameOver(Team team1, Team team2)
    {
        if (!team1.IsDefeated && !team2.IsDefeated && roundCounter == maxRounds)
        {
            return "НИЧЬЯ ПО ОКОНЧАНИЮ ИГРОВОЙ СЕССИИ!";
        }
        if (team1.IsDefeated)
        {
            return "ПОБЕДИЛА КОМАНДА " + team2.Name;
        }
        if (!team2.IsDefeated)
        {
            return "ПОБЕДИЛА КОМАНДА " + team1.Name;
        }
        else
        {
            return "НИЧЬЯ! ТАНКИ ОБОИХ КОМАНД БЫЛИ УНИЧТОЖЕНЫ!";
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
        List<Team> teamsList = new();
        Int32 teamCapasity = Random.Shared.Next(1, 6);
        var team1 = teamCreator.GetTeam(tanksList, teamCapasity, teamsList);
        var team2 = teamCreator.GetTeam(tanksList, teamCapasity, teamsList);
        teamCreator.GearRandomizer(whereHouse.Weapons, whereHouse.Ammos, whereHouse.Armors, team1);
        teamCreator.GearRandomizer(whereHouse.Weapons, whereHouse.Ammos, whereHouse.Armors, team2);
 
        //team1.Strategy = whereHouse.Tactics[0];
        //team2.Strategy = whereHouse.Tactics[0];
        Console.WriteLine("Команда " + team1.Name);
        foreach (Tank tank in team1.Tanks.Where(t => t.IsAlive))
        {
            Console.WriteLine(tank.Name + " - " + tank.TankType);
        }
        Console.WriteLine("Команда " + team2.Name);
        foreach (Tank tank in team2.Tanks.Where(t => t.IsAlive))
        {
            Console.WriteLine(tank.Name + " - " + tank.TankType);
        }

        Console.WriteLine("____________________БОЙ___________________");
        
        while (!team1.IsDefeated && !team2.IsDefeated && roundCounter < maxRounds)
        {
            DamageHolder damageHolder = new DamageHolder();
            List<DamageHolder> damageList = new List<DamageHolder>();
            Console.WriteLine("___________________Ход " + roundCounter + "__________________");
            foreach (Tank tank in team1.Tanks.Where(t => t.IsAlive))
            {
                Console.Write(team1.Name + " ");
                damageCalculations.Attack(tank, team1.Tanks, team2, damageHolder);
                //damageList.Add(damageCalculations.Attack(tank, team2.Tanks, team1));
                
            }
            foreach (Tank tank in team2.Tanks.Where(t => t.IsAlive))
            {
                Console.Write(team2.Name + " ");
                damageCalculations.Attack(tank, team1.Tanks, team2, damageHolder);
                //damageList.Add(damageCalculations.Attack(tank, team1.Tanks, team2));
            }
            Console.WriteLine("___________________УРОН___________________");
            damageList.Add(damageHolder);
            damageCalculations.ApplyDamage(damageList);
            Console.WriteLine("__________________________________________");
            roundCounter++;
        }
        Console.WriteLine(GameOver(team1, team2));
    }
}