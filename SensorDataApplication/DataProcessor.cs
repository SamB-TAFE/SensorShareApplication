using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SensorDataApplication
{

    internal class DataProcessor
    {
        private static DataProcessor instance;
        private List<SensorData> loadedData;
        protected int currentDatasetIndex;

        protected DataProcessor()
        {
            loadedData = new List<SensorData>();
            currentDatasetIndex = 0;
        }

        public static DataProcessor getInstance()
        {
            if (instance == null)
            {
                instance = new DataProcessor();
            }
            return instance;
        }

        public int GetCurrentIndex()
        {
            return currentDatasetIndex;
        }
        public int GetLoadedCount()
        {
            return loadedData.Count;
        }

        public SensorData GetCurrent()
        {
            return loadedData[currentDatasetIndex];
        }
        public SensorData ChangeDataset(int nextOrPrevFlag)
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

        public void saveData(SensorData data, string metaFilePath)
        {
            string metaBase = Path.GetFileNameWithoutExtension(metaFilePath);
            string binName = metaBase + ".bin";

            data.metaData.file = binName;

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };

            string jsonText = JsonSerializer.Serialize(data.metaData, options);
            File.WriteAllText(metaFilePath, jsonText);
          

            string binaryFilePath = Path.Combine(Path.GetDirectoryName(metaFilePath), data.metaData.file);

            saveDataBinary(data, binaryFilePath);
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

        protected SensorData loadBinary(MetaData metaData, string parentFilePath)
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
            newData.setSV(calculateStandardVariance(newData));
            CheckMetaData(newData);
            loadedData.Add(newData);
            currentDatasetIndex = loadedData.IndexOf(newData);
            return newData;
        }

        public void saveDataBinary(SensorData data, string filePath)
        {
            float[,] rawValues = data.getValues();

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

        protected void CheckMetaData(SensorData data)
        {
            float[,] values = data.getValues();

            int rows = values.GetLength(0);
            int cols = values.GetLength(1);

            if (data.metaData.rows != rows)
            {
                data.metaData.rows = rows;
            }
            if (data.metaData.cols != cols)
            {
                data.metaData.cols = cols;
            }


            // if there is a mismatch create empty string array of appropriate length.

            string[] rowHeaders = data.metaData.row_labels;
            if (rowHeaders.Length != rows)
            {
                rowHeaders = new string[rows];
                for (int i = 0; i < rows; i++)
                {
                    rowHeaders[i] = "";
                }
            }

            string[] colHeaders = data.metaData.col_labels;
            if (colHeaders.Length != cols)
            {
                colHeaders = new string[cols];
                for (int i = 0; i < cols; i++)
                {
                    colHeaders[i] = "";
                }
            }
        }

        protected float calculateAverage(SensorData data)
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

        protected float calculateStandardVariance(SensorData data)
        {
            float[,] values = data.getValues();
            float average = data.getAverage();

            int rows = values.GetLength(0);
            int cols = values.GetLength(1);

            double squaredDeviationSum = 0;
            int count = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    float deviation = values[r, c] - average;
                    float deviationSquared = deviation * deviation;
                    squaredDeviationSum += deviationSquared;
                    count++;
                }
            }

            double variance = (squaredDeviationSum / count);
            float standardVariance = (float)Math.Sqrt(variance);
            return standardVariance;

        }

        public ValueIndex binarySearchNearest(float searchTarget)
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
                if(currentMatchVariance < bestMatchVariance)
                {
                    bestMatchVariance = currentMatchVariance;
                    bestMatchIndex = mid;
                }

                //Continue searching for exact match
                if(middleValue.value == searchTarget)
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

        protected List<ValueIndex> buildSortedList(float[,] values)
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
