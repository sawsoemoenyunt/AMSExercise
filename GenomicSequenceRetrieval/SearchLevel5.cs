using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace GenomicSequenceRetrieval
{
    public class SearchLevel5
    {
        public SearchLevel5()
        {
            //Search16s -level5 16S.fasta CTGGTACGGTCAACTTGCTCTAAG
        }

        public void Search()
        {
            FastaReader reader = new FastaReader("16S.fasta");
            List<string> idList = reader.GetIdListBySequence("ATTCTGGTTGATCCTGCCAG");

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
            }

        }
    }
}
