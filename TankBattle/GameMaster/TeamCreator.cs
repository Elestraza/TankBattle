using System;
using System.Collections.Generic;
using System.Text;
using TankBattle.Classes;

namespace TankBattle.GameMaster
{
    class TeamCreator
    {
        public void GetTeam(List<Tank> tanksList, Int32 teamCapacity, List<Team> teamsList, Int32 teamQuantity)
        {
            TankFactory tankFactory = new TankFactory();
            List<Tank> availableTanks = new List<Tank>(tanksList);
            for (Int32 i = 0; i < teamQuantity; i++)
            {
                Team team = new Team();
                availableTanks.Shuffle();
                Random random = new Random();
                for (Int32 j = 0; j < teamCapacity && availableTanks.Count > 0; j++)
                {
                    Tank newTank = tankFactory.CreateRandomTank();
                    newTank.Name = "Танк" + (i+1) + "-" + (j+1);
                    team.Tanks.Add(newTank);
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

                teamsList.Add(team);
            }
        }

        public void GearRandomizer(List<Weapon> weaponsList, List<Ammo> ammoesList, List<Armor> armorsList, List<Team> teamsList) // выдача снаряжения
        {
            for (Int32 i = 0; i < teamsList.Count; i++)
            {
                for (Int32 j = 0; j < teamsList[i].Tanks.Count; j++) // Выдача оружия
                {
                    Random index = new(weaponsList.Count);
                    Weapon[] arrayedElements = weaponsList.ToArray();
                    weaponsList.Shuffle();
                    Weapon randomWeapon = arrayedElements[index.Next(0, arrayedElements.Length)];
                    teamsList[i].Tanks[j].Weapons = randomWeapon;
                }
                for (Int32 j = 0; j < teamsList[i].Tanks.Count; j++) // Выдача боеприпасов
                {
                    teamsList[i].Tanks[j].RecieveAmmo();
                }
                for (Int32 j = 0; j < teamsList[i].Tanks.Count; j++) // Выдача брони
                {
                    Random index = new(armorsList.Count);
                    Armor[] arrayedElements = armorsList.ToArray();
                    armorsList.Shuffle();
                    Armor randomArmor = arrayedElements[index.Next(0, arrayedElements.Length)];
                    teamsList[i].Tanks[j].Armor = randomArmor;
                }
            }
        }

    }
}
