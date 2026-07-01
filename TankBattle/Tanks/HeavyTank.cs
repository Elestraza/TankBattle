
using TankBattle.Classes;
using Windows.UI.Text;

namespace TankBattle.Tanks
{
    class HeavyTank : Tank
    {
        public HeavyTank()
        {
            TankType = "Тяжелый танк";
            MaxHP = 700;
            HP = 700;
            DodgeChance = 0f;
            MaxWeight = 15000;
            GunsQuantity = Random.Shared.Next(1, 2);
        }
        
    }
}
