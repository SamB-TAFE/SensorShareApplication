using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorDataApplication
{
    internal class DataController
    {
        private DataProcessor processor;
        private SensorData currentData;

        public DataController(DataProcessor processor)
        {
            processor = processor.getInstance();
        }

        public SensorData onLoad()
        {

        }
    }
}
