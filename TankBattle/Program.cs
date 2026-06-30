using TankBattle.Ammunitions;
using TankBattle.Armors;
using TankBattle.Classes;
using TankBattle.DamageCalculation;
using TankBattle.Inventory;
using TankBattle.Tactics;
using TankBattle.Tanks;
using TankBattle.Weapons;

/*
    TODO: 
        Рандомайзер снаряжения
        Боёвку
        Пополнение патронов
        Переделать тактики (затронет калькуляцию урона)
*/

internal class Program
{
    
    public static void GetTeam(List<Tank> tanksList, Team team1, Team team2) // Создать равные комманды
    {
        int teamCapasity = Random.Shared.Next(1, 6);
        for (int i  = 0; i < teamCapasity; i++)
        {
            Random index = new(tanksList.Count);
            Tank[] aliveEnemies = tanksList.ToArray();
            Tank randomTank = aliveEnemies[index.Next(0, aliveEnemies.Length)];
            randomTank.Name = "Танк" + i;
            team1.Tanks.Add(randomTank);
        }
        for (int i = 0; i < teamCapasity; i++)
        {
            Random index = new(tanksList.Count);
            Tank[] aliveEnemies = tanksList.ToArray();
            Tank randomTank = aliveEnemies[index.Next(0, aliveEnemies.Length)];
            randomTank.Name = "Танк" + i;
            team2.Tanks.Add(randomTank);
        }
    }

    public static void GearRandomizer(List<Weapon> weaponsList, List<Ammo> ammoesList, List<Armor> armorsList, List<Tactic> tacticsList,Team team) // выдача снаряжения
    {
        for (int i = 0; i < team.Tanks.Count; i++) // Выдача оружия
        {
            Random index = new(weaponsList.Count);
            Weapon[] arrayedElements = weaponsList.ToArray();
            Weapon randomWeapon = arrayedElements[index.Next(0, arrayedElements.Length)];
            team.Tanks[i].Weapons = randomWeapon;
        }
        for (int i = 0; i < team.Tanks.Count; i++) // Выдача боеприпасов
        {
            team.Tanks[i].RecieveAmmo();
        }
        for (int i = 0; i < team.Tanks.Count; i++) // Выдача брони
        {
            Random index = new(armorsList.Count);
            Armor[] arrayedElements = armorsList.ToArray();
            Armor randomArmor = arrayedElements[index.Next(0, arrayedElements.Length)];
            team.Tanks[i].Armor = randomArmor;
        }
    }

    private static void Main()
    {
        WhereHouse whereHouse = new();

        DamageCalculations damageCalculations = new();
        Team team1 = new()
        {
            Name = "Blue",
            Strategy = whereHouse.captainOrderTactic
        };
        Team team2 = new()
        {
            Name = "Red",
            Strategy = whereHouse.weakestEnemyTactic
        };


        HeavyTank heavyTank = new();
        MediumTank mediumTank = new();
        LightTank lightTank = new();

        List<Tank> tanksList = [heavyTank, mediumTank, lightTank];
        GetTeam(tanksList, team1, team2);

        
        GearRandomizer(whereHouse.Weapons, whereHouse.Ammos, whereHouse.Armors, whereHouse.Tactics, team1);
        GearRandomizer(whereHouse.Weapons, whereHouse.Ammos, whereHouse.Armors, whereHouse.Tactics, team2);

        Console.WriteLine("Команда " + team1.Name);
        foreach (Tank tank in team1.Tanks.Where(t => t.IsAlive))
        {
            Console.WriteLine(tank.Name);
        }
        Console.WriteLine("Команда " + team2.Name);
        foreach (Tank tank in team2.Tanks.Where(t => t.IsAlive))
        {
            Console.WriteLine(tank.Name);
        }

        Console.WriteLine("_____________________БОЙ_____________________");
        while (!team1.IsDefeated && !team2.IsDefeated)
        { 
            foreach (Tank tank in team1.Tanks.Where(t => t.IsAlive))
            {
                Console.Write(team1.Name + " ");
                damageCalculations.Attack(tank, team2.Tanks, team1);
            }
            foreach (Tank tank in team2.Tanks.Where(t => t.IsAlive))
            {
                Console.Write(team2.Name + " ");
                damageCalculations.Attack(tank, team1.Tanks, team2);
            }
            Console.WriteLine();
        }
    }
}