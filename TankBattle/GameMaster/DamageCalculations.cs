using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using TankBattle.Classes;
using Windows.Security.Credentials;
using static System.Net.Mime.MediaTypeNames;

namespace TankBattle.GameMaster
{
    class DamageCalculations
    {
        
        public void ApplyDamage(List<DamageHolder> damageList)
        {
            for (int i = 0; i < damageList.Count; i++)
            {
                if (damageList[i].Reciever.IsAlive)
                {
                    var recievedDamage = damageList[i].Reciever.Armor.ReduceDamage(damageList[i].RecievingDamage, damageList[i].AttackerAmmo);
                    damageList[i].Reciever.HitRegister(recievedDamage);
                }
                else
                {
                    damageList[i].Reciever.HitRegister(0);
                }
            }
        }
        public void Attack(Tank attacker, List<Tank> enemies, Team team, DamageHolder damageHolder)
        {
            //DamageHolder damageHolder = new();
            for (int i = 0; i < attacker.GunsQuantity; i++)
            {
                if (attacker.Ammunition.Count <= 0)
                {
                    Console.WriteLine("У " + attacker.Name + " кончились снаряды.");
                    attacker.RecieveAmmo();
                    break;
                    
                } else
                {
                    Console.WriteLine(attacker.Name + " ходит");
                    damageHolder.Reciever = team.Strategy.SelectTarget(attacker, enemies);
                    damageHolder.RecievingDamage = attacker.Weapons.Shoot(attacker, attacker.Weapons.Accuracy);
                    damageHolder.AttackerAmmo = attacker.Ammunition.First();
                    var ammoIndex = attacker.Ammunition.IndexOf(attacker.Ammunition.First());
                    attacker.Ammunition.RemoveAt(ammoIndex);
                    attacker.Weight -= damageHolder.AttackerAmmo.AmmoWeight;
                    damageHolder.Attacker = attacker;
                    //return damageHolder;
                }
            }
        }        
    }
}
