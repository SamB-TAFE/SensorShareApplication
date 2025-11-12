using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorDataApplication
{
    internal class MetaData
    {
        public string file { get; set; }
        public string dataset_label { get; set; }
        public int rows { get; set; }
        public int cols { get; set; }
        public string[] row_labels { get; set; }
        public string[] col_labels { get; set; }

    }
}
