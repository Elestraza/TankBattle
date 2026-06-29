using System;
using System.Collections.Generic;
using System.Text;

namespace TankBattle.Classes
{
    public class Weapons
    {
        private float _aim = 0.65f;
        public float Aim
        {
            get { return _aim; }
            set { _aim = value; }
        }
        
        private bool _isAuto = false;
        public bool Auto
        {
            get { return _isAuto; }
            set { _isAuto = value; }
        }


        public virtual void Attack()
        {

        }
    }
    public class RWeapons : Weapons // Нарезное оружие
    {
        public RWeapons()
        {
            Aim = Aim + 0.10f;
        }

        public override void Attack()
        {

        }
    }
    public class SBWeapons : Weapons // Гладкоствольное оружие 
    {
        public SBWeapons()
        {
            Aim = Aim;
        }
        public override void Attack()
        {

        }
    }
    public class AWeapons : Weapons // Автоматическое оружие
    {
        public AWeapons()
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