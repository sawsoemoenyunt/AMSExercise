using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GenomicSequenceRetrieval
{
    public class SearchLevel3 : Search
    {
        private string queryFileName;
        private string resultFileName;
        private List<string> resultList = new List<string>();
        private string[] idList;
        private StreamWriter streamWriter;

        public SearchLevel3(string programName, FlagLevel level, string file, string query, string result) : base(programName, level, file)
        {
            this.queryFileName = query;
            this.resultFileName = result;
        }

        public override void ShowResult()
        {
            //do nothing here
        }

        public override void StartSearching()
        {
            try
            {
                idList = File.ReadAllLines(this.queryFileName);

                foreach (var id in idList)
                {
                    string result = base.CurrentReader().SequentialAccessByID(id);
                    this.resultList.Add(result);

                }

            }
            catch (Exception ex)
            {
                base.ShowError(ex.Message);
            }
        }

        public void SaveResult()
        {
            try
            {
                streamWriter = new StreamWriter(this.resultFileName);

                foreach (string result in resultList)
                {
                    if (result.ToLower().Contains("error"))
                    {
                        //show error on console;
                        base.ShowError(result);
                    }
                    else
                    {
                        //save data to results.txt
                        streamWriter.WriteLine(result);
                    }
                }
                //close the writer
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                base.ShowError(ex.Message);
            }
        }
    }
}
