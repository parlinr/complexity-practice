import java.util.*;

public class BarPatron {
    //FIELDS
    //this array tracks the result of the patron's decisions on the provious two Fridays
    private int [] _previousTwoFridays;
    //this is the bias factor which determines if the patron thinks history will repeat itself, values range from 0-99
        // 0 = history will never repeat itself
        // 99 = history will always repeat itself 
    private int _p;
    //this bool tracks whether a patron thinks history will repeat itself on a particular Friday night
    private boolean _willHistoryRepeatItself;
    //this bool tracks whether a patron went to the bar on a particular night
    private boolean _willIGoToTheBarTonight;
    //these ints track the individual patron's response to the last time a particular pattern arose
        // 0 = do not go
        // 1 = go
    private int _last00Result;
    private int _last01Result;
    private int _last10Result;
    private int _last11Result;
    //these ints track the cumulative number of wins and losses since the last time the P value was set
    private int _wins;
    private int _losses;

    private int _id;
    //GET/SET
    public int[] getPreviousTwoFridays(int index) {
        return _previousTwoFridays[index];
    }
    public void setPreviousTwoFridays(int index, int value) {
        _previousTwoFridays[index] = value;
    }   
    public int getP() {
        return _p;
    }
    public void setP(int value) {
        _p = value;
    }
    public boolean getWillHistoryRepeatItself() {
        return _willHistoryRepeatItself;
    }
    public void setWillHistoryRepeatItself(boolean value) {
        _willHistoryRepeatItself = value;
    }
    public boolean getWillIGoToTheBarTonight() {
        return _willIGoToTheBarTonight;
    }
    public void setWIllIGoToTheBarTonight(boolean value) {
        _willIGoToTheBarTonight = value;
    }
    public int getLast00Result() {
        return _last00Result;
    }
    public void setLast00Result(int value) {
        _last00Result = value;
    }
    public int getLast01Result() {
        return _last01Result;
    }
    public void setLast01Result(int value) {
        _last01Result = value;
    }
    public int getLast10Result() {
        return _last10Result;
    }
    public void setLast10Result(int value) {
        _last10Result = value;
    }
    public int getLast11Result() {
        return _last11Result;
    }
    public void setLast11Result(int value) {
        _last11Result = value;
    }
    public int getWins() {
        return _wins;
    }
    public void setWins(int value) {
        _wins = value;
    }
    public int getLosses() {
        return _losses;
    }
    public void setLosses(int value) {
        _losses = value;
    }
    public int getID() {
        return _id;
    }
    public void setID(int value) {
        _id = value;
    }
    //CONSTRUCTORS

    //METHODS
    /// <summary>
        /// Handles the biased coin flips to determine whether a patron thinks history will repeat itself. 
        /// </summary>
        /// <param name="p"></param>
    /// <returns></returns>
    public void BiasedCoinFlip() {
        
    }
}