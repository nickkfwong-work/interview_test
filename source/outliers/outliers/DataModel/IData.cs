using System;

namespace outliers.DataModel
{
    /// <summary>
    /// The core-data model for data set present on the input/output file
    /// </summary>
    public interface IData
    {
        DateTime Date { get; }
        double Price { get; }
    }
}
