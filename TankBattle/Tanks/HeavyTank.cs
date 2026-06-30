
using TankBattle.Classes;

namespace TankBattle.Tanks
{
    class HeavyTank : Tank
    {
        public HeavyTank()
        {
            Name = "Тяжелый танк";
            MaxHP = 700;
            HP = 700;
            DodgeChance = 0f;
            MaxWeight = 15000;
            MaxAmmo = Random.Shared.Next(16, 31);
            CurrentAmmo = 0;
        }
        
    }
}
