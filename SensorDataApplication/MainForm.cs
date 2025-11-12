using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SensorDataApplication
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitialiseClasses();

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
        }

        public void InitialiseClasses()
        {
            DataView uiControls = new DataView(
                dataGridView1,
                txtbxTitle,
                txtbxAverage,
                txtbxUpperBound,
                txtbxLowerBound,
                txtbxSearchTerm,
                btnPrev,
                btnNext,
                btnSearch,
                btnClearBounds,
                btnSetBounds
                );
            DataProcessor dataProcessor = new DataProcessor();
            DataController controller = new DataController(dataProcessor);
        }
    }
}
