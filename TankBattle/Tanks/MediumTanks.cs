
using TankBattle.Classes;

namespace TankBattle.Tanks
{
    class MediumTank : Tank
    {
        public MediumTank()
        {
            TankType = "Средний танк";
            MaxHP = 550;
            HP = 550f;
            DodgeChance = 0.07f;
            MaxWeight = 10000;
            GunsQuantity = 1;
        }   
    }
}
