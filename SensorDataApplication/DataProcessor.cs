using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SensorDataApplication
{

    internal class DataProcessor
    {
        private DataProcessor instance;
        private List<SensorData> loadedData;
        private int currentDatasetIndex;

        public DataProcessor getInstance()
        {
            if (instance == null)
            {
                instance = new DataProcessor();
                return instance;
            }
            else
            {
                return instance;
            }
        }

        public SensorData loadfromMetaData(string filePath)
        {
            string jsonText = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            MetaData meta = JsonSerializer.Deserialize<MetaData>(jsonText, options);

            SensorData newData = loadBinary(meta, filePath);

            return newData;
        }

        private SensorData loadBinary(MetaData metaData, string parentFilePath)
        {
            string binaryPath = Path.Combine(Path.GetDirectoryName(parentFilePath), metaData.file);

            if (!File.Exists(binaryPath))
                throw new FileNotFoundException($"Binary file not found: {binaryPath}");

            float[,] values = new float[metaData.rows, metaData.cols];

            using (FileStream stream = new FileStream(binaryPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                for (int r = 0; r < metaData.rows; r++)
                {
                    for (int c = 0; c < metaData.cols; c++)
                    {
                        values[r,c] = reader.ReadSingle();
                    }
                }
            }

            SensorData newData = new SensorData(metaData, values);
            newData.setAverage(calculateAverage(newData));
            loadedData.Add(newData);
            currentDatasetIndex = loadedData.IndexOf(newData);
            return newData;
        }

        public void saveData(SensorData data, string filePath)
        {
            float[,] rawValues = data.getValues();
            if (data == null || rawValues == null)
                throw new ArgumentNullException(nameof(data), "SensorData or its values cannot be null.");

            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                for (int r = 0; r < data.metaData.rows; r++)
                {
                    for (int c = 0; c < data.metaData.cols; c++)
                    {
                        bw.Write(rawValues[r, c]);
                    }
                }
            }
        }

        private float calculateAverage(SensorData data)
        {
            float[,] values = data.getValues();

            int rows = values.GetLength(0);
            int cols = values.GetLength(1);

            double sum = 0;
            int count = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    sum += values[r, c];
                    count++;
                }
            }

            float average = (float)(sum / count);
            return average;

        }

        public ValueIndex binarySearch(float searchTarget)
        {
            SensorData currentDataset = loadedData[currentDatasetIndex];
            float[,] dataSearchField = currentDataset.getValues();
            List<ValueIndex> sortedData = buildSortedList(dataSearchField);

            int low = 0, high = sortedData.Count - 1;

            while (low <= high)
            {
                int mid = low + high / 2;
                
                ValueIndex middleValue = sortedData[mid];

                if(middleValue.value == searchTarget)
                {
                    middleValue.searchVariance = 0;
                    return middleValue;
                }
                else if ()
                else if (middleValue.value < searchTarget)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }


        }

        private List<ValueIndex> buildSortedList(float[,] values)
        {
            int rows = values.GetLength (0);
            int cols = values.GetLength (1);
            List<ValueIndex> sortedValues = new List<ValueIndex>(rows*cols);

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    sortedValues.Add(new ValueIndex(values[r, c], r, c));
                }
                    
            }
            sortedValues.Sort(CompareValues);
            return sortedValues; 
        }
        int CompareValues(ValueIndex a, ValueIndex b)
        {
            return a.value.CompareTo(b.value);
        }


    }
}
