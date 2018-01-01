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
        //this is the bias factor by which a patron's decision to go or not go will be modified by
        public double P { get; set; }

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

        #endregion
    }
}
