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
            currentDatasetIndex = loadedData.IndexOf(data);
        }

        new public SensorData ChangeDataset(int nextOrPrevFlag)
        {
            if (nextOrPrevFlag == 1) // Previous
            {
                if (currentDatasetIndex == 0)
                {
                    return null;
                }
                currentDatasetIndex = currentDatasetIndex - 1;
                return loadedData[currentDatasetIndex];
            }
            if (nextOrPrevFlag == 2) // Next
            {
                if (currentDatasetIndex + 1 < loadedData.Count())
                {
                    currentDatasetIndex = currentDatasetIndex + 1;
                    return loadedData[currentDatasetIndex];
                }
                else
                {
                    return null;
                }
            }
            else // Safety Catch
            {
                return null;
            }
        }

        new public ValueIndex binarySearchNearest(float searchTarget)
        {
            SensorData currentDataset = loadedData[currentDatasetIndex];
            float[,] dataSearchField = currentDataset.getValues();
            List<ValueIndex> sortedData = buildSortedList(dataSearchField);

            int low = 0, high = sortedData.Count - 1;

            int bestMatchIndex = -1;
            float bestMatchVariance = float.MaxValue;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                ValueIndex middleValue = sortedData[mid];

                float currentMatchVariance = Math.Abs(middleValue.value - searchTarget); // Math.Abs ensures no negative values

                //Search for best match if no exact
                if (currentMatchVariance < bestMatchVariance)
                {
                    bestMatchVariance = currentMatchVariance;
                    bestMatchIndex = mid;
                }

                //Continue searching for exact match
                if (middleValue.value == searchTarget)
                {
                    middleValue.searchVariance = 0;
                    return middleValue;
                }
                else if (middleValue.value < searchTarget)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            if (bestMatchIndex < 0)
            {
                return null;
            }
            ValueIndex nearestMatch = sortedData[bestMatchIndex];
            nearestMatch.searchVariance = bestMatchVariance;
            return nearestMatch;
        }

        public float CallAverage(SensorData data)
        {
            return calculateAverage(data);
        }

        public float CallSV(SensorData data)
        {
            return calculateStandardVariance(data);
        }

        public void CallSave(SensorData data, string filePath)
        {
            saveData(data, filePath);
        }

        public SensorData CallLoad(string filePath)
        {
            return loadfromMetaData(filePath);
        }

        public (float, int, int, float) CallSearch(float search)
        {
            var result = binarySearchNearest(search);
            return (result.value, result.row, result.col, result.searchVariance);
        }

        public SensorData CallDataChange(int flag)
        {
            return ChangeDataset(flag);
        }
    }
}
