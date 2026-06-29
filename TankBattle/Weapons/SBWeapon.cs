using TankBattle.Classes;

namespace TankBattle.Weapons
{
    class SBWeapon : Weapon // Гладкоствольное оружие 
    {
        public override int Shoot(Ammo ammo)
        {
            return Random.Shared.Next(35, 46) + ammo.Damage;
        }

        public override bool CanUse(Ammo ammo)
        {
            return true;
        }
    }
}
