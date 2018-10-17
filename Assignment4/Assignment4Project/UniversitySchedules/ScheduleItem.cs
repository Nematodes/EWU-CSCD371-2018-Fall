using System;

namespace BrianBosAssignment4Namespace
{
    public abstract class ScheduleItem : ISummarizable
    {
        public String Name { get; set; }

        private int _NumberOfAttendees;
        public int NumberOfAttendees
        {
            get
            {
                return _NumberOfAttendees;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The number of attendees cannot be less than 0.");
                }
                else
                {
                    _NumberOfAttendees = value;
                }
            }
        }

        public ScheduleItem(string name, int numberOfAttendees)
        {
            Name = name;
            NumberOfAttendees = numberOfAttendees;
        }

        public abstract string GetSummaryInformation();
    }
}
