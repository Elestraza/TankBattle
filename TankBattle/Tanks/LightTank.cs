
using TankBattle.Classes;

namespace TankBattle.Tanks
{
    class LightTank : Tank
    {
        public LightTank()
        {
            TankType = "Легкий танк";
            MaxHP = 400f;
            HP = 400f;
            DodgeChance = 0.15f;
            MaxWeight = 5000;
            GunsQuantity = 1;
        }
    }
}
