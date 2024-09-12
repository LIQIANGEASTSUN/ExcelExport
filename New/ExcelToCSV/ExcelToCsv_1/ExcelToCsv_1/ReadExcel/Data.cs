using System.Collections.Generic;

namespace ReadExcel
{
    public class Data
    {
        private string fileName;
        private List<List<string>> rowList = new List<List<string>>();

        public Data(string fileName)
        {
            this.fileName = fileName;
        }

        public string FileName
        {
            get { return fileName; }
        }


    }
}
