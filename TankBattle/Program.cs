using TankBattle.Ammunitions;
using TankBattle.Armors;
using TankBattle.Classes;
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
        Random tactIndex = new(tacticsList.Count);
        Tactic[] arrayedTactics = tacticsList.ToArray();
        Tactic randomTactic = arrayedTactics[tactIndex.Next(0, arrayedTactics.Length)];
        for (int i = 0; i < team.Tanks.Count; i++) // Тестовый выбор тактики, в будущем будет изменен
        {
            team.Tanks[i].Strategy = randomTactic;
        }

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
        Team team1 = new()
        {
            Name = "Blue"
        };
        Team team2 = new()
        {
            Name = "Red"
        };


        HeavyTank heavyTank = new();
        MediumTank mediumTank = new();
        LightTank lightTank = new();

        List<Tank> tanksList = [heavyTank, mediumTank, lightTank];
        GetTeam(tanksList, team1, team2);

        WhereHouse whereHouse = new();
        GearRandomizer(whereHouse.Weapons, whereHouse.Ammos, whereHouse.Armors, whereHouse.Tactics, team1);
        GearRandomizer(whereHouse.Weapons, whereHouse.Ammos, whereHouse.Armors, whereHouse.Tactics, team2);
        /*team1.Tanks[0].Name = "Игрок 1";
        team1.Tanks[0].Strategy = heathiestEnemyTactic;
        team1.Tanks[0].Weapons = sbw;
        team1.Tanks[0].Armor = dinamicArmor;
        team1.Tanks[0].RecieveAmmo();

        team2.Tanks[0].Name = "Игрок 2";
        team2.Tanks[0].Strategy = heathiestEnemyTactic;
        team2.Tanks[0].Weapons = sbw;
        team2.Tanks[0].Armor = rolledHomogeneous;
        team2.Tanks[0].RecieveAmmo();
        */

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
                tank.Attack(team2.Tanks);
            }
            foreach (Tank tank in team2.Tanks.Where(t => t.IsAlive))
            {
                Console.Write(team2.Name + " ");
                tank.Attack(team1.Tanks);
            }
            Console.WriteLine();
        }
    }
}