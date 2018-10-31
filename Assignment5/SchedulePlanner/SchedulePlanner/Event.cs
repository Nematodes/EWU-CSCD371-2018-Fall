using System;

namespace BrianBosAssignmentFive
{
    public class Event : ScheduleItem
    {
        public string Date { get; set; }

        public Event() : this("Unnamed Event", 0, "Thursday, 1 January 1970")
        {

        }

        public Event(string name, int numberOfAttendees, string date) : base(name, numberOfAttendees)
        {
            Date = date;
        }

        public override string GetSummaryInformation()
        {
            return $"Event name: {Name}{Environment.NewLine}Number of attendees: {NumberOfAttendees}{Environment.NewLine}Date: {Date}";
        }
    }
}