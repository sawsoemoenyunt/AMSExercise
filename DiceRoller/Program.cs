using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiceRoller
{

    public class Die
    {
        // You should include your Die class from the previous exercise here
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

        public void SetFaceValue(int faceValue)
        {
            this.value = faceValue;
        }

        public int GetFaceValue()
        {
            return this.value;
        }

        public int GetNumFaces()
        {
            return this.faces;
        }
    }// end class Die

    public class Dice
    {
        // Implement your 'Dice' class here
        // ...
        List<Die> dieList = new List<Die>();
        Random random = new Random();

        public Dice(int dice)
        {
            for (int i = 0; i < dice; i++)
            {
                Die die = new Die();
                dieList.Add(die);
            }
        }

        public Dice(int dice, int faces)
        {
            for (int i = 0; i < dice; i++)
            {
                Die die = new Die(faces);
                dieList.Add(die);
            }
        }

        public void RollDice()
        {
            for (int i = 0; i < dieList.Count; i++)
            {
                dieList[i].SetFaceValue(random.Next(dieList[i].GetNumFaces()) + 1);
            }
        }

        public int GetFaceValue()
        {
            int faceValue = 0;

            for (int i = 0; i < dieList.Count; i++)
            {
                faceValue += dieList[i].GetFaceValue();
            }
            return faceValue;
        }

    }// end class Dice

    public class Program
    {
        public static void Main()
        {
            // This will not be called by the AMS, however you may want to test your Die class here.
            Dice myDice = new Dice(2);

            for (int i = 0; i < 1000; i++)
            {
                myDice.RollDice();
                Console.WriteLine(myDice.GetFaceValue());
            }
        }
    }
}