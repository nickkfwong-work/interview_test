using System;
using System.IO;

namespace outliers.IO.Loader
{
    public static class DataLoaderFactory
    {
        public static IDataLoader GetLoader(string path)
        {
            var extension = Path.GetExtension(path).ToLower();

            switch (extension)
            {
                case ".csv":
                    return new CsvDataLoader();

                default:
                    throw new NotSupportedException(string.Format("File type not supported: {0}", extension));
            }
        }
    }
}
