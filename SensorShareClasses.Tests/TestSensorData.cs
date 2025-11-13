using SensorDataApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorShareClasses.Tests
{
    public class TestSensorData : SensorData
    {
        private float[,] values;
        public TestSensorData(MetaData meta, float[,] binaryValues) : base(meta, binaryValues)
        {
            metaData = meta;
            values = binaryValues;
        }

        public static TestSensorData MakeTestData()
        {
            float[,] testData = new float[,]
            {
                { 1.0f, 2.0f, 3.0f },
                { 4.0f, 5.0f, 6.0f },
                { 7.0f, 8.0f, 9.0f }
            };
            MetaData testMeta = new MetaData();
            testMeta.rows = 3;
            testMeta.cols = 3;
            testMeta.row_labels = new string[] { "row1", "row2", "row3" };
            testMeta.col_labels =  new string[] { "col1", "col2", "col3" };

            return new TestSensorData(testMeta,testData);
        }
    }
}
