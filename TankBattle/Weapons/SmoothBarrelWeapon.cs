using TankBattle.Classes;
using TankBattle.Ammunitions;

namespace TankBattle.Weapons
{
    class SmoothBarrelWeapon : Weapon // Гладкоствольное оружие 
    {
        public override int Shoot(Tank attacker, Double Accuracy)
        {
            if (Random.Shared.NextDouble() > Accuracy)
            {
                Console.WriteLine("Промазал");
                return 0;
            }
            return Random.Shared.Next(35, 46) + attacker.Ammunition[0].Damage;
        }

        public override bool CanUse(Ammo ammo)
        {
            return true;
        }
    }
}
