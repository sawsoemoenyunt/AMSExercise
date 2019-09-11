using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace GenomicSequenceRetrieval
{
    public class SearchLevel3 : Search
    {
        private string queryFileName;
        private string resultFileName;
        private List<string> resultList;
        private StreamReader streamReader;
        private StreamWriter streamWriter;

        public SearchLevel3(string programName, FlagLevel level, string file, string query, string result) : base(programName, level, file)
        {
            this.queryFileName = query;
            this.resultFileName = result;

            try
            {
                streamReader = new StreamReader(this.queryFileName);
                streamWriter = new StreamWriter(this.resultFileName);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        public override void ShowResult()
        {
            //do nothing here
        }

        public override void StartSearching()
        {
            try
            {
                resultList = new List<string>();
                while (true)
                {
                    string id = streamReader.ReadLine();
                    if (string.IsNullOrEmpty(id))
                    {
                        break;
                    }
                    string result = base.CurrentReader().SequentialAccessByID(id);
                    this.resultList.Add(result);
                }
                streamReader.Close();
                SaveResult();

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
