using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Chapter4
{
    class CSVExportRepository
    {
        public void ExportSimData(List<BarPatron> listOfPatrons, string filePath)
        {
            string pValue;
            StreamWriter sWriter = new StreamWriter(filePath, false);

            using (sWriter)
            {
                foreach (BarPatron patron in listOfPatrons)
                {
                    pValue = patron.P.ToString();
                    sWriter.WriteLine(pValue);
                }
            }
        }
    }
}
