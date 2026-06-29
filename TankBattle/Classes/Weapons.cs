using System;
using System.Collections.Generic;
using System.Text;

namespace TankBattle.Classes
{
    public class Weapon
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

        public virtual void Reload() { }

        public virtual void Attack() { }
    }
}