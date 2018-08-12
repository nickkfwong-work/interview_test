using CsvHelper;
using outliers.DataModel;
using System;
using System.Collections.Generic;
using System.IO;

namespace outliers.IO.Dumper
{
    public class CsvDataDumper : IDataDumper
    {
        public void Write(IReadOnlyList<IData> dataSet, string outputPath)
        {
            outputPath = RenameFile(outputPath);
            Console.WriteLine("[{0}] Dumping data to {1}", DateTime.Now, outputPath);

            // Todo: add file IO error handling here
            using (var sw = new StreamWriter(outputPath))
            {
                using (var writer = new CsvWriter(sw))
                {
                    writer.WriteRecords(dataSet);
                }
            }   
        }

        private string RenameFile(string source)
        {
            var directory = Path.GetDirectoryName(source);
            var fileName = Path.GetFileNameWithoutExtension(source);
            
            // must be csv on csb dumper
            var outputFile = string.Format("{0}-{1}.csv", fileName, "clean");

            return string.Format("{0}\\{1}", directory, outputFile);
        }
    }
}
