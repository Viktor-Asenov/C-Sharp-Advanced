using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        public DateModifier (string firstDate, string secondDate)
        {
            this.FirstDate = DateTime.ParseExact(firstDate, "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);
            this.SecondDate = DateTime.ParseExact(secondDate, "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);
        }

        public DateTime FirstDate { get; private set; }

        public DateTime SecondDate { get; private set; }

        public int GetDaysDifference (string firstDate, string secondDate)
        {
            return Math.Abs((this.FirstDate.Date - this.SecondDate.Date).Days);
        }
    }
}
