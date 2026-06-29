using TankBattle.Ammunitions;
using TankBattle.Armors;
using TankBattle.Classes;
using TankBattle.Tanks;
using TankBattle.Weapons;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");


        RWeapon RWp = new RWeapon();
        LightArmor LArmor = new LightArmor();
        AP aP = new AP();
        LightTank LT = new LightTank(LArmor, RWp, aP);
    }
}