using outliers.DataModel;
using System.Collections.Generic;

namespace outliers.IO.Dumper
{
    public interface IDataDumper
    {
        /// <summary>
        /// Writre the entire <see cref="dataSet"/> to the <see cref="path"/>
        /// </summary>
        void Write(IReadOnlyList<IData> dataSet, string path);
    }
}
