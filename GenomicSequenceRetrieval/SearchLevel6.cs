using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace GenomicSequenceRetrieval
{
    public class SearchLevel6
    {
        public SearchLevel6()
        {
            //Search16s -level6 16S.fasta Streptomyces
        }

        public void Search()
        {
            FastaReader reader = new FastaReader("16S.fasta");
            List<string> idList = reader.GetIdListByName("Streptomyces");

            if (idList.Count() == 0)
            {
                Console.WriteLine("IDs not found!");
            }
            else
            {
                foreach (string id in idList)
                {
                    Console.WriteLine(id);
                }
                Console.WriteLine("Found : {0} rows", idList.Count);
            }

        }
    }
}
