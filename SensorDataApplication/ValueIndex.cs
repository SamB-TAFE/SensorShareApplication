using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorDataApplication
{
    public class ValueIndex
    {
        public float value;
        public int row;
        public int col;
        public float searchVariance;

        public ValueIndex(float value, int row, int col)
        {
            this.value = value;
            this.row = row;
            this.col = col;
        }
    }
}
