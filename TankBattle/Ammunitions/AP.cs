using System;
using System.Collections.Generic;
using System.Text;
using TankBattle.Classes;
using static System.Net.Mime.MediaTypeNames;

namespace TankBattle.Ammunitions
{
    public class AP : Ammo // Бронебойный, игнорирует динамическую защиту
    {
        public AP()
        {
            Damage = 20;
        }
    }
}
