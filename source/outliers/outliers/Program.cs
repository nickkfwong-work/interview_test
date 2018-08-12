using outliers.IO.Dumper;
using outliers.IO.Loader;
using outliers.Processor;
using outliers.Stat;
using System;
using System.IO;

namespace outliers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // note: we assume input args are valid full paths and does not include error handling here.
            if (args.Length < 1)
            {
                Console.WriteLine("Please specfiy an input path and retry...");
                Console.ReadLine();
                return;
            }

            // Data input
            var inputPath = Path.GetFullPath(args[0]);
            var loader = DataLoaderFactory.GetLoader(inputPath);

            var allData = loader.Load(inputPath);

            Statistics.Instance.LoadedCount = allData.Count;

            // Process data set
            // - Here simply define a single validator that takes away data points who have significantly changed 
            //   over the previous date's data.
            // - To add other criteria against 'outlier', implement such referenced-criteria on enriched data
            //   and validate against that criteria. 
            var proc = new EnrichDataProcessor(new[] { new IntradayPriceReturn5PercentValidator() });
            var result = proc.Process(allData);

            Statistics.Instance.ValidatedCount = result.Count;

            // Data output
            var outputPath = args.Length == 2 ? Path.GetFullPath(args[1]) : inputPath;

            var dumper = DataDumperFactory.GetDumper(outputPath);
            dumper.Write(result, outputPath);

            // Print statistics
            Console.WriteLine("[{0}] Completed. Details:\n", DateTime.Now);
            Console.WriteLine(Statistics.Instance.ToString());

            Console.WriteLine("Press any key to close...");
            Console.ReadLine();
        }
    }
}
