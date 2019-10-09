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
            List<string> indexlist = reader.MakeIndexForID(this.fileName);
            StreamWriter wr = new StreamWriter("16S.index");
            foreach (string result in indexlist)
            {
                if (result.ToLower().Contains("error"))
                {
                    Console.WriteLine("error");
                }
                else
                {
                    ///save data to results.txt
                    wr.WriteLine(result);
                }
            }
            ///close the writer
            wr.Close();

            string[] idList = { "NR_044838.1", "NR_118889.1", "NR_025955.1" };
            foreach (string data in idList)
            {
                foreach (string row in indexlist)
                {
                    if (row.Contains(data))
                    {
                        string[] sequenceAndIndex = row.Split(null);
                        string result = reader.DirectAccessByIndex(sequenceAndIndex[0], int.Parse(sequenceAndIndex[1]));
                        Console.WriteLine(result);
                    }
                }
            }
        }
    }

    public class TrackingTextReader : TextReader
    {
        private TextReader _baseReader;
        private int _position;

        public TrackingTextReader(TextReader baseReader)
        {
            _baseReader = baseReader;
        }

        public override int Read()
        {
            _position++;
            return _baseReader.Read();
        }

        public override int Peek()
        {
            return _baseReader.Peek();
        }

        public int Position
        {
            get { return _position; }
        }
    }
}
