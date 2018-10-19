using System;

namespace BrianBosAssignment4Namespace
{
    public class UniversityCourse : ScheduleItem
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public int CreditHours
        {
            get;
        }

        private int _NumberOfWaitlistedAttendees;
        public int NumberOfWaitlistedAttendees
        {
            get
            {
                return _NumberOfWaitlistedAttendees;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The number of waitlisted attendees cannot be less than 0.");
                }
                else
                {
                    _NumberOfWaitlistedAttendees = value;
                }
            }
        }

        public int TotalAttendingStudents
        {
            get
            {
                return NumberOfAttendees + NumberOfWaitlistedAttendees;
            }
        }

        public string WeeklySchedule { get; set; }

        public UniversityCourse() : this("Unnamed Course", 0, "Thursday, 1 January 1970", "Monday, 5 January 1970", 5, 0, "N/A")
        {

        }

        public UniversityCourse(string name, int numberOfAttendees, string startDate, string endDate, int creditHours, int numberOfWaitlistedAttendees, string weeklySchedule) : base(name, numberOfAttendees)
        {
            StartDate = startDate;
            EndDate = endDate;
            CreditHours = creditHours;
            NumberOfWaitlistedAttendees = numberOfWaitlistedAttendees;
            WeeklySchedule = weeklySchedule;
        }

        public void Deconstruct(out string name, out int numberOfAttendees, out string startDate, out string endDate, out int creditHours, out int numberOfWaitlistedAttendees, out string weeklySchedule)
        {
            (name, numberOfAttendees, startDate, endDate, creditHours, numberOfWaitlistedAttendees, weeklySchedule) = (Name, NumberOfAttendees, StartDate, EndDate, CreditHours, NumberOfWaitlistedAttendees, WeeklySchedule);
        }

        public override string GetSummaryInformation()
        {
            return $@"Course name: {Name}{Environment.NewLine
                     }Enrolled students: {NumberOfAttendees}{Environment.NewLine
                     }Waitlisted students: {NumberOfWaitlistedAttendees}{Environment.NewLine
                     }Start date: {StartDate}{Environment.NewLine
                     }End date: {EndDate}{Environment.NewLine
                     }Credit hours: {CreditHours}{Environment.NewLine
                     }Weekly schedule: {WeeklySchedule}";
        }
    }
}