using System;

namespace BrianBosAssignmentSix
{
    public struct Schedule
    {
        [Flags]
        public enum DayName : byte
        {
            None      = 0x0,
            Monday    = 0x1,
            Tuesday   = 0x2,
            Wednesday = 0x4,
            Thursday  = 0x8,
            Friday    = 0x10,
            Saturday  = 0x20,
            Sunday    = 0x40
        }

        public enum CollegeQuarter : byte
        {
            None,
            Spring,
            Summer,
            Fall,
            Winter
        }

        public DayName DayOfWeek { get; }

        public CollegeQuarter Quarter { get; }

        public ClockTime StartTime { get; }

        public TimeSpan Duration { get; }

        public Schedule(DayName dayOfWeek, CollegeQuarter quarter, ClockTime startTime, TimeSpan duration)
        {
            DayOfWeek = dayOfWeek;
            Quarter = quarter;
            StartTime = startTime;
            Duration = duration;
        }

        // Since parsing dayOfWeek involves some processing, the standard constructor (DayName, CollegeQuarter, ClockTime, TimeSpan) cannot be called for this
        public Schedule(string dayOfWeek, CollegeQuarter quarter, ClockTime startTime, TimeSpan duration)
        {
            Enum.TryParse<DayName>(dayOfWeek, out DayName tempDayName); // tempDayName is guaranteed to contain the default DayName value ("None") if parsing fails

            DayOfWeek = tempDayName;
            Quarter = quarter;
            StartTime = startTime;
            Duration = duration;
        }

        public Schedule(DayName dayOfWeek, string quarter, ClockTime startTime, TimeSpan duration)
        {
            Enum.TryParse<CollegeQuarter>(quarter, out CollegeQuarter tempCollegeQuarter);

            DayOfWeek = dayOfWeek;
            Quarter = tempCollegeQuarter;
            StartTime = startTime;
            Duration = duration;
        }
    }
}
