using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenomicSequenceRetrieval
{
   
    ///<summary>
    ///The class inherit from Search.class
    ///</summary>
    public class SearchLevel1 : Search
    {
        private int startIndex;
        private int rows;
        private List<string> resultList;

        public SearchLevel1(string programName, FlagLevel level, string fileName, int start, int rows) : base(programName, level, fileName)
        {
            if (start % 2 == 0)
            {
                ShowError("Please enter odd number for start position.");
            }
            else
            {
                this.startIndex = start;
                this.rows = rows;
            }
        }

        public override void StartSearching()
        {
            this.resultList = base.CurrentReader().SequentialAccessByStartingPosition(this.startIndex, rows);
        }

        public override void ShowResult()
        {
            foreach (string result in resultList)
            {
                Console.WriteLine(result);
            }
        }
    }
}
