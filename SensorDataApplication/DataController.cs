using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorDataApplication
{
    internal class DataController
    {
        private readonly DataProcessor processor;
        private SensorData currentData;
        private string dataDirectory;

        public DataController(DataProcessor processor)
        {
            this.processor = processor;
            SetDirectory();
        }

        public SensorData GetData()
        {
            return currentData;
        }

        public string GetDirectory()
        {
            return dataDirectory;
        }

        private void SetDirectory()
        {
            dataDirectory = Path.Combine(AppContext.BaseDirectory, "data");
        }

        public (int,int) GetLoadedDataPosition()
        {
            int index = processor.GetCurrentIndex();
            int count = processor.GetLoadedCount();
            return (index, count);
        }

        public SensorData onLoad(string metaFilePath)
        {
            currentData = processor.loadfromMetaData(metaFilePath);
            return currentData;
        }

        public void onSave(string metaFilePath)
        {
            if (currentData != null)
            {
                processor.saveData(currentData,metaFilePath);
            }
        }

        public SensorData NextDataset()
        {
            currentData = processor.ChangeDataset(2);
            return currentData;
        }

        public SensorData PrevDataset()
        {
            currentData = processor.ChangeDataset(1);
            return currentData;
        }

        public (ValueIndex, string message) SearchNearest(float target)
        {
            ValueIndex result = processor.binarySearchNearest(target);
            double within3decimals = Math.Round(result.searchVariance, 3);
            if (result.searchVariance == 0 || within3decimals == 0)
            {
                return (result, "Match Found");
            }
            else if (result.searchVariance < currentData.getSV())
            {
                return (result, "Closest Match Found\n(Within Standard Variance)");
            }
            else
            {
                return (null, "No Close Match Found");
            }
        }
    }
}
