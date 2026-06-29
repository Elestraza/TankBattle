using System;
using System.Collections.Generic;
using System.Text;
using TankBattle.Classes;

namespace TankBattle.Weapons
{
    public class AWeapon : Weapon // Автоматическое оружие
    {
        public AWeapon()
        {
            Aim = Aim - 0.15f;
            Auto = true;
        }
        public override void Attack()
        {
            // Attack x3
        }
    }
}
