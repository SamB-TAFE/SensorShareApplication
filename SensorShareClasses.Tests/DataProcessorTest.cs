using SensorDataApplication;
namespace SensorShareClasses.Tests
{
    [TestClass]
    public sealed class DataProcessorTest
    {

        [TestMethod]
        public void TestAverageMethod()
        {
            TestDataProcessor dataProcessor = TestDataProcessor.getInstance();

            TestSensorData testData = TestSensorData.MakeTestData();

            float result = dataProcessor.CallAverage(testData);

            Assert.AreEqual(5, result);    
        }

        public void TestSVMethod()
        {
            TestDataProcessor dataProcessor = TestDataProcessor.getInstance();

            TestSensorData testData = TestSensorData.MakeTestData();

            float result = dataProcessor.CallSV(testData);

            Assert.AreEqual(2.58, Math.Round(result,2));
        }


    }
}

