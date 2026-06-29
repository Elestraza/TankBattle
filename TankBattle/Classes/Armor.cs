using System;
using System.Collections.Generic;
using System.Text;

namespace TankBattle.Classes
{
    public class Armor
    {
        private float _damageReduction;
        public float DamageReduction 
        {
            get { return _damageReduction; } 
            set { _damageReduction = value; }
        }

        /*
            Катаная гомогенная - базовая 20%;
            Композитная - базовая 15%, защита от кумулятивных снарядов (снижает их урон на 40%);
            Динамическая защита - базовая 20%, шанс 60% отразить кумулятивный снаряд, полностью пробивается бронебойным снарядом;
        */
    }
}
