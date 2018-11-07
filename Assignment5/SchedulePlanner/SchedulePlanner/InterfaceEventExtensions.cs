using System;

namespace BrianBosAssignmentSix
{
    // The class "Event" and interface "IEvent" caused some interesting conflicts when deciding on a name for this
    public static class InterfaceEventExtensions
    {
        public static int SummaryLengthDifference(this IEvent minuendEvent, IEvent subtrahendEvent)
        {
            return minuendEvent.GetSummaryInformation().Length - subtrahendEvent.GetSummaryInformation().Length;
        }
    }
}