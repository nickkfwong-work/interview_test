using outliers.DataModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace outliers.Stat
{
    /// <summary>
    ///  A simple tracker on processing result
    /// </summary>
    public class Statistics
    {
        private static Statistics instance;
        private static StringBuilder sb = new StringBuilder();

        private Statistics()
        {
        }

        /// <summary>
        /// Count of all data loaded
        /// </summary>
        public int LoadedCount { get; set; }

        /// <summary>
        /// Count of all data loaded which are validated
        /// </summary>
        public int ValidatedCount { get; set; }

        /// <summary>
        /// Count of all outliers identified
        /// </summary>
        public int OutliersCount { get; private set; }

        private IList<IData> outliers = new List<IData>();

        public void TrackOutliers(IData data)
        {
            outliers.Add(data);
            OutliersCount++;
        }

        public static Statistics Instance
        {
            get { return instance ?? (instance = new Statistics()); }
        }

        public override string ToString()
        {
            var outliersDetails = string.Join("\n", outliers.Select(d => d.ToString()));

            var message = sb
                .AppendFormat("Loaded Count:{0}", LoadedCount)
                .AppendLine()
                .AppendFormat("Validated Count:{0}", ValidatedCount)
                .AppendLine()
                .AppendFormat("Outliers:")
                .AppendLine()
                .Append(outliersDetails).ToString();

            sb.Clear();

            return message;
        }
    }
}
