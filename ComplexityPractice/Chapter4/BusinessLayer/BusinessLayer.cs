using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Chapter4
{
    public class BusinessLayer
    {
        public void SavePatrons(List<BarPatron> listOfPatrons, string filePath)
        {
            JSONRepository j = new JSONRepository();
            j.SavePatrons(listOfPatrons, filePath);
            ConsoleView.SaveSuccessful();
        }

    }
}
