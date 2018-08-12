using Moq;
using NUnit.Framework;
using outliers.DataModel;
using outliers.Processor;
using outliers.Processor.Validation;
using outliers.Stat;
using System;
using System.Collections.Generic;

namespace outliers.Test.Processor
{
    // Todo: add more testcases ;-)
    [TestFixture]
    public class EnrichDataProcessorTest
    {
        private IValidator<EnrichedData> alwaysMatchValidator;
        private IReadOnlyList<Data> dataSet;

        [OneTimeSetUp]
        public void SetupFixture()
        {
            dataSet = new List<Data>
            {
                new Data { Date = DateTime.Today, Price = 1.0 },
                new Data { Date = DateTime.Today.AddDays(1), Price = 1.2 }
            };

            var validatorMock = new Mock<IValidator<EnrichedData>>();
            validatorMock.Setup(v => v.Validate(It.IsAny<EnrichedData>())).Returns(true);

            alwaysMatchValidator = validatorMock.Object;
        }

        [Test]
        public void TestSimpleEnrichData()
        {
            var processor = new EnrichDataProcessor(new[] { alwaysMatchValidator });
            var enrichedDataSet = processor.Process(dataSet);

            Assert.That(enrichedDataSet.Count, Is.EqualTo(2));

            // We use date as identifier for testing because of precision issue on Price value
            Assert.That(((EnrichedData)enrichedDataSet[0]).Date, Is.EqualTo(DateTime.Today));
            Assert.That(((EnrichedData)enrichedDataSet[1]).Date, Is.EqualTo(DateTime.Today.AddDays(1)));
        }

        [Test]
        public void TestOutlierData()
        {
            var processor = new EnrichDataProcessor(new[] { new IntradayPriceReturn5PercentValidator() });
            var enrichedDataSet = processor.Process(dataSet);

            Assert.That(Statistics.Instance.OutliersCount, Is.EqualTo(1));
            Assert.That(enrichedDataSet.Count, Is.EqualTo(1));
            Assert.That(((EnrichedData)enrichedDataSet[0]).Date, Is.EqualTo(DateTime.Today));
        }
    }
}
