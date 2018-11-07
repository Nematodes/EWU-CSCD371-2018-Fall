using System;

namespace BrianBosAssignmentSix
{
    public struct ClockTime
    {
        public byte Hours { get; }

        public byte Minutes { get; }

        public byte Seconds { get; }

        public ClockTime(byte hours, byte minutes, byte seconds)
        {
            if (hours > 23)
            {
                Hours = 23;
            }
            else
            {
                Hours = hours;
            }

            if (minutes > 59)
            {
                Minutes = 59;
            }
            else
            {
                Minutes = minutes;
            }

            if (seconds > 59)
            {
                Seconds = 59;
            }
            else
            {
                Seconds = seconds;
            }
        }
    }
}