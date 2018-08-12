using System;
using System.IO;

namespace outliers.IO.Dumper
{
    public static class DataDumperFactory
    {
        public static IDataDumper GetDumper(string path)
        {
            var extension = Path.GetExtension(path).ToLower();

            switch (extension)
            {
                case ".csv":
                    return new CsvDataDumper();

                default:
                    throw new NotSupportedException(string.Format("File type not supported: {0}", extension));
            }
        }
    }
}
