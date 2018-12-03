using AddisonWesley.Michaelis.EssentialCSharp.Chapter15.Listing15_10;
using System;
using System.Collections.Generic;
using System.Linq;

/*
 * Namespaces are named after project names. However, since each project only contains one C# file due to the nature of the assignment,
 * the project is named identically to the C# file it contains (which is named identically to to the class it contains.)
 * As a result, namespaces happen to be named after the C# files they contain.
 */
namespace BrianBosAssignmentNine.PatentDataAnalyzer
{
    public static class PatentDataAnalyzer
    {
        public static List<string> InventorLastNames()
        {
            return PatentData.Inventors
                             .OrderByDescending(inventor => inventor.Id)
                             .Select(inventor => inventor.Name.Split().Last())
                             .ToList();
        }

        public static List<string> InventorNames(string country)
        {
            if (country is null)
            {
                throw new ArgumentNullException("Parameter \"country\" in method InventorNames(string country) was null!");
            }

            return PatentData.Inventors
                             .Where(inventor => inventor.Country == country)
                             .Select(inventor => inventor.Name)
                             .ToList();
        }

        public static string LocationsWithInventors()
        {
            /*
             * I considered (and attempted) separating out the individual steps involved here instead of concatenating them all.
             * However, the act of creating multiple placeholder variables to store intermediate results added lots of clutter, negating its potential readability.
             */
            return string.Join(", ", (PatentData.Inventors
                                                .Select(inventor => inventor.State + "-" + inventor.Country))
                                                .Distinct()
                                                .ToList());
        }
    }
}