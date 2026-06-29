using System;
using System.Collections.Generic;
using System.Text;

namespace TankBattle.Classes
{
    abstract class Armor
    {
        public float Protection { get; protected set; }

        public abstract int ReduceDamage(int damage, Ammo ammo);
        
        /*
            Катаная гомогенная - базовая 20%;
            Композитная - базовая 15%, защита от кумулятивных снарядов (снижает их урон на 40%);
            Динамическая защита - базовая 20%, шанс 60% отразить кумулятивный снаряд, полностью пробивается бронебойным снарядом;
        */
    }
}
