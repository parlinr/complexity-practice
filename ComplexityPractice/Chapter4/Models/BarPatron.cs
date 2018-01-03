using System;
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
        //this is the bias factor which determines if the patron thinks history will repeat itself, values range from 0-100
        // 0 = history will never repeat itself
        // 100 = history will always repeat itself 
        //using int instead of double because I want 1.0 to be a possible probability and Random.NextDouble does not return 1.0
        public int P { get; set; }
        //this bool tracks whether a patron thinks history will repeat itself on a particular Friday night
        public bool WillHistoryRepeatItself { get; set; }
        //this bool tracks whether a patron went to the bar on a particular night
        public bool WillIGoToTheBarTonight { get; set; }

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
            int coinFlipResult = random.Next(101);
            

            //if P < coinFlipResult, patron thinks history will not repeat itself
            //if P >= coinFlipResult, patron thinks history will repeat itself
            if (P < coinFlipResult)
            {
                WillHistoryRepeatItself = false;
            }
            else
            {
                WillHistoryRepeatItself = true;
            }

            
        }

        /// <summary>
        /// This method determines whether a patron will go to the bar on a particular night
        /// </summary>
        public void WillIGoToTheBar()
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
        #endregion
    }
}
