using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace GenomicSequenceRetrieval
{
    public class SearchLevel7 : Search
    {
        private string sequenceWildcard;
        private List<string> matchedSequenceList;

        public SearchLevel7(string programName, FlagLevel level, string file, string sequenceWildcard) : base(programName, level, file)
        {
            this.sequenceWildcard = sequenceWildcard;
        }

        public override void ShowResult()
        {
            if (matchedSequenceList.Count > 0)
            {
                foreach (string sequence in matchedSequenceList)
                {
                    Console.WriteLine(sequence);
                }
                Console.WriteLine("\nTotal {0} sequence matched.", matchedSequenceList.Count);
                Console.WriteLine("Sequencewildcard {0}", this.sequenceWildcard);
            }
            else
            {
                Console.WriteLine("No matched sequences");
            }
        }

        public override void StartSearching()
        {
            this.matchedSequenceList = base.CurrentReader().SearchSequenceWithWildCard(this.sequenceWildcard);
        }
    }
}
