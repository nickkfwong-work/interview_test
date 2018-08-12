using outliers.DataModel;
using System.Collections.Generic;

namespace outliers.Processor
{
    public interface IProcessor
    {
        /// <summary>
        /// Process a list of data and return a list of data
        /// </summary>
        IReadOnlyList<IData> Process(IReadOnlyList<IData> data);
    }
}
