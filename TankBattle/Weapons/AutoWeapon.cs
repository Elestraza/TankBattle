using TankBattle.Ammunitions;
using TankBattle.Classes;

namespace TankBattle.Weapons
{
    class AutoWeapon : Weapon // Автоматическое оружие
    {
        public Double Accuracy => Accuracy - (Accuracy*0.15f);
        public AutoWeapon()
        {
            ReloadTime = 1;
        }

        public override int Shoot(Tank attacker, Double Accuracy)
        {
            var round = attacker.Ammunition.IndexOf(attacker.Ammunition.First());
            if (!CanUse(attacker.Ammunition[round]))
            {
                Console.WriteLine(attacker.Name + " - Осечка!");
                attacker.Ammunition.RemoveAt(round);
            }
            if (this.ReloadTime > 0)
            {
                Console.WriteLine(attacker.Name + " - Перезарядка");
                this.ReloadTime = 0;
                return 0;
            }
            Int32 fullDamage = 0;

            for (Int32 i = 0; i < 2; i++)
            {
                if (Random.Shared.NextDouble() < Accuracy)
                {
                    fullDamage += Random.Shared.Next(10, 16) + attacker.Ammunition.First().Damage;
                } else
                {
                    Console.WriteLine(attacker.Name + ": Выстрел " + (Int32)(i + 1) + " промазал.");
                }

            }
            this.ReloadTime = 1;
            return fullDamage;

        }

        public override bool CanUse(Ammo ammo)
        {
            if (ammo is HighExplosive)
                return true;
            if (ammo is ArmorPearcing)
                return true;
            return false;
        }
    }
}
