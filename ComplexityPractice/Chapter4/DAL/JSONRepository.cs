using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Chapter4
{
    public class JSONRepository : IRepository
    {
        public void SavePatrons(List<BarPatron> listOfPatrons, string filePath)
        {
                  
            string jsonText = JsonConvert.SerializeObject(listOfPatrons, Formatting.Indented);
            using (StreamWriter sWriter = new StreamWriter(filePath, true))
            {
                sWriter.Write(jsonText);
            }
           
        }
    }
}
