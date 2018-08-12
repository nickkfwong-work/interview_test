using System;

namespace outliers.DataModel
{
    /// <summary>
    /// The core-data model for data set present on the input/output file
    /// </summary>
    public class Data : IData
    {
        public DateTime Date { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return string.Format("Date:{0} Price:{1}", Date, Price);
        }
    }

    /// <summary>
    /// An enriched model that includes derived properties base on the core-data
    /// </summary>
    public class EnrichedData : Data
    {
        public double IntradayPriceReturn { get; set; }

        public override string ToString()
        {
            return string.Format("{0} IntradayPriceReturn:{1}", base.ToString(), IntradayPriceReturn);
        }
    }
}
