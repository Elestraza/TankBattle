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

        public void GetArmor() { }
        public void SetArmor() { }

        public void GetWeapon() { }
        public void SetWeapon() { }


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
        public LightTank()
        {
            HP = 400;
            Dodge = 0.15f;
        }
    }
    public class MediumTank : Tank
    {
        public MediumTank()
        {
            HP = 550;
            Dodge = 0.07f;
        }
    }
    public class HeavyTank : Tank {
        public HeavyTank()
        {
            HP = 700;
            Dodge = 0f;
        }
    }
}
