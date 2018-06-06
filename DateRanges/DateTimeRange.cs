using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateRanges
{
    /// <summary>
    /// Represents one continuos DateTime range
    /// </summary>
    public class DateTimeRange
    {

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        //sidekicks

        public DateTimeRange(DateTime date1, DateTime date2)
        {

        }

        public DateTime MaxDate(DateTime date1, DateTime date2)
        {
            if (date1 > date2)
                return date1;
            else
                return date2;
        }

        public DateTime MinDate(DateTime date1, DateTime date2)
        {
            if (date1 < date2)
                return date1;
            else
                return date2;
        }

        /// <summary>
        /// Adds given range to current range
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public DateTimeRange[] Add(DateTimeRange range)
        {
            if (IntersectsWith(range))
                return new DateTimeRange[] { Merge(range) };
            else
                return new DateTimeRange[] { this, range };
        }

        /// <summary>
        /// Subtracts given range from current range
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public DateTimeRange[] Subtract(DateTimeRange range)
        {
            if (!IntersectsWith(range))
                return new DateTimeRange[] { this };
            if (Contains(range))
            {
                var d1 = new DateTimeRange(this.Start, range.Start);
                var d2 = new DateTimeRange(range.End, this.End);
                return new DateTimeRange[] { d1, d2 };
            }
            else//when given range intersects on the right side of current range
            {
                var d1 = new DateTimeRange(this.Start, range.Start);
                return new DateTimeRange[] { d1 };
            }
            //one case left - when given range intersects on the left side of current range

        }

        /// <summary>
        /// Merges current range with given range
        /// If ranges doesn't intersect, they are merged as longest period possible to create
        /// </summary>
        /// <param name="dateRange"></param>
        public DateTimeRange Merge(DateTimeRange dateRange)
        {
            var startDate = MinDate(this.Start, dateRange.Start);
            var endDate = MaxDate(this.End, dateRange.End);
            return new DateTimeRange(startDate, endDate);
        }

        /// <summary>
        /// Expands current range to given date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateTimeRange ExpandTo(DateTime date)
        {
            if (date >= this.End)
                return new DateTimeRange(this.Start, date);
            else if (date <= this.Start)
                return new DateTimeRange(date, this.End);
            else
                return this;
        }

        /// <summary>
        /// Return value indicating if current range intersects with given range
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Boolean IntersectsWith(DateTimeRange range)
        {
            return this.End >= range.Start || this.Start <= range.End;
        }



        /// <summary>
        /// Returns value indicating if current range starts with given range
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Boolean StartsWith(DateTimeRange range)
        {
            return this.Start == range.Start;
        }

        /// <summary>
        /// Returns value indicating if current range ends with given range
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Boolean EndsWith(DateTimeRange range)
        {
            return this.End == range.End;
        }

        /// <summary>
        /// Return value indicating if current range contains whole given range
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Boolean Contains(DateTimeRange range)
        {
            return range.Start >= this.Start && range.End <= this.End;
        }

        /// <summary>
        /// Gets value indicating if current range is continuation of given date time range
        /// </summary>
        /// <param name="dateRange"></param>
        /// <returns></returns>
        public Boolean IsContinuationOf(DateTimeRange dateRange)
        {
            return this.Start == dateRange.End;
        }

        /// <summary>
        /// Returns value indicating if current range is equal to given range
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Boolean IsEqualTo(DateTimeRange range)
        {
            return this.Start == range.Start && this.End == range.End;
        }

    }
}
