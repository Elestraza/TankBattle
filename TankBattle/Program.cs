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

        AutoWeapon autoWeapon = new();
        RifledWeapon rifledWeapon = new();
        SmoothBarrelWeapon smoothBarrelWeapon = new();

        ArmorPearcing armorPearcing = new();
        Cumulative cumulative = new();
        HighExplosive highExplosive = new();

        CompositeArmor compositeArmor = new();
        DinamicArmor dinamicArmor = new();
        RolledHomogeneous homogeneous = new();

        HeavyTank heavyTank = new();
        MediumTank mediumTank = new();
        LightTank lightTank = new();

        List<Tank> tanks = [heavyTank, mediumTank, lightTank];
        List<Weapon> weapons = [autoWeapon, rifledWeapon, smoothBarrelWeapon];
        List<Ammo> ammo = [armorPearcing, cumulative, highExplosive];
        List<Armor> armors = [compositeArmor, dinamicArmor, homogeneous];

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