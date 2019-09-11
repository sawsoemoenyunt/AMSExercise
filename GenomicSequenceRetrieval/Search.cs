using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenomicSequenceRetrieval
{
    public abstract class Search
    {
        private string programName;
        private FlagLevel searchLevel;
        private string dataFileName;
        private FastaReader reader;

        public Search(string programName, FlagLevel searchLevel, string dataFileName)
        {
            this.programName = programName;
            this.searchLevel = searchLevel;
            this.dataFileName = dataFileName;

            try
            {
                reader = new FastaReader(dataFileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public FastaReader CurrentReader()
        {
            return reader;
        }

        public string CurrentProgram()
        {
            return programName;
        }

        public FlagLevel CurrentLevel()
        {
            return searchLevel;
        }

        public void ShowError(string errorText)
        {
            Console.WriteLine(errorText);
        }

        public abstract void StartSearching();
        public abstract void ShowResult();
    }
}
