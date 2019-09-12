using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using System.IO;
using System.Text;

namespace GenomicSequenceRetrieval
{
    
    //<summary>
    //    The main FastaReader class
    //    Contains all methods for dealing with.fasta file
    //</summary>
    //<remark>
    //        This class can read and search data from .fasta file
    //</remark>
    public class FastaReader
    {
        //<summary>a private variable to store StreamReader</summary>
        private StreamReader reader;

        /*
            Intialize FastaReader
        */
        //<summary>
        //    Intialize FastaReader
        //</summary>
        //<remark>
        //<para>
        //This can create FastaReader
        //</para>
        //</remark>
        //<example>
        //<code>
        //    FastaReader fastaReader = new FastaReader("filename.fasta");
        //</code>
        //</example>
        //<exception>
        //    Throw exception if reader cannot create
        //</exception>
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

        
        //<summary>
        //    Close FastaReader
        //</summary>
        public void Close()
        {
            reader.Close();
        }

       
        //<summary>
        //    Search DNA seqence by SequenceID
        //</summary>
        //<remark>
        //<returns>
        //The found DNA sequence
        //</returns>
        //</remark>
        //<example>
        //<code>
        //    FastaReader fastaReader = new FastaReader("filename.fasta");
        //    string foundRow = fastaReader.SequentialAccessByID(yourSequenceID);
        //</code>
        //</example>
        public string SequentialAccessByID(string id)
        {
            this.reader.BaseStream.Seek(0, SeekOrigin.Begin);

            string result = "";

            if(id.ToCharArray().Length == 11)
            {
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
            }
            else
            {
                result = string.Format("Error, sequence {0} not found.", id);
            }
            
            return result;
        }

        //<summary>
        //    Show list of DNA sequence by start position and number of rows
        //</summary>
        //<remark>
        //<returns>
        //The list of DNA sequences
        //</returns>
        //</remark>
        //<example>
        //<code>
        //    FastaReader fastaReader = new FastaReader("filename.fasta");
        //    List<String> foundRows = fastaReader.SequentialAccessByStartingPosition(273, 10);
        //</code>
        //</example>
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