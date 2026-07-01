using System;
using System.Collections.Generic;
using System.Text;

namespace TankBattle.Classes
{
    abstract class Weapon
    {
        public Double Accuracy => 0.65f;
        public Int32 ReloadTime { get; set; }
        public abstract int Shoot(Tank attacker, Double Accuracy);
        public abstract Boolean CanUse(Ammo ammo);
        /*
            Нарезное - высокая точность (+10% к шансу попадания), урон 20-30;
            Гладкоствольное - урон 35-45, обычный шанс попадания;
            Автоматическое - низная точность (-15% к шансу попадания), 
                стреляет очередью (по 3 выстрела с уроном 10-15 каждый), 
                может стрелять только бронебойными и осколочно-фугасными, перезарядка 1 ход;
        */
    }
}