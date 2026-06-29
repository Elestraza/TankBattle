using System;
using System.Collections.Generic;
using System.Text;
using TankBattle.Classes;
using static System.Net.Mime.MediaTypeNames;

namespace TankBattle.Ammunition
{
    public class HEF : Ammo // Осколосно-фугасный
    {
        public HEF()
        {
            Damage = 5;
        }
    }
}
