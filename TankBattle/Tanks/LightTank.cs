
using TankBattle.Classes;

namespace TankBattle.Tanks
{
    class LightTank : Tank
    {
        public LightTank()
        {
            Name = "Легкий танк";
            MaxHP = 400;
            HP = 400;
            DodgeChance = 0.15f;
            MaxWeight = 5000;
            MaxAmmo = Random.Shared.Next(16, 31);
            CurrentAmmo = 0;
        }
    }
}
