using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenomicSequenceRetrieval
{
    
    ///<summary>
    ///    The main Search class
    ///</summary>
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

        ///<summary>
        ///    This method return current FastaReader
        ///</summary>
        public FastaReader CurrentReader()
        {
            return reader;
        }

        ///<summary>
        ///    This method return current program name
        ///</summary>
        public string CurrentProgram()
        {
            return programName;
        }

        ///<summary>
        ///    This method return current FlagLevel
        ///</summary>
        public FlagLevel CurrentLevel()
        {
            return searchLevel;
        }

        ///<summary>
        ///    This method is to show error on console
        ///</summary>
        public void ShowError(string errorText)
        {
            Console.WriteLine(errorText);
        }

        public abstract void StartSearching();
        public abstract void ShowResult();
    }
}
