using System;
using System.Collections.Generic;
using System.Text;
using TankBattle.Classes;
using TankBattle.Tanks;

namespace TankBattle.GameMaster
{
    class TankFactory
    {
        public Tank CreateRandomTank()
        {
            Int32 type = Random.Shared.Next(3);
            return type switch
            {
                0 => new HeavyTank(),
                1 => new MediumTank(),
                2 => new LightTank()
            };
        }
    }
}
