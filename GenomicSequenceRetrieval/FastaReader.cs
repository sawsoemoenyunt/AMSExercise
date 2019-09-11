using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using System.IO;
using System.Text;

namespace GenomicSequenceRetrieval
{
    public class FastaReader
    {
        private StreamReader reader;

        public FastaReader(string filePath)
        {
            try
            {
                reader = new StreamReader(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Close()
        {
            reader.Close();
        }

        public string SequentialAccessByID(string id)
        {
            this.reader.BaseStream.Seek(0, SeekOrigin.Begin);

            string result = "";
            //Search16s -level2 16S.fasta NR_115365.1
            while (true)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    result = string.Format("Error, sequence {0} not found.", id);
                    break;
                }

                if (line.StartsWith(">", StringComparison.Ordinal))
                {
                    //metadata
                    if (line.Contains(id))
                    {
                        result = line;
                        string dna = reader.ReadLine();
                        if (line.StartsWith("", StringComparison.Ordinal))
                        {
                            result += "\n" + dna;
                        }
                        break;
                    }
                }
            }
            this.Close();
            return result;
        }

        public List<String> SequentialAccessByStartingPosition(int start, int rowCount = 1)
        {

            List<string> sequences = new List<string>();

            int sequenceCounter = 0;
            bool isFetchingData = true;


            while (isFetchingData)
            {
                sequenceCounter++;

                var line = reader.ReadLine();
                if (string.IsNullOrEmpty(line))
                    break;

                if (sequenceCounter >= start)
                {
                    if (line.StartsWith(">", StringComparison.Ordinal))
                    {//metadata

                        if (sequences.Count == rowCount)
                        {
                            isFetchingData = false;
                            break;
                        }
                        else
                        {
                            sequences.Add(line);
                        }
                    }
                    else
                    {//dna
                        if (sequences.Count > 0)
                        {
                            sequences[sequences.Count - 1] += "\n" + line;
                        }
                    }
                }
            }
            this.Close();
            return sequences;
        }

    }
}