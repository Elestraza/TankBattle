using TankBattle.Classes;

namespace TankBattle.Weapons
{
    class SmoothBarrelWeapon : Weapon // Гладкоствольное оружие 
    {
        public override (int, Double) Shoot(Tank tank, Ammo ammo, Double Accuracy)
        {

            return ((Random.Shared.Next(35, 46) + ammo.Damage), Accuracy);
        }

        public override bool CanUse(Ammo ammo)
        {
            return true;
        }
    }
}
