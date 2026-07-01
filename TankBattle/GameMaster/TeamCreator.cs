using System;
using System.Collections.Generic;
using System.Text;
using TankBattle.Classes;

namespace TankBattle.GameMaster
{
    class TeamCreator
    {
        public Team GetTeam(List<Tank> tanksList, Int32 teamCapacity, List<Team> teamsList)
        {
            Team team = new Team();

            Random random = new Random();
            Tank[] tanksArray = tanksList.ToArray();

            for (int i = 0; i < teamCapacity; i++)
            {
                tanksArray.Shuffle();
                Tank randomTank = tanksArray[random.Next(tanksArray.Length)];
                randomTank.Name = "Танк" + i;
                team.Tanks.Add(randomTank);
            }

            WhereHouse whereHouse = new WhereHouse();
            Tactic[] tactics = whereHouse.Tactics.ToArray();
            Tactic randomTactic = tactics[random.Next(tactics.Length)];
            team.Strategy = randomTactic;

            String[] names = whereHouse.TeamNames.ToArray();
            names.Shuffle();
            String randomName = names[random.Next(names.Length)];
            whereHouse.TeamNames.Remove(randomName);
            team.Name = randomName;

            return team;
        }

        public void GearRandomizer(List<Weapon> weaponsList, List<Ammo> ammoesList, List<Armor> armorsList, Team team) // выдача снаряжения
        {
            for (Int32 i = 0; i < team.Tanks.Count; i++) // Выдача оружия
            {
                Random index = new(weaponsList.Count);
                Weapon[] arrayedElements = weaponsList.ToArray();
                weaponsList.Shuffle();
                Weapon randomWeapon = arrayedElements[index.Next(0, arrayedElements.Length)];
                team.Tanks[i].Weapons = randomWeapon;
            }
            for (Int32 i = 0; i < team.Tanks.Count; i++) // Выдача боеприпасов
            {
                team.Tanks[i].RecieveAmmo();
            }
            for (Int32 i = 0; i < team.Tanks.Count; i++) // Выдача брони
            {
                Random index = new(armorsList.Count);
                Armor[] arrayedElements = armorsList.ToArray();
                armorsList.Shuffle();
                Armor randomArmor = arrayedElements[index.Next(0, arrayedElements.Length)];
                team.Tanks[i].Armor = randomArmor;
            }
        }

    }
}
