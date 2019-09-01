using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DieRoller
{
    /// <summary>
    /// Represents one die (singular of dice) with faces showing values between
    /// 1 and the number of faces on the die.
    /// </summary>
    public class Die
    {
        private int faces, value;
        Random random;

        // Implement your 'Die' class here
        public Die()
        {
            this.faces = 6;
            this.value = 1;
            random = new Random();
        }

        public Die(int _faces)
        {
            this.value = 1;
            random = new Random();

            if (_faces < 3)
            {
                this.faces = 6;
            }
            else
            {
                this.faces = _faces;
            }
        }

        public void RollDie()
        {
            this.value = random.Next(this.faces) + 1;
        }

        public int GetFaceValue()
        {
            return this.value;
        }

        public int GetNumFaces()
        {
            return this.faces;
        }

    }// end Class Die

    public class Program
    {
        public static void Main()
        {
            // This will not be called by the AMS, however you may want to test your Die class here.
            Die myDie = new Die(10);

            for (int i = 0; i < 1000; i++)
            {
                myDie.RollDie();

                Console.WriteLine(myDie.GetFaceValue());
            }
        }
    }
}