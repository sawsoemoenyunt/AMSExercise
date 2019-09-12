using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenomicSequenceRetrieval
{
    class Program
    {
        static void Main(string[] args)
        {
            Validator v = new Validator(args);
            v.StartValidate();
            Console.ReadLine();

        }
    }
}
