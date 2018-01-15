import java.util.Scanner;
import java.io.File;
import java.io.IOException;
import java.lang.Number;

public class ConsoleView {
    //FIELDS
    Scanner scanner;
    
    public ConsoleView() {
        scanner = new Scanner( System.in );
    }
    public MenuAction GetUserChoice() {
       

        System.out.println("To Bar, or Not To Bar?");
        System.out.println("Enter the number corresponding to the desired option and press enter");
        System.out.println();
        System.out.println("(1) New Sim");
        System.out.println("(2) Load Sim");
        System.out.println("(3) Run Sim");
        System.out.println("(4) View Current Sim");
        System.out.println("(5) Change Properties");
        System.out.println("(6) Save Sim Data");
        System.out.println("(7) Export Sim Data");
        System.out.println("(8) Delete Sim");
        System.out.println("(9) Exit");

        int userResponse = scanner.nextInt();
        MenuAction userResponseEnum;

        switch (userResponse) {
            case 1:
                userResponseEnum = MenuAction.NewSim;
                break;
            case 2:
                userResponseEnum = MenuAction.LoadSim;
                break;
            case 3:
                userResponseEnum = MenuAction.RunSim;
                break;
            case 4:
                userResponseEnum = MenuAction.ViewCurrentSim;
                break;
            case 5:
                userResponseEnum = MenuAction.ChangeProperties;
                break;
            case 6:
                userResponseEnum = MenuAction.SaveSimData;
                break;
            case 7:
                userResponseEnum = MenuAction.ExportSimData;
                break;
            case 8:
                userResponseEnum = MenuAction.DeleteSim;
                break;
            case 9:
                userResponseEnum = MenuAction.Exit;
                break;
            default:
                System.out.println("You did not enter a valid key. Press enter to try again.");
                userResponseEnum = MenuAction.None;
                scanner.next();
                break;
        }
        return userResponseEnum;
    }

    public void ClearScreen() {
        System.out.println(new String(new char[50]).replace("\0", "\r\n"));
    }

    public void Exit() {
        ClearScreen();
        System.out.println("Press enter to exit.");
        scanner.next();
    }

    public void DefaultResponse() {
        ClearScreen();
        System.out.println("You made a valid selection. Press enter to continue.");
        scanner.next();
    }

    public void NoSimLoaded() {
        ClearScreen();
        System.out.println("You have not loaded or created a new sim. Press enter to return to the main menu to load or create a sim.");
        scanner.next();
    }

    public String GetFilePath(String ext) {
        String sourceFolder;
        String os = System.getProperty("os.name");
        
        
        if (os.contains("Windows")) {
            sourceFolder = "Saves\\";
        }
        else {
            sourceFolder = "Saves//";
        }
        
        String filePath = "";
        boolean validFilePath = false;

        while (!validFilePath) {
            ClearScreen();
            System.out.println("Enter the name for the new save file.");
            String fileName = scanner.nextLine();
            if (ext == "json") {
                fileName += ".json";
            }
            else if (ext =="csv") {
                fileName += ".csv";
            }

            try {
                File file = new File(fileName);
                validFilePath = file.createNewFile();
                if (!validFilePath) {
                    System.out.println("The file name is invalid. Press enter to try again.");
                    scanner.next();
                }
                else {
                    filePath = sourceFolder + fileName;
                    file.delete();
                }
            }
            catch (IOException io) {
                System.out.println("The file could not be written because of an I/O error. Press enter to try again.");
                validFilePath = false;
                scanner.next();
            }
            catch (SecurityException s) {
                System.out.println("The file could not be written because of an access error. Press enter to try again.");
                validFilePath = false;
                scanner.next();
            }
        }
        return filePath;
    }
    
    public void SaveSuccessful() {
        System.out.println("The save operation was successful. Press enter to continue.");
        scanner.next();
    }

    public void ExportSuccessful() {
        System.out.println("The export operation was successful. Press enter to continue.");
        scanner.next();
    }

    public int GetNumberOfTimesToRunSim() {
        boolean validInt = false;
        int userInt = 0;

        while (!validInt) {
            ClearScreen();
            System.out.println("Enter the number of times you want to run the sim.");
            String userResponse = scanner.nextLine();

            try {
                userInt = Integer.parseInt(userResponse);
            }
            catch (NumberFormatException n) {
                System.out.println("The quantity you entered is either not an integer or is out of bounds. Press enter to try again.");
                scanner.next();
                continue;
            }
            validInt = true;
        }

        return userInt;
    }

    public void NewSimWait() {
        ClearScreen();
        System.out.println("The sim files are being created. Please wait.");
    }

    public void SimStart() {
        ClearScreen();
        System.out.println("The sim is running. Please wait.");
    }

    public void SimEnd() {
        System.out.println("The sim has completed. Press enter to continue.");
        scanner.next();
    }

    public void SimRunStarting() {
        System.out.println("A sim run is in progress ....");
    }
}