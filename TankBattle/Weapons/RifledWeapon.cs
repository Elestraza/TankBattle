using TankBattle.Classes;
using TankBattle.Ammunitions;

namespace TankBattle.Weapons
{
    class RifledWeapon : Weapon // Нарезное оружие
    {
        public override Double Accuracy => base.Accuracy + (base.Accuracy * 0.10f);

        public override int Shoot(Tank attacker, Double Accuracy)
        {
            if (Random.Shared.NextDouble() > Accuracy)
            { 
                Console.WriteLine("Промазал");
                return 0;
            }
            return Random.Shared.Next(20, 31) + attacker.Ammunition[0].Damage;
        }

        public override bool CanUse(Ammo ammo)
        {
            return true;
        }
    }
}
