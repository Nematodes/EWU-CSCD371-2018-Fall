using System;

namespace BrianBosAssignmentEight
{
    /*
     * Each time Hours, Minutes, or Seconds is changed, a new DateTime is created.
     * This is obviously inefficient, but I am unsure if there is a better solution or not.
     * 
     * Interfaces cannot require constructors, and DateTime is immutable.
     * IDateTime is just a bunch of properties, each of which must be initialized individually.
     * Therefore, initializing hours, minutes, and seconds separately wastes two DateTime instances.
     * 
     * A potential solution would be to have interface methods specifying multiple values at once.
     * However, this seems to also cause interface bloat - why not have a method for every value combination?
     * 
     * Factory method doesn't solve the problem (creation complexity isn't the problem, and factory can't magically initialize more efficiently.)
     * 
     * In the end, there is little to be gained and much to be lost (more bloating and complexity.)
     * This is far from being any sort of bottleneck considering the nature of the application.
     */
    public class TimeTrackerDateTime : IDateTime
    {
        private DateTime Time { get; set; }

        public int Hours
        {
            get
            {
                return Time.Hour;
            }
            set
            {
                Time = new DateTime(1, 1, 1, value, Minutes, Seconds);
            }
        }

        public int Minutes
        {
            get
            {
                return Time.Minute;
            }
            set
            {
                Time = new DateTime(1, 1, 1, Hours, value, Seconds);
            }
        }

        public int Seconds
        {
            get
            {
                return Time.Second;
            }
            set
            {
                Time = new DateTime(1, 1, 1, Hours, Minutes, value);
            }
        }

        public TimeTrackerDateTime(int hours, int minutes, int seconds)
        {
            Time = new DateTime(1, 1, 1, hours, minutes, seconds);
        }

        public object Clone()
        {
            return new TimeTrackerDateTime(Hours, Minutes, Seconds);
        }

        public IDateTime Difference(IDateTime subtrahendTime)
        {
            int secondsDifference = Seconds - subtrahendTime.Seconds;
            int minutesDifference = Minutes - subtrahendTime.Minutes;
            int hoursDifference = Hours - subtrahendTime.Hours;

            if (secondsDifference < 0)
            {
                secondsDifference += 60;
                minutesDifference -= 1;
            }

            if (minutesDifference < 0)
            {
                minutesDifference += 60;
                hoursDifference -= 1;
            }

            if (hoursDifference < 0)
            {
                throw new ArgumentException("subtrahendTime was earlier than the caller IDateTime's time.");
            }

            return new TimeTrackerDateTime(hoursDifference, minutesDifference, secondsDifference);
        }

        public override string ToString()
        {
            return $"{Hours}:{Minutes:00}:{Seconds:00}";
        }
    }
}