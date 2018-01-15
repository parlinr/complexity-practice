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
    public int getPreviousTwoFridays(int index) {
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
        Random random = new Random();
        int coinFlipResult = random.nextInt(100);

        //if P < coinFlipResult, patron thinks history will not repeat itself
        //if P >= coinFlipResult, patron thinks history will repeat itself
        if (getP() == 0) {
            setWillHistoryRepeatItself(false);
        }
        else if (getP() == 99) {
            setWillHistoryRepeatItself(true);
        }
        else if (getP() < coinFlipResult) {
            setWillHistoryRepeatItself(false);
        }
        else {
            setWillHistoryRepeatItself(true);
        }
    }

    /// <summary>
        /// This method determines whether a patron will go to the bar on a particular night.
        /// Used when there are 0 or 1 previous Friday nights simulated.
    /// </summary>

    public void WillIGoToTheBarSimple() {
        if (getWillHistoryRepeatItself() == true) {
            setWIllIGoToTheBarTonight(true);
        }
        else if (getWillHistoryRepeatItself() == false) {
            setWIllIGoToTheBarTonight(false);
        }
    }

    /// <summary>
        /// This method determines whether a patron will go to the bar on a particular night.
        /// Used when there are two or more previous Friday nights simulated.
        /// for Java: crib sheets are ints where:
        ///     -1 = no data
        ///     0 = false
        ///     1 = true
    /// </summary>
    public void WillIGoToTheBarWithHistory(int crib00, int crib01, int crib10, int crib11, BarNight secondToLast, BarNight last) {
        // get the result of the previous two nights
        int secondToLastValue = secondToLast.getResult();
        int lastValue = last.getResult();

        //check the corresponding crib sheet to see if it has a non-null value
        //if not, use the simple method
        if (secondToLastValue == 0 && lastValue == 0) {
            if (crib00 != -1) {
                if (crib00 == 1 && getWillHistoryRepeatItself() == true) {
                    setWIllIGoToTheBarTonight(false);
                }
                else if (crib00 == 1 && getWillHistoryRepeatItself() == false) {
                    setWIllIGoToTheBarTonight(true);
                }
                else if (crib00 == 0 && getWillHistoryRepeatItself() == true) {
                    setWIllIGoToTheBarTonight(true);
                }
                else if (crib00 == 0 && getWillHistoryRepeatItself() == false) {
                    setWIllIGoToTheBarTonight(false);
                }
            }
            else {
                WillIGoToTheBarSimple();
            }
        }
        else if (secondToLastValue == 0 && lastValue == 1) {
            if (crib01 != -1) {
                if (crib01 == 1 && getWillHistoryRepeatItself() == true) {
                    setWIllIGoToTheBarTonight(false);
                }
                else if (crib01 == 1 && getWillHistoryRepeatItself() == false) {
                    setWIllIGoToTheBarTonight(true);
                }
                else if (crib01 == 0 && getWillHistoryRepeatItself() == true) {
                    setWIllIGoToTheBarTonight(true);
                }
                else if (crib01 == 0 && getWillHistoryRepeatItself() == false) {
                    setWIllIGoToTheBarTonight(false);
                }
            }
            else {
                WillIGoToTheBarSimple();
            }
        }
        else if (secondToLastValue == 1 && lastValue == 0) {
            if (crib10 != -1) {
                if (crib10 == 1 && getWillHistoryRepeatItself() == true) {
                    setWIllIGoToTheBarTonight(false);
                }
                else if (crib10 == 1 && getWillHistoryRepeatItself() == false) {
                    setWIllIGoToTheBarTonight(true);
                }
                else if (crib10 == 0 && getWillHistoryRepeatItself() == true) {
                    setWIllIGoToTheBarTonight(true);
                }
                else if (crib10 == 0 && getWillHistoryRepeatItself() == false) {
                    setWIllIGoToTheBarTonight(false);
                }
            }
            else {
                WillIGoToTheBarSimple();
            }
        }
        else {
            if (crib11 != -1) {
                if (crib11 == 1 && getWillHistoryRepeatItself() == true) {
                    setWIllIGoToTheBarTonight(false);
                }
                else if (crib11 == 1 && getWillHistoryRepeatItself() == false) {
                    setWIllIGoToTheBarTonight(true);
                }
                else if (crib11 == 0 && getWillHistoryRepeatItself() == true) {
                    setWIllIGoToTheBarTonight(true);
                }
                else if (crib11 == 0 && getWillHistoryRepeatItself() == false) {
                    setWIllIGoToTheBarTonight(false);
                }
            }
            else {
                WillIGoToTheBarSimple();
            }
        }
    }

    public void GeneratePValue() {
        Random random = new Random();
        setP(random.nextInt(100));
    }
}