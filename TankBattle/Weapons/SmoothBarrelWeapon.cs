using TankBattle.Classes;
using TankBattle.Ammunitions;

namespace TankBattle.Weapons
{
    class SmoothBarrelWeapon : Weapon // Гладкоствольное оружие 
    {
        public SmoothBarrelWeapon() 
        {
            ReloadTime = 0;
        }

        public override int Shoot(Ammo ammo, Double Accuracy)
        {

            return Random.Shared.Next(35, 46) + ammo.Damage;
        }

        public override bool CanUse(Ammo ammo)
        {
            return true;
        }
    }
}
