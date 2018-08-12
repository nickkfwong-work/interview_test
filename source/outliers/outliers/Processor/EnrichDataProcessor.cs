using outliers.DataModel;
using outliers.Processor.Validation;
using outliers.Stat;
using System;
using System.Collections.Generic;
using System.Linq;

namespace outliers.Processor
{
    /// <summary>
    /// Process a simple dataset and return an enriched dataset
    /// </summary>
    public class EnrichDataProcessor : IProcessor
    {
        IValidator<EnrichedData>[] enrichedDataValidators;

        public EnrichDataProcessor(IValidator<EnrichedData>[] enrichedDataValidators)
        {
            this.enrichedDataValidators = enrichedDataValidators;
        }

        public IReadOnlyList<IData> Process(IReadOnlyList<IData> dataSet)
        {
            Console.WriteLine("[{0}] Processing data set", DateTime.Now);

            var enrichedSet = new List<IData>(dataSet.Count);

            for (var i = 0; i < dataSet.Count; i++)
            {
                var data = dataSet[i];
                
                var enriched = new EnrichedData
                {
                    Date = data.Date,
                    Price = data.Price,
                    IntradayPriceReturn = CalculatePriceReturn(dataSet, i)
                };

                // internal validator on each single enriched data before adding to result set
                if (enrichedDataValidators.All(validator => validator.Validate(enriched)))
                {
                    enrichedSet.Add(enriched);
                }
                else
                {
                    Statistics.Instance.TrackOutliers(enriched);
                };                
            }

            return enrichedSet;
        }
        
        /// <summary>
        /// PriceReturn is calculated as the intra-day price change
        /// </summary>
        private double CalculatePriceReturn(IReadOnlyList<IData> dataSet, int currentIdx)
        {
            if (currentIdx == 0)
            {
                return 0;
            }
            else
            {
                var currentData = dataSet[currentIdx];
                var prevPrice = dataSet[currentIdx - 1].Price;
                
                return (currentData.Price - prevPrice) / prevPrice;
            }
        }
    }
}
