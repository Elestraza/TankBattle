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

                for (Int32 j = 0; j < teamCapacity && availableTanks.Count > 0; j++)
                {
                    Tank newTank = tankFactory.CreateRandomTank();
                    newTank.Name = "Танк" + (i+1) + "-" + (j+1);
                    team.Tanks.Add(newTank);
                }

                WhereHouse whereHouse = new WhereHouse();

                team.Strategy = whereHouse.GetRandomTactic();
                team.Name = whereHouse.GetRandomTeamName();

                teamsList.Add(team);
            }
        }

        public void GearRandomizer(List<Weapon> weaponsList, List<Ammo> ammoesList, List<Armor> armorsList, List<Team> teamsList) // выдача снаряжения
        {
            WhereHouse whereHouse = new WhereHouse();
            for (Int32 i = 0; i < teamsList.Count; i++)
            {
                for (Int32 j = 0; j < teamsList[i].Tanks.Count; j++) // Выдача оружия
                {
                    teamsList[i].Tanks[j].Weapons = whereHouse.GetRandomWeapon();
                }
                for (Int32 j = 0; j < teamsList[i].Tanks.Count; j++) // Выдача боеприпасов
                {
                    teamsList[i].Tanks[j].RecieveAmmo();
                }
                for (Int32 j = 0; j < teamsList[i].Tanks.Count; j++) // Выдача брони
                {
                    teamsList[i].Tanks[j].Armor = whereHouse.GetRandomArmor();
                }
            }
        }

    }
}
