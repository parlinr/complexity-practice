using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            Console.WriteLine("(6) Save Sim Data");
            Console.WriteLine("(7) Export Sim Data");
            Console.WriteLine("(8) Delete Sim");
            Console.WriteLine("(9) Exit");

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
                    userResponseEnum = AppEnum.MenuAction.SaveSimData;
                    break;
                case '7':
                    userResponseEnum = AppEnum.MenuAction.ExportSimData;
                    break;
                case '8':
                    userResponseEnum = AppEnum.MenuAction.DeleteSim;
                    break;
                case '9':
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

        public static void NewSimSuccess()
        {
            Console.WriteLine("The new simulation was successfully created. Press any key to continue.");
            Console.ReadKey(true);
        }

        public static void NoSimLoaded()
        {
            Console.Clear();
            Console.WriteLine("You have not loaded or created a new sim. Press any key to return to the main menu to load or create a sim.");
            Console.ReadKey(true);
        }

        public static string GetFilePath()
        {
            string sourceFolder = "Saves\\";
            string filePath = "";
            bool validFilePath = false;

            while (!validFilePath)
            {
                Console.Clear();
                Console.WriteLine("Enter the name for the new save file.");
                string fileName = Console.ReadLine();
                fileName += ".json";
                //from https://stackoverflow.com/questions/4650462/easiest-way-to-check-if-an-arbitrary-string-is-a-valid-filename
                var isValid = !string.IsNullOrEmpty(fileName) &&
                  fileName.IndexOfAny(Path.GetInvalidFileNameChars()) < 0 &&
                  !File.Exists(Path.Combine(sourceFolder, fileName));
                if (isValid)
                {
                    Console.WriteLine("The chosen file name is valid. Press any key to continue.");
                    filePath = sourceFolder + fileName;
                    validFilePath = true;
                    Console.ReadKey(true);
                }
                else
                {
                    Console.WriteLine("The chosen file name is not valid. Press any key to try again.");
                    Console.ReadKey(true);
                }
            }
            return filePath;

        }

        public static void SaveSuccessful()
        {
            Console.WriteLine("The save operation was successful. Press any key to continue.");
            Console.ReadKey(true);
        }

        public static void NewSimWait()
        {
            Console.Clear();
            Console.WriteLine("The sim files are being created. Please wait.");
        }
    }

}
