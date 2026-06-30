
using TankBattle.Classes;

namespace TankBattle.Tanks
{
    abstract class HeavyTank : Tank
    {
        public HeavyTank()
        {
            Name = "Тяжелый танк";
            MaxHP = 700;
            HP = 700;
            DodgeChance = 0f;
        }
    }
}
