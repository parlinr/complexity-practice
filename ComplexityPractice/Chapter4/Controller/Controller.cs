using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Threading;


namespace Chapter4
{
    
    public class Controller
    {
        #region FIELDS
        bool applicationRunning = true;
        AppEnum.MenuAction userResponse;
        List<BarPatron> listOfPatrons;
        BusinessLayer businessLayer;
        #endregion

        #region PROPERTIES
        
        #endregion

        #region CONSTRUCTORS
        public Controller()
        {
            listOfPatrons = new List<BarPatron>();
            businessLayer = new BusinessLayer();
            ApplicationControl();
        }
        #endregion

        #region METHODS
        public void ApplicationControl()
        {
            
            while (applicationRunning)
            {
                Console.Clear();
                userResponse = ConsoleView.GetUserChoice();
                switch (userResponse)
                {
                    case AppEnum.MenuAction.NewSim:
                        NewSim();
                        break;
                    case AppEnum.MenuAction.LoadSim:
                        ConsoleView.DefaultResponse();
                        break;
                    case AppEnum.MenuAction.RunSim:
                        ConsoleView.DefaultResponse();
                        break;
                    case AppEnum.MenuAction.ViewCurrentSim:
                        ConsoleView.DefaultResponse();
                        break;
                    case AppEnum.MenuAction.ChangeProperties:
                        ConsoleView.DefaultResponse();
                        break;
                    case AppEnum.MenuAction.ExportSimData:
                        ConsoleView.DefaultResponse();
                        break;
                    case AppEnum.MenuAction.DeleteSim:
                        ConsoleView.DefaultResponse();
                        break;
                    case AppEnum.MenuAction.Exit:
                        applicationRunning = false;
                        break;
                    case AppEnum.MenuAction.SaveSimData:
                        SaveSimData();
                        break;
                    case AppEnum.MenuAction.None:
                        break;
                    
                }
            }

            ConsoleView.Exit();
        }

        /// <summary>
        /// Creates a new simulation
        /// </summary>
        private void NewSim()
        {
            ConsoleView.NewSimWait();
            for (int i = 0; i < 100; i++)
            {
                BarPatron patron = new BarPatron();
                patron.ID = i;
                Random random = new Random();
                patron.P = (double)random.Next(101) / 100;

                listOfPatrons.Add(patron);
                //the program needs to wait to get a new seed for the Random object
                Thread.Sleep(20);
            }
            ConsoleView.NewSimSuccess();
        }

        /// <summary>
        /// Saves the state of the current simulation
        /// </summary>
        private void SaveSimData()
        {
            string filePath = ConsoleView.GetFilePath();
            businessLayer.SavePatrons(listOfPatrons, filePath);
        }
        #endregion



    }
}
