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
        List<BarNight> simHistory;

        //crib sheets (false = go, true = don't go)
        bool? last00 = null;
        bool? last01 = null;
        bool? last10 = null;
        bool? last11 = null;

        #endregion

        #region PROPERTIES
        
        #endregion

        #region CONSTRUCTORS
        public Controller()
        {
            listOfPatrons = new List<BarPatron>();
            businessLayer = new BusinessLayer();
            simHistory = new List<BarNight>();
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
                        RunSim();
                        break;
                    case AppEnum.MenuAction.ViewCurrentSim:
                        ConsoleView.DefaultResponse();
                        break;
                    case AppEnum.MenuAction.ChangeProperties:
                        ConsoleView.DefaultResponse();
                        break;
                    case AppEnum.MenuAction.ExportSimData:
                        ExportSimData();
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
                patron.GeneratePValue();
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
            string filePath = ConsoleView.GetFilePath("json");
            businessLayer.SavePatrons(listOfPatrons, filePath);
        }

        /// <summary>
        /// Simulates a Friday night at the bar
        /// </summary>
        private void RunSim()
        {
            int numberOfTimes = ConsoleView.GetNumberOfTimesToRunSim();
            ConsoleView.SimStart();
            for (int i = 0; i < numberOfTimes; i++)
            {
                ConsoleView.SimRunStarting();
                ProcessSimIteration();
            }
            
            ConsoleView.SimEnd();
        }

        /// <summary>
        /// The sim iterations are performed here
        /// </summary>
        private void ProcessSimIteration()
        {
            List<BarPatron> bargoingPatrons = new List<BarPatron>();

            //make sure a sim is loaded/created; if not, the user needs to load or make one
            if (listOfPatrons.Count == 0)
            {
                ConsoleView.NoSimLoaded();
                return;
            }

            //all patrons perform their biased coin flips to determine whether they think
            //history will repeat itself that night
            foreach (BarPatron patron in listOfPatrons)
            {
                patron.BiasedCoinFlip();
            }

            //if there are at least two values for history, see if there is a crib sheet
            //value and use it
            //otherwise, just use the patron's WillHistoryRepeatItself value to determine
            //whether or not to go to the bar

            if (simHistory.Count >= 3)
            {
                foreach (BarPatron patron in listOfPatrons)
                {
                    int historyCount = simHistory.Count;
                    patron.WillIGoToTheBarWithHistory(last00, last01, last10, last11, simHistory.ElementAt(historyCount - 2), simHistory.ElementAt(historyCount - 1));
                    if (patron.WillIGoToTheBarTonight == true)
                    {
                        bargoingPatrons.Add(patron);
                    }
                }
            }
            else
            {
                foreach (BarPatron patron in listOfPatrons)
                {
                    patron.WillIGoToTheBarSimple();
                    if (patron.WillIGoToTheBarTonight == true)
                    {
                        bargoingPatrons.Add(patron);
                    }
                }
            }




            //count the bargoing patrons
            int patronsGoingToBar = bargoingPatrons.Count;

            //determine who wins and loses and record this night appropriately
            bool wasNumberOfBargoersGreaterThan60 = false;

            //determine if the night was overcrowded or undercrowded
            //and record it in the sim history
            if (patronsGoingToBar > 60)
            {
                wasNumberOfBargoersGreaterThan60 = true;
                BarNight tonight = new BarNight();
                tonight.ID = simHistory.Count;
                tonight.Result = 0;
                simHistory.Add(tonight);
            }
            else if (patronsGoingToBar <= 60)
            {
                wasNumberOfBargoersGreaterThan60 = false;
                BarNight tonight = new BarNight();
                tonight.ID = simHistory.Count;
                tonight.Result = 1;
                simHistory.Add(tonight);
            }

            //determine if each individual patron won or lost
            foreach (BarPatron patron in listOfPatrons)
            {
                if (wasNumberOfBargoersGreaterThan60 == true && patron.WillIGoToTheBarTonight == true)
                {
                    patron.Losses += 1;
                }
                else if (wasNumberOfBargoersGreaterThan60 == true && patron.WillIGoToTheBarTonight == false)
                {
                    patron.Wins += 1;
                }
                else if (wasNumberOfBargoersGreaterThan60 == false && patron.WillIGoToTheBarTonight == true)
                {
                    patron.Wins += 1;
                }
                else if (wasNumberOfBargoersGreaterThan60 == false && patron.WillIGoToTheBarTonight == false)
                {
                    patron.Losses += 1;
                }
            }

            //crib sheet is updated
            int count = simHistory.Count;
            if (count > 2)
            {
                if (simHistory.ElementAt(count - 3).Result == 0 && simHistory.ElementAt(count - 2).Result == 0)
                {
                    last00 = wasNumberOfBargoersGreaterThan60;
                }
                else if (simHistory.ElementAt(count - 3).Result == 0 && simHistory.ElementAt(count - 2).Result == 1)
                {
                    last01 = wasNumberOfBargoersGreaterThan60;
                }
                else if (simHistory.ElementAt(count - 3).Result == 1 && simHistory.ElementAt(count - 2).Result == 0)
                {
                    last10 = wasNumberOfBargoersGreaterThan60;
                }
                else if (simHistory.ElementAt(count - 3).Result == 1 && simHistory.ElementAt(count - 2).Result == 1)
                {
                    last11 = wasNumberOfBargoersGreaterThan60;
                }
            }

            //each patron analyzes their cumulative results
            //and generates a new P value if needed
            foreach (BarPatron patron in listOfPatrons)
            {
                if (patron.Wins - patron.Losses <= -5)
                {
                    patron.GeneratePValue();
                    //the thread needs to wait for 20 ms to ensure that a new seed is obtained
                    Thread.Sleep(20);
                    patron.Wins = 0;
                    patron.Losses = 0;
                }
            }

        }

        private void ExportSimData()
        {
            string filePath = ConsoleView.GetFilePath("csv");
            businessLayer.ExportSimData(listOfPatrons, filePath);
        }
        
        
        #endregion



    }
}
