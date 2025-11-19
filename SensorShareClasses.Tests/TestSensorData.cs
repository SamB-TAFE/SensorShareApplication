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
            testMeta.file = "testdata.bin";
            testMeta.rows = 3;
            testMeta.cols = 3;
            testMeta.row_labels = new string[] { "row1", "row2", "row3" };
            testMeta.col_labels =  new string[] { "col1", "col2", "col3" };

            return new TestSensorData(testMeta,testData);
        }

        public static TestSensorData MakeSecondTestData()
        {
            float[,] testData = new float[,]
            {
                { 10.0f, 20.0f, 30.0f },
                { 40.0f, 50.0f, 60.0f },
                { 70.0f, 80.0f, 90.0f }
            };
            MetaData testMeta = new MetaData();
            testMeta.file = "testdata2.bin";
            testMeta.rows = 3;
            testMeta.cols = 3;
            testMeta.row_labels = new string[] { "rowA", "rowB", "rowC" };
            testMeta.col_labels = new string[] { "colA", "colB", "colC" };

            return new TestSensorData(testMeta, testData);
        }
    }
}
