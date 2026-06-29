using TankBattle.Ammunitions;
using TankBattle.Armors;
using TankBattle.Classes;
using TankBattle.Tanks;
using TankBattle.Weapons;


/*
 
    TODO: Рандомайзер снаряжения и "игру"
 
 */



internal class Program
{
    private static void Main(string[] args)
    {
        Team team1 = new Team();
        team1.Name = "Blue";
        Team team2 = new Team();
        team2.Name = "Red";


        while (!team1.IsDefeated && !team2.IsDefeated)
        {
            foreach (Tank tank in team1.Tanks.Where(t => t.IsAlive))
            {
                tank.Attack(team2.Tanks);
            }
            foreach (Tank tank in team2.Tanks.Where(t => t.IsAlive))
            {
                tank.Attack(team1.Tanks);
            }
        }
    }
}