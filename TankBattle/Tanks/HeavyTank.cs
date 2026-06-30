
using TankBattle.Classes;

namespace TankBattle.Tanks
{
    class HeavyTank : Tank
    {
        public HeavyTank()
        {
            Name = "Тяжелый танк";
            MaxHP = 700;
            HP = 700;
            DodgeChance = 0f;
        }
        public override void Attack(List<Tank> enemies) 
        {
            Strategy.SelectTarget(this, enemies);
        }
    }
}
