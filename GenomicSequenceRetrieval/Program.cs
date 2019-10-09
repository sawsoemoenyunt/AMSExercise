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
            //SequenceRetrieval v = new SequenceRetrieval(args);
            //v.StartValidate();
            SearchLevel4 s = new SearchLevel4("IndexSequence16s", "16S.fasta", "NR_118941.1", 1236733);
            s.Search();
            //SearchLevel6 s = new SearchLevel6();
            //s.Search();

            //FastaReader r = new FastaReader("16S.fasta");
            //r.SearchByIndex(2048);
        }
    }
}
