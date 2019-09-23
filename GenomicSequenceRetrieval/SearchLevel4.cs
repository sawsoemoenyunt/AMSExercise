using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace GenomicSequenceRetrieval
{
    public class SearchLevel4
    {
        string programName, fileName, id;
        int index;
        FastaReader reader;

        public SearchLevel4(string p, string f, string id, int index)
        {
            this.programName = p;
            this.fileName = f;
            this.id = id;
            this.index = index;
            reader = new FastaReader(this.fileName);
            
        }

        public void Search()
        {
            string[] ids = { "NR_115365.1", "NR_999999.9", "NR_118941.1" };
            int[] indexes = { 0, 531, 1236733 };

            for (int i = 0; i < ids.Length; i++)
            {
                string result = this.reader.DirectAccessByIndex(ids[i], indexes[i]);
                Console.WriteLine(result + "\n");
            }
        }
    }
}
