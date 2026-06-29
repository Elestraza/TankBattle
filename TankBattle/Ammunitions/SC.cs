using System;
using System.Collections.Generic;
using System.Text;
using TankBattle.Classes;
using static System.Net.Mime.MediaTypeNames;

namespace TankBattle.Ammunitions
{
    class SC : Ammo // Кумулятивный, может быть отражен динамической защитой, игнорирует композитную броню
    {
        public SC()
        {
            Damage = 15;
        }
    }
}
