using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SensorDataApplication
{
    public class SensorData
    {
        public MetaData metaData;
        private float[,] values;
        private float average;
        private float standardVariance;

        public SensorData(MetaData meta, float[,] extractedValues)
        {
            metaData = meta;
            values = extractedValues;
        }


        public float[,] getValues()
        {
            return values;
        }

        public void setAverage(float average)
        {
            this.average = average;
        }

        public float getAverage()
        {
            return average;
        }

        public void setSV(float standardVariance)
        {
            this.standardVariance = standardVariance;
        }

        public float getSV()
        {
            return standardVariance;
        }
    }
}
