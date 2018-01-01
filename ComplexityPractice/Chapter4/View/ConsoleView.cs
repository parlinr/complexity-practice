using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    public static class ConsoleView
    {
        public static AppEnum.MenuAction GetUserChoice()
        {
            Console.WriteLine("To Bar, or Not To Bar?");
            Console.WriteLine("Enter the number corresponding to the desired option");
            Console.WriteLine();
            Console.WriteLine("(1) New Sim");
            Console.WriteLine("(2) Load Sim");
            Console.WriteLine("(3) Run Sim");
            Console.WriteLine("(4) View Current Sim");
            Console.WriteLine("(5) Change Properties");
            Console.WriteLine("(6) Export Sim Data");
            Console.WriteLine("(7) Delete Sim");
            Console.WriteLine("(8) Exit");

            ConsoleKeyInfo userResponse = Console.ReadKey(true);
            AppEnum.MenuAction userResponseEnum;

            switch (userResponse.KeyChar)
            {
                case '1':
                    userResponseEnum = AppEnum.MenuAction.NewSim;
                    break;
                case '2':
                    userResponseEnum = AppEnum.MenuAction.LoadSim;
                    break;
                case '3':
                    userResponseEnum = AppEnum.MenuAction.RunSim;
                    break;
                case '4':
                    userResponseEnum = AppEnum.MenuAction.ViewCurrentSim;
                    break;
                case '5':
                    userResponseEnum = AppEnum.MenuAction.ChangeProperties;
                    break;
                case '6':
                    userResponseEnum = AppEnum.MenuAction.ExportSimData;
                    break;
                case '7':
                    userResponseEnum = AppEnum.MenuAction.DeleteSim;
                    break;
                case '8':
                    userResponseEnum = AppEnum.MenuAction.Exit;
                    break;
                default:
                    Console.WriteLine("You did not enter a valid key. Press any key to try again.");
                    userResponseEnum = AppEnum.MenuAction.None;
                    Console.ReadKey(true);
                    break;
            }

            return userResponseEnum;
        }

        public static void Exit()
        {
            Console.Clear();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }

        public static void DefaultResponse()
        {
            Console.Clear();
            Console.WriteLine("You made a valid selection. Press any key to continue.");
            Console.ReadKey(true);
        }
    }
}
