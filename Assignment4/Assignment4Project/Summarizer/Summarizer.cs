using System;

/*
 * The reason for Summarizer having its own project (thereby warranting its unit tests having another separate project)
 * is that it acts more like an application using the "ScheduleItems" project libraries.
 * 
 * Obviously, the above is a pretend scenario. The main method here is blank,
 * and DisplaySummaries() isn't actually used by other applications.
 */

namespace BrianBosAssignment4Namespace
{
    public static class Summarizer
    {
        public static void Main()
        {
            // A blank Main method that exists solely to stop the compiler from complaining
        }

        /*
         * In terms of functionality, the "Event" case isn't needed at all.
         * It was included to demonstrate pattern matching.
         */
        public static string DisplayObjectSummary(Object inputObject)
        {
            switch (inputObject)
            {
                case Event inputEvent:
                    return inputEvent.GetSummaryInformation();

                case ScheduleItem inputScheduleItem:
                    return inputScheduleItem.GetSummaryInformation();

                case object inputUnrelatedObject:
                    return inputUnrelatedObject.ToString();

                default:
                    return inputObject.ToString();
            }
        }

        public static string DisplaySummarizableObjectSummary(ISummarizable summarizableObject)
        {
            return summarizableObject.GetSummaryInformation();
        }
    }
}
