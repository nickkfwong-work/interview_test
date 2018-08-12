using outliers.DataModel;
using System.Collections.Generic;

namespace outliers.IO.Loader
{
    public interface IDataLoader
    {
        /// <summary>
        /// Load the dataset from <see cref="path"/>
        /// </summary>
        IReadOnlyList<IData> Load(string path);
    }
}
