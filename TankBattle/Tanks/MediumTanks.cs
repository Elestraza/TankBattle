
using TankBattle.Classes;

namespace TankBattle.Tanks
{
    class MediumTank : Tank
    {
        public MediumTank()
        {
            Name = "Средний танк";
            MaxHP = 550;
            HP = 550;
            DodgeChance = 0.07f;
            MaxWeight = 10000;
            MaxAmmo = Random.Shared.Next(16, 31);
            CurrentAmmo = 0;
            GunsQuantity = 1;
        }   
    }
}
