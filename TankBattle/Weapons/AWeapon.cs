using TankBattle.Ammunitions;
using TankBattle.Classes;

namespace TankBattle.Weapons
{
    class AWeapon : Weapon // Автоматическое оружие
    {
        public AWeapon()
        {
            AccuracyModifier = -0.15f;
        }

        public override int Shoot(Ammo ammo)
        {
            int damage = 0;

            for (int i = 0; i < 3; i++)
                damage += Random.Shared.Next(10, 16);

            return damage + ammo.Damage;
        }

        public override bool CanUse(Ammo ammo)
        {
            return ammo is AP || ammo is HEF;
        }

    }
}
