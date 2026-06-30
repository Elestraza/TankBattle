using System;
using System.Collections.Generic;
using System.Text;
using TankBattle.Classes;
using static System.Net.Mime.MediaTypeNames;

namespace TankBattle.Ammunitions
{
    class Cumulative : Ammo // Кумулятивный, может быть отражен динамической защитой, игнорирует композитную броню
    {
        public Cumulative()
        {
            Damage = 15;
        }
    }
}
