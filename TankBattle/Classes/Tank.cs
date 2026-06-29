using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml.Linq;

namespace TankBattle.Classes
{
    public class Tank
    {
        private int _hp;
        public int HP
        {
            get { return _hp; }
            set { _hp = value; }
        }

        private float _dodge;
        public float Dodge
        {
            get { return _dodge; }
            set { _dodge = value; }
        }

        private object _armor;
        public object Armor
        {
            get { return _armor; }
            set { _armor = value; }
        }

        private object _weapon;
        public object Weapon
        {
            get { return _weapon; }
            set { _weapon = value; }
        }

        private object _ammo;
        public object Ammo
        {
            get { return _ammo; }
            set { _ammo = value; }
        }

        public Tank(object armor, object weapon, object ammo)
        {
            _armor = armor;
            _weapon = weapon;
            _ammo = ammo;
        }

        /*
            Легкий танк - 400 HP, повышенный шанс уклонения (15%);
            Средний танк - 550 HP, шанс уклонения 7%;
            Тяжелый танк - 750 HP, шанс уклонения 0%, может иметь 2 орудия (стреляет дважды за ход);
         */

        /*
            - орудие (3 вида с разными характеристиками);
	        - броня (3 вида с разными характеристиками);
	        - боеприпасы (3 вида с разными характеристиками);   
        */
    }


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
    public class HeavyTank : Tank {
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
