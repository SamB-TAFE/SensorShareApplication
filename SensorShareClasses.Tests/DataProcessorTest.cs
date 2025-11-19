using SensorDataApplication;
using System.Reflection.PortableExecutable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestMethod]
        public void TestAverageMethod2()
        {
            TestDataProcessor dataProcessor = TestDataProcessor.getInstance();

            TestSensorData testData = TestSensorData.MakeSecondTestData();

            float result = dataProcessor.CallAverage(testData);

            Assert.AreEqual(50, result);
        }

        [TestMethod]
        public void TestSVMethod()
        {
            TestDataProcessor dataProcessor = TestDataProcessor.getInstance();

            TestSensorData testData = TestSensorData.MakeTestData();

            testData.setAverage(dataProcessor.CallAverage(testData));

            float result = dataProcessor.CallSV(testData);

            Assert.AreEqual(2.58, Math.Round(result,2));
        }

        [TestMethod]
        public void TestSVMethod2()
        {
            TestDataProcessor dataProcessor = TestDataProcessor.getInstance();

            TestSensorData testData = TestSensorData.MakeSecondTestData();

            testData.setAverage(dataProcessor.CallAverage(testData));

            float result = dataProcessor.CallSV(testData);

            Assert.AreEqual(25.82, Math.Round(result, 2));
        }

        [TestMethod]
        public void TestSaveMethod()
        {
            TestDataProcessor dataProcessor = TestDataProcessor.getInstance();

            TestSensorData testData = TestSensorData.MakeTestData();

            dataProcessor.CallSave(testData, "C:\\Users\\samue\\Desktop\\TestSaveData\\testdata.json");

            Assert.IsTrue(File.Exists("C:\\Users\\samue\\Desktop\\TestSaveData\\testdata.bin") && File.Exists("C:\\Users\\samue\\Desktop\\TestSaveData\\testdata.json"));
        }

        [TestMethod]
        public void TestSaveMethod2()
        {
            TestDataProcessor dataProcessor = TestDataProcessor.getInstance();

            TestSensorData testData = TestSensorData.MakeSecondTestData();

            dataProcessor.CallSave(testData, "C:\\Users\\samue\\Desktop\\TestSaveData\\testdata2.json");

            Assert.IsTrue(File.Exists("C:\\Users\\samue\\Desktop\\TestSaveData\\testdata2.bin") && File.Exists("C:\\Users\\samue\\Desktop\\TestSaveData\\testdata2.json"));
        }

        [TestMethod]
        public void TestLoadMethod()
        {
            TestDataProcessor dataProcessor = TestDataProcessor.getInstance();

            SensorData testDataLoad = dataProcessor.CallLoad("C:\\Users\\samue\\Desktop\\TestSaveData\\testdata.json");

            TestSensorData testDataBase = TestSensorData.MakeTestData();

            Assert.IsTrue(DataisEqual(testDataLoad, testDataBase));
        }

        [TestMethod]
        public void TestLoadMethod2()
        {
            TestDataProcessor dataProcessor = TestDataProcessor.getInstance();

            SensorData testDataLoad = dataProcessor.CallLoad("C:\\Users\\samue\\Desktop\\TestSaveData\\testdata2.json");

            TestSensorData testDataBase = TestSensorData.MakeSecondTestData();

            Assert.IsTrue(DataisEqual(testDataLoad, testDataBase));
        }

        [TestMethod] 
        public void TestSearchMethod()
        {
            TestDataProcessor dataProcessor = TestDataProcessor.getInstance();

            TestSensorData testData = TestSensorData.MakeTestData();

            dataProcessor.LoadDataForTest(testData);

            (float result, int row, int col, float searchVar) = dataProcessor.CallSearch(5.12f);

            double roundedSearchVar = Math.Round((double)searchVar, 2);

            Assert.AreEqual(5.0f, result);
            Assert.AreEqual(1, row);
            Assert.AreEqual(1, col);
            Assert.AreEqual(0.12, roundedSearchVar);
        }

        [TestMethod]
        public void TestSearchMethod2()
        {
            TestDataProcessor dataProcessor = TestDataProcessor.getInstance();

            TestSensorData testData = TestSensorData.MakeSecondTestData();

            dataProcessor.LoadDataForTest(testData);

            (float result, int row, int col, float searchVar) = dataProcessor.CallSearch(63.43f);

            double roundedSearchVar = Math.Round((double)searchVar, 2);

            Assert.AreEqual(60.0f, result);
            Assert.AreEqual(1, row);
            Assert.AreEqual(2, col);
            Assert.AreEqual(3.43, roundedSearchVar);
        }

        [TestMethod]
        public void TestChangeDataMethodPrev()
        {
            TestDataProcessor dataProcessor = TestDataProcessor.getInstance();

            TestSensorData testDataFirst = TestSensorData.MakeTestData();

            TestSensorData testDataSecond = TestSensorData.MakeSecondTestData();


            dataProcessor.LoadDataForTest(testDataFirst);
            dataProcessor.LoadDataForTest(testDataSecond);

            TestSensorData testDataPrev = (TestSensorData)dataProcessor.CallDataChange(1);

            Assert.IsTrue(DataisEqual(testDataPrev,testDataFirst));
        }

        [TestMethod]
        public void TestChangeDataMethodNext()
        {
            TestDataProcessor dataProcessor = TestDataProcessor.getInstance();

            TestSensorData testDataFirst = TestSensorData.MakeTestData();

            TestSensorData testDataSecond = TestSensorData.MakeSecondTestData();


            dataProcessor.LoadDataForTest(testDataFirst);
            dataProcessor.LoadDataForTest(testDataSecond);

            TestSensorData testDataPrev = (TestSensorData)dataProcessor.CallDataChange(1);
            TestSensorData testDataNext = (TestSensorData)dataProcessor.CallDataChange(2);

            Assert.IsTrue(DataisEqual(testDataNext, testDataSecond));
        }

        public static bool DataisEqual(SensorData data1, SensorData data2)
        {
            Assert.IsNotNull(data1, "First dataset was null in DataisEqual");
            Assert.IsNotNull(data2, "Second dataset was null in DataisEqual");
            Assert.IsNotNull(data1.metaData, "First dataset metaData was null");
            Assert.IsNotNull(data2.metaData, "Second dataset metaData was null");

            if (data1.metaData.file != data2.metaData.file)
            {
                return false;
            }
            if (data1.metaData.rows != data2.metaData.rows)
            {
                return false;
            }
            if (data1.metaData.cols != data2.metaData.cols)
            {
                return false;
            }
            if (data1.metaData.cols != data2.metaData.cols)
            {
                return false;
            }

            for (int i = 0; i < data1.metaData.row_labels.Length; i++)
            {
                if (data1.metaData.row_labels[i] != data2.metaData.row_labels[i]) { return false; }
            }

            for (int i = 0; i < data1.metaData.col_labels.Length; i++)
            {
                if (data1.metaData.col_labels[i] != data2.metaData.col_labels[i]) { return false; }
            }

            float[,] data1Values = data1.getValues();
            float[,] data2Values = data2.getValues();

            for (int r = 0; r < data1.metaData.rows; r++)
            {
                for (int c = 0; c < data1.metaData.cols; c++)
                {
                    if (data1Values[r,c] != data2Values[r,c]) { return false; }
                }
            }

            return true;
        }

    }
}

