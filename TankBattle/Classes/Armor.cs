using System;
using System.Collections.Generic;
using System.Text;

namespace TankBattle.Classes
{
    public class Armor
    {

        /*
            Катаная гомогенная - базовая 20%;
            Композитная - базовая 15%, защита от кумулятивных снарядов (снижает их урон на 40%);
            Динамическая защита - базовая 20%, шанс 60% отразить кумулятивный снаряд, полностью пробивается бронебойным снарядом;

         */
    }

    public class LightArmor: Armor{ }
    public class MediumArmor : Armor { }
    public class HeavyArmor : Armor { }
}
