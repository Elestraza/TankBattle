using System;
using System.Collections.Generic;
using System.Text;

namespace TankBattle.Classes
{
    /*
        Нарезное - высокая точность (+10% к шансу попадания), урон 20-30;
        Гладкоствольное - урон 35-45, обычный шанс попадания;
        Автоматическое - низная точность (-15% к шансу попадания), 
            стреляет очередью (по 3 выстрела с уроном 10-15 каждый), 
            может стрелять только бронебойными и осколочно-фугасными, перезарядка 1 ход;
     */
    public class Ammunition
    {
        private int _damage;
        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        public int GetDamage(int _damage)
        {
            return _damage;
        }

    }

    public class HEF : Ammunition // Осколосно-фугасный
    {
        public HEF ()
        {
            Damage = 5;
        }
    }
    public class AP : Ammunition // Бронебойный, игнорирует динамическую защиту
    {

        public AP()
        {
            Damage = 20;
        }
    }
    public class SC : Ammunition // Кумулятивный, может быть отражен динамической защитой, игнорирует композитную броню
    {
        public SC()
        {
            Damage = 15;
        }
    }
}
