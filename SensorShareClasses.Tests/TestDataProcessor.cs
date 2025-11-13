using SensorDataApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorShareClasses.Tests
{
    internal class TestDataProcessor : DataProcessor
    {
        private static TestDataProcessor instance;
        private List<TestSensorData> loadedData;
        new private int currentDatasetIndex;

        private TestDataProcessor()
        {
            loadedData = new List<TestSensorData>();
            currentDatasetIndex = 0;
        }

        new public static TestDataProcessor getInstance()
        {
            if (instance == null)
            {
                instance = new TestDataProcessor();
            }
            return instance;
        }
        public void LoadDataForTest(TestSensorData data)
        {
            loadedData.Add(data);
        }

        public float CallAverage(SensorData data)
        {
            return calculateAverage(data);
        }

        public float CallSV(SensorData data)
        {
            return calculateStandardVariance(data);
        }
    }
}
