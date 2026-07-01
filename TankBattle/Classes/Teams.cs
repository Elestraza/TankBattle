using System.Linq;

namespace TankBattle.Classes
{
    class Team
    {
        public String Name { get; set; }
        public List<Tank> Tanks { get; set; } = [];
        public Tactic Strategy { get; set; }
        public Boolean IsDefeated => Tanks.All(tank => !tank.IsAlive); // LINQ выражение, для учета проигрыша, когда все танки команды мертвы, заменяет перебор через for
       
        public void LooseMsg()
        {
            if (IsDefeated)
                Console.WriteLine("Комманда " + Name + " проиграла...");
        }
    }
}
