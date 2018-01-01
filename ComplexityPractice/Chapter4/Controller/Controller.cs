using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    
    public class Controller
    {
        #region FIELDS
        bool applicationRunning = true;
        AppEnum.MenuAction userResponse;
        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS
        public Controller()
        {
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
                        ConsoleView.DefaultResponse();
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
                    case AppEnum.MenuAction.None:
                        break;
                }
            }

            ConsoleView.Exit();
        }
        #endregion



    }
}
