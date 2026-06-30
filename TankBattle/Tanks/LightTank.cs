
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
        }
        public override void Attack(List<Tank> enemies)
        {
            throw new NotImplementedException();
        }
    }
}
