
using TankBattle.Classes;

namespace TankBattle.Tanks
{
    abstract class LightTank : Tank
    {
        public LightTank()
        {
            MaxHP = 400;
            HP = 400;
            DodgeChance = 0.15f;
        }
    }
}
