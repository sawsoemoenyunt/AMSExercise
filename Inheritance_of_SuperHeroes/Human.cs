using System;
namespace Inheritance_of_SuperHeroes
{
    public class Human : SuperHero
    {
        public Human(string name, string secretId) : base(name, secretId)
        {
        }

        public override bool HasPower(SuperPower whatPower)
        {
            return false;
        }

        public override int TotalPower()
        {
            return 0;
        }
    }
}
