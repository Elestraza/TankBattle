using TankBattle.Classes;
using TankBattle.Ammunitions;

namespace TankBattle.Weapons
{
    class RifledWeapon : Weapon // Нарезное оружие
    {
        public RifledWeapon()
        {
            ReloadTime = 0;
        }

        public override int Shoot(Ammo ammo, Double Accuracy)
        {
            if (Random.Shared.NextDouble() > Accuracy)
                Console.WriteLine("Промазал");
            return Random.Shared.Next(20, 31) + ammo.Damage;
        }

        public override bool CanUse(Ammo ammo)
        {
            return true;
        }
    }
}
