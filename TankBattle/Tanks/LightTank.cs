using System;
using System.Collections.Generic;
using System.Text;
using TankBattle.Classes;

namespace TankBattle.Tanks
{
    public class LightTank : Tank
    {
        public LightTank(object armor, object weapon, object ammo)
        {
            HP = 400;
            Dodge = 0.15f;
            Armor = armor;
            Weapon = weapon;
            Ammo = ammo;
        }
    }
}
