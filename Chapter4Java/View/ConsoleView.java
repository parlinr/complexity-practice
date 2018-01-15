
public class ConsoleView {
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

        int userResponse = System.in.read();
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
                System.in.read();
                break;
        }
        return userResponseEnum;
    }
}