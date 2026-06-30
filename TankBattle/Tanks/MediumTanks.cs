
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
        }
        public override void Attack(List<Tank> enemies)
        {
            Strategy.SelectTarget(this, enemies);
        }
    }
}
