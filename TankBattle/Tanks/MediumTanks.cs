
using TankBattle.Classes;

namespace TankBattle.Tanks
{
    abstract class MediumTank : Tank
    {
        public MediumTank()
        {
            MaxHP = 550;
            HP = 550;
            DodgeChance = 0.07f;
        }
    }
}
