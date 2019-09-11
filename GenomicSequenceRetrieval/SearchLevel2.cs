using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenomicSequenceRetrieval
{
    public class SearchLevel2 : Search
    {
        private string sequenceId;
        private string result;

        public SearchLevel2(string programName, FlagLevel level, string file, string sequenceId) : base(programName, level, file)
        {
            this.sequenceId = sequenceId;
        }

        public override void ShowResult()
        {
            Console.WriteLine(result);
        }

        public override void StartSearching()
        {
            result = base.CurrentReader().SequentialAccessByID(this.sequenceId);
        }
    }
}
