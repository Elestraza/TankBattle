using System;
using System.Collections.Generic;
using System.Text;
using TankBattle.Classes;
using static System.Net.Mime.MediaTypeNames;

namespace TankBattle.Ammunitions
{
    class ArmorPearcing : Ammo // Бронебойный, игнорирует динамическую защиту
    {
        public ArmorPearcing()
        {
            Damage = 20;
        }
    }
}
