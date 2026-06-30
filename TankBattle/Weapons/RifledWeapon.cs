using TankBattle.Classes;

namespace TankBattle.Weapons
{
    class RifledWeapon : Weapon // Нарезное оружие
    {
        //public RifledWeapon()
        //{
        //    Accuracy = Accuracy;
        //}

        public override (int, Double) Shoot(Tank tank, Ammo ammo, Double Accuracy)
        {
            if (Random.Shared.NextDouble() > Accuracy)
                Console.WriteLine("Промазал");
            return ((Random.Shared.Next(20, 31) + ammo.Damage), Accuracy);
        }

        public override bool CanUse(Ammo ammo)
        {
            return true;
        }
    }
}
