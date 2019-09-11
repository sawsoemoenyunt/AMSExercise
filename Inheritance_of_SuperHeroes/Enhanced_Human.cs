using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_of_SuperHeroes
{
    public class Enhanced_Human : SuperHero
    {
        private int sumOfPowers;
        private bool enhanced;
        private List<SuperPower> powerSet;

        public Enhanced_Human(string name, string secretId, List<SuperPower> myPowers) : base(name, secretId)
        {
            powerSet = myPowers;
        }

        public override bool HasPower(SuperPower whatPower)
        { if (enhanced)
            {
                return powerSet.Contains(whatPower);
            }
            else
            {
                return false;
            }
        }

        public override int TotalPower()
        {

            if (enhanced)
            {
                sumOfPowers = 0;
                foreach (int power in powerSet)
                {
                    sumOfPowers += power;
                }
                return sumOfPowers;
            }
            else
            {
                return 0;
            }
        }

        public override void SwitchIdentity()
        {
            base.SwitchIdentity();
            enhanced = !enhanced;
        }
    }
}
