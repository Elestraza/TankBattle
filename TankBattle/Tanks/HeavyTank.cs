using System;
using System.Collections.Generic;
using System.Text;
using TankBattle.Classes;

namespace TankBattle.Tanks
{
    public class HeavyTank : Tank
    {
        public HeavyTank(object armor, object weapon, object ammo)
        {
            HP = 700;
            Dodge = 0f;
            Armor = armor;
            Weapon = weapon;
            Ammo = ammo;
        }
    }
}
