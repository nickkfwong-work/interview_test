using System.Collections.Generic;
using System.IO;
using outliers.DataModel;
using CsvHelper;
using System.Linq;
using System;

namespace outliers.IO.Loader
{
    /// <summary>
    /// Load a csv file and return the data set in a list
    /// </summary>
    public class CsvDataLoader : IDataLoader
    {
        public IReadOnlyList<IData> Load(string inputPath)
        {
            Console.WriteLine("[{0}] Loading from {1}", DateTime.Now, inputPath);

            // Todo: add file IO error handling here
            using (var sr = new StreamReader(inputPath))
            {
                using (var reader = new CsvReader(sr))
                {
                    // We assume header name is the same as field name. Otherwise a mapping is needed.
                    var records = reader.GetRecords<Data>();
                    return records.ToList();
                }
            }
        }
    }
}
