

public class Controller {
    //FIELDS
    boolean applicationRunning = true;
    MenuAction userResponse;



    //GET/SET

    //CONSTRUCTORS
    
    public Controller() {
        BarNight test = new BarNight();
        System.out.println("Enter a value for the object: ");
        int value = Integer.parseInt(System.console().readLine());
        test.setID(value);
        System.out.println("The object's value is: " + test.getID());
    }
    
    //METHODS
}