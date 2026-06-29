using TankBattle.Classes;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");


        RWeapons RWp = new RWeapons();
        LightArmor LArmor = new LightArmor();
        AP aP = new AP();
        LightTank LT = new LightTank(LArmor, RWp, aP);
    }
}