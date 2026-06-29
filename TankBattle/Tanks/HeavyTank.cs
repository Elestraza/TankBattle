
using TankBattle.Classes;

namespace TankBattle.Tanks
{
    abstract class HeavyTank : Tank
    {
        public HeavyTank()
        {
            MaxHP = 700;
            HP = 700;
            DodgeChance = 0f;
        }
    }
}
