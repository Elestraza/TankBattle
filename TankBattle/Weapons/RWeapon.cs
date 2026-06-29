using System;
using System.Collections.Generic;
using System.Text;
using TankBattle.Classes;

namespace TankBattle.Weapons
{
    public class RWeapon : Weapon // Нарезное оружие
    {
        public RWeapon()
        {
            Aim = Aim + 0.10f;
        }

        public override void Attack()
        {

        }
    }
}
