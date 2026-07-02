using System.Linq;
using System.Text;
using TankBattle.Ammunitions;
using TankBattle.Armors;
using TankBattle.Classes;
using TankBattle.GameMaster;
using TankBattle.Tactics;
using TankBattle.Tanks;
using TankBattle.Weapons;

/*
    TODO: 
        Танк атакует сам себя и союзников: 
            (Танк  1 - 1 атакует Танк Танк  1 - 1)
*/

internal class Program
{
    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8; // Использование UTF8, т.к. не на всех машинах она используется в терминале по умолчанию (Пример: у меня на домашней машине)
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
        Int32 teamQuantity;

        do
        {
            Console.Write("Введите количество команд (от 2 до 6): ");
            if (!Int32.TryParse(Console.ReadLine(), out teamQuantity))
            {
                Console.WriteLine("Ошибка: введите число.");
                continue;
            }

            if (teamQuantity < 2 || teamQuantity > 6)
            {
                Console.WriteLine("Ошибка: количество команд должно быть от 2 до 6.");
            }
        } while (teamQuantity < 2 || teamQuantity > 6);

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

        
        AliveTeams aliveTeams = new AliveTeams();
        aliveTeams.Teams.AddRange(teamsList.Where(t => !t.IsDefeated));
        //Console.WriteLine(aliveTeams.Teams);
        battleSimulator.Game(aliveTeams);
    }
}