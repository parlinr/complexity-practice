﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    public class BarPatron
    {
        #region FIELDS
        
        #endregion

        #region PROPERTIES
        //this array tracks the result of the patron's decisions on the provious two Fridays
        public int[] PreviousTwoFridays { get; set; }
        //this is the bias factor which determines if the patron thinks history will repeat itself, values range from 0-99
        // 0 = history will never repeat itself
        // 99 = history will always repeat itself 
        
        public int P { get; set; }
        //this bool tracks whether a patron thinks history will repeat itself on a particular Friday night
        public bool WillHistoryRepeatItself { get; set; }
        //this bool tracks whether a patron went to the bar on a particular night
        public bool WillIGoToTheBarTonight { get; set; }
        //these are the null history objects for the first two runs

        //these ints track the individual patron's response to the last time a particular pattern arose
        // 0 = do not go
        // 1 = go
        public int Last00Result { get; set; }
        public int Last01Result { get; set; }
        public int Last10Result { get; set; }
        public int Last11Result { get; set; }

        //these ints track the cumulative number of wins and losses since the last time the P value was set
        public int Wins { get; set; }
        public int Losses { get; set; }

        public int ID { get; set; }
        #endregion

        #region CONSTRUCTORS
        public BarPatron()
        {
        }
        #endregion

        #region METHODS
        /// <summary>
        /// Handles the biased coin flips to determine whether a patron thinks history will repeat itself. 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public void BiasedCoinFlip()
        {
            Random random = new Random();
            int coinFlipResult = random.Next(100);
            

            //if P < coinFlipResult, patron thinks history will not repeat itself
            //if P >= coinFlipResult, patron thinks history will repeat itself
            if (P == 0)
            {
                WillHistoryRepeatItself = false;
            }
            else if (P == 99)
            {
                WillHistoryRepeatItself = true;
            }
            else if (P < coinFlipResult)
            {
                WillHistoryRepeatItself = false;
            }
            else
            {
                WillHistoryRepeatItself = true;
            }

            
        }

        /// <summary>
        /// This method determines whether a patron will go to the bar on a particular night.
        /// Used when there are 0 or 1 previous Friday nights simulated.
        /// </summary>
        public void WillIGoToTheBarSimple()
        {
            if (WillHistoryRepeatItself == true)
            {
                WillIGoToTheBarTonight = true;
            }
            else if (WillHistoryRepeatItself == false)
            {
                WillIGoToTheBarTonight = false;
            }
        }

        /// <summary>
        /// This method determines whether a patron will go to the bar on a particular night.
        /// Used when there are two or more previous Friday nights simulated.
        /// </summary>
        public void WillIGoToTheBarWithHistory(bool? crib00, bool? crib01, bool? crib10, bool? crib11, BarNight secondToLast, BarNight last)
        {
            //get the result of the previous two nights
            int secondToLastValue = secondToLast.Result;
            int lastValue = last.Result;

            //check the corresponding crib sheet to see if it has a non-null value
            //if not, use the simple method
            if (secondToLastValue == 0 && lastValue == 0)
            {
                if (crib00 != null)
                {
                    if (crib00 == true && WillHistoryRepeatItself == true)
                    {
                        WillIGoToTheBarTonight = false;
                    }
                    else if (crib00 == true && WillHistoryRepeatItself == false)
                    {
                        WillIGoToTheBarTonight = true;
                    }
                    else if (crib00 == false && WillHistoryRepeatItself == true)
                    {
                        WillIGoToTheBarTonight = true;
                    }
                    else if (crib00 == false && WillHistoryRepeatItself == false)
                    {
                        WillIGoToTheBarTonight = false;
                    }
                }
                else
                {
                    WillIGoToTheBarSimple();
                }
            }
            else if (secondToLastValue == 0 && lastValue == 1)
            {
                if (crib01 != null)
                {
                    if (crib01 == true && WillHistoryRepeatItself == true)
                    {
                        WillIGoToTheBarTonight = false;
                    }
                    else if (crib01 == true && WillHistoryRepeatItself == false)
                    {
                        WillIGoToTheBarTonight = true;
                    }
                    else if (crib01 == false && WillHistoryRepeatItself == true)
                    {
                        WillIGoToTheBarTonight = true;
                    }
                    else if (crib01 == false && WillHistoryRepeatItself == false)
                    {
                        WillIGoToTheBarTonight = false;
                    }
                }
                else
                {
                    WillIGoToTheBarSimple();
                }
            }
            else if (secondToLastValue == 1 && lastValue == 0)
            {
                if (crib10 != null)
                {
                    if (crib10 == true && WillHistoryRepeatItself == true)
                    {
                        WillIGoToTheBarTonight = false;
                    }
                    else if (crib10 == true && WillHistoryRepeatItself == false)
                    {
                        WillIGoToTheBarTonight = true;
                    }
                    else if (crib10 == false && WillHistoryRepeatItself == true)
                    {
                        WillIGoToTheBarTonight = true;
                    }
                    else if (crib10 == false && WillHistoryRepeatItself == false)
                    {
                        WillIGoToTheBarTonight = false;
                    }
                }
                else
                {
                    WillIGoToTheBarSimple();
                }
            }
            else
            {
                if (crib11 != null)
                {
                    if (crib11 == true && WillHistoryRepeatItself == true)
                    {
                        WillIGoToTheBarTonight = false;
                    }
                    else if (crib11 == true && WillHistoryRepeatItself == false)
                    {
                        WillIGoToTheBarTonight = true;
                    }
                    else if (crib11 == false && WillHistoryRepeatItself == true)
                    {
                        WillIGoToTheBarTonight = true;
                    }
                    else if (crib11 == false && WillHistoryRepeatItself == false)
                    {
                        WillIGoToTheBarTonight = false;
                    }
                }
                else
                {
                    WillIGoToTheBarSimple();
                }
            }
            
        }

        public void GeneratePValue()
        {
            Random random = new Random();
            P = random.Next(100);
        }
        #endregion
    }
}
