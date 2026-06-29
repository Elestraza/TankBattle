using TankBattle.Classes;

namespace TankBattle.Weapons
{
    class RWeapon : Weapon // Нарезное оружие
    {
        public RWeapon()
        {
            AccuracyModifier = 0.10f;
        }

        public override int Shoot(Ammo ammo)
        {
            return Random.Shared.Next(20, 31) + ammo.Damage;
        }

        public override bool CanUse(Ammo ammo)
        {
            return true;
        }
    }
}
