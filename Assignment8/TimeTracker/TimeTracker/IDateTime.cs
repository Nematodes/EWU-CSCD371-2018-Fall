using System;

namespace BrianBosAssignmentEight
{
    public interface IDateTime : ICloneable
    {
        int Hours { get; set; }

        int Minutes { get; set; }

        int Seconds { get; set; }

        IDateTime Difference(IDateTime subtrahendTime);
    }
}