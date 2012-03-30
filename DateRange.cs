using System;
using System.Linq;

namespace AJNLib
{
    /// <summary>
    /// Represents a range of two dates.
    /// </summary>
    public class DateRange
    {
        /// <summary>
        /// Gets the date respresenting the start of this range.
        /// </summary>
        public DateTime Start
        {
            get
            {
                return _startDate;
            }
        }

        /// <summary>
        /// Gets the date respresenting the end of this range.
        /// </summary>
        public DateTime End
        {
            get
            {
                return _endDate;
            }
        }

        /// <summary>
        /// Constructs a new DateRange using the supplied start and end dates.
        /// </summary>
        /// <param name="startDate">The start of the range.</param>
        /// <param name="endDate">The end of the range.</param>
        public DateRange(DateTime startDate, DateTime endDate)
        {
            this._startDate = startDate;
            this._endDate = endDate;
        }

        /// <summary>
        /// Returns a string representation of this range in the following format: dd/MM/yyyy - dd/MM/yyyy
        /// </summary>
        /// <returns>A string representation of this range.</returns>
        public override string ToString()
        {
            return string.Format("{0} - {1}", this.Start.ToString("dd/MM/yyyy"), this.End.ToString("dd/MM/yyyy"));
        }

        /// <summary>
        /// Returns the TimeSpan that this DateRange covers.
        /// </summary>
        /// <returns>A TimeSpan.</returns>
        public TimeSpan ToTimeSpan()
        {
            return new TimeSpan(this._endDate.Ticks - this._startDate.Ticks);
        }

        /// <summary>
        /// Confirms if the supplied date falls between the dates of this range.
        /// </summary>
        /// <param name="date">The date to check for.</param>
        /// <returns>true if the date is between the start and end dates of this range (inclusive).</returns>
        public bool IsInRange(DateTime date)
        {
            return date >= this._startDate && date <= this._endDate;
        }

        /// <summary>
        /// Confirms if the supplied dates fall between the dates of this range.
        /// </summary>
        /// <param name="dates">An array of dates to check for.</param>
        /// <returns>true if -ALL- dates supplied fall between the start date and end date of this range.</returns>
        public bool IsInRange(params DateTime[] dates)
        {
            return dates.All(d => IsInRange(d));
        }

        /// <summary>
        /// Checks if the supplied daterange is between the dates of this range.
        /// </summary>
        /// <param name="dates">The DateRange to check.</param>
        /// <returns>true if the DateRange starts and ends within this DateRange.</returns>
        public bool IsInRange(DateRange dates)
        {
            return IsInRange(dates.Start, dates.End);
        }

        private DateTime _startDate;
        private DateTime _endDate;
    }
}
