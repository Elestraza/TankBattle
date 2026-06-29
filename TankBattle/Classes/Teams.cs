using System.Linq;

namespace TankBattle.Classes
{
    class Team
    {
        public string Name { get; set; }
        public List<Tank> Tanks { get; set; } = new();

        public bool IsDefeated => Tanks.All(tank => !tank.IsAlive); // LINQ выражение, для учета проигрыша, когда все танки команды мертвы, заменяет перебор через for(;;)
    }
}
