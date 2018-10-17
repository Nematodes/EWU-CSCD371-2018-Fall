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
                return base.NumberOfAttendees + this.NumberOfWaitlistedAttendees;
            }
        }

        public UniversityCourse() : this("Unnamed Course", 0, "Thursday, 1 January 1970", "Monday, 5 January 1970", 5, 0)
        {

        }

        public UniversityCourse(string name, int numberOfAttendees, string startDate, string endDate, int creditHours, int numberOfWaitlistedAttendees) : base(name, numberOfAttendees)
        {
            StartDate = startDate;
            EndDate = endDate;
            CreditHours = creditHours;
            NumberOfWaitlistedAttendees = numberOfWaitlistedAttendees;
        }

        public override string GetSummaryInformation()
        {
            throw new NotImplementedException();
        }
    }
}
