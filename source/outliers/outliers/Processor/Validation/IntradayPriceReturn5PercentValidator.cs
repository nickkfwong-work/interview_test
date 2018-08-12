using outliers.DataModel;
using outliers.Processor.Validation;
using System;

namespace outliers.Processor
{
    /// <summary>
    /// Check if <see cref="EnrichedData.IntradayPriceReturn"/> exceed a pre-determined thersold (0.5).
    /// </summary>
    public class IntradayPriceReturn5PercentValidator : IValidator<EnrichedData>
    {
        private const double limit = 0.05;

        public bool Validate(EnrichedData data)
        {
            return Math.Abs(data.IntradayPriceReturn) < limit;
        }
    }
}
