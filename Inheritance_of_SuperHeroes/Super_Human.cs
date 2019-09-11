using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_of_SuperHeroes
{
    public class Super_Human : SuperHero
    {
        private int sumOfPowers;
        private List<SuperPower> powerSet;

        public Super_Human(string name, string secretId, List<SuperPower> myPowers) : base(name, secretId)
        {
            powerSet = myPowers;
        }

        public override bool HasPower(SuperPower whatPower)
        {
            return powerSet.Contains(whatPower);
        }

        public override int TotalPower()
        {
            sumOfPowers = 0;
            foreach (int power in powerSet)
            {
                sumOfPowers += power;
            }
            return sumOfPowers;
        }

        public void AddSuperPower(SuperPower newPower)
        {
            powerSet.Add(newPower);
        }

        public bool LoseSinglePower(SuperPower power)
        {
            return powerSet.Remove(power);
        }

        public void LoseAllSuperPowers()
        {
            powerSet.Clear();
        }
    }
}
