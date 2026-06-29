using System;
using System.Collections.Generic;
using System.Text;
using TankBattle.Classes;

namespace TankBattle.Tanks
{
    public class MediumTank : Tank
    {
        public MediumTank(object armor, object weapon, object ammo)
        {
            HP = 550;
            Dodge = 0.07f;
            Armor = armor;
            Weapon = weapon;
            Ammo = ammo;
        }
    }
}
