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

        public SearchLevel4()
        {
            this.programName = "Search16s";
            this.fileName = "16S.fasta";
            this.id = "";
            reader = new FastaReader(this.fileName);

        }

        public void CreateIndex()
        {
            int counter = 0; // line counter in text file
            string line; // line of text
            int position = 0; // file position of first line
            List<int> pos = new List<int>(); // an array to keep ine positions in
            List<int> size = new List<int>(); // an array to keep ine size in


            // Read the file and display it line by line.  
            StreamReader file = new StreamReader(this.fileName);
            while ((line = file.ReadLine()) != null)
            {
                pos.Insert(counter, position); // store line position
                size.Insert(counter, line.Length + 1); // store line size
                counter++;
                position = position + line.Length + 1; // add 1 for '\n' character in file
                //System.Console.WriteLine(line); // display the line
            }
            System.Console.WriteLine("There were {0} lines.", counter);
            for (int i = 0; i < counter; i++)
            {
                System.Console.WriteLine("Line[{0}] : position {1}, size {2}", i, pos[i], size[i]);
            }
            file.Close();
            System.Console.WriteLine();

            // now use the parallel arrays index to access a line directly 
            using (FileStream fs = new FileStream(this.fileName, FileMode.Open, FileAccess.Read))
            {
                // the "using" construct ensures that the FileStream is properly closed/disposed   

                for (int n = 4; n < 6; n++)
                {
                    //display lines 4 and 5 in the file               
                    byte[] bytes = new byte[size[n]];
                    fs.Seek(pos[n], SeekOrigin.Begin);// seek to line n (note: there is no actual disk access yet)
                    System.Console.WriteLine("offset: {0}", fs.Position); // display the line
                    fs.Read(bytes, 0, size[n]); // get the data off disk - now there is disk access
                                                //System.Console.WriteLine("Line[{n}] : position {n}, size {n}", n, pos[n], size[n]);
                    System.Console.WriteLine(Encoding.Default.GetString(bytes)); // display the line
                }
            }

            // Suspend the screen.  
            System.Console.ReadLine();
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

            // now use the parallel arrays index to access a line directly 


            //FileStream fs = new FileStream(this.fileName, FileMode.Open,
            //    FileAccess.Read);

            ////display lines 4 and 5 in the file  
            ////fs.Seek(int.Parse(sequenceAndIndex[1]), SeekOrigin.Begin);


            //for (int i = 0; i < 5; i++)
            //{
            //    using (StreamReader streamReader = new StreamReader(this.fileName))
            //    {
            //        string[] sequenceAndIndex = indexlist[i].Split(null);
            //        streamReader.BaseStream.Seek(int.Parse(sequenceAndIndex[1]), SeekOrigin.Begin);
            //        Console.WriteLine(streamReader.ReadLine());
            //        streamReader.Close();
            //    }
            //}

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
