using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SensorDataApplication
{
    public partial class MainForm : Form
    {
        private readonly DataProcessor dataProcessor;
        private readonly DataView uiControls;
        private readonly DataController controller;
        public MainForm()
        {
            InitializeComponent();
            uiControls = new DataView(
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
                btnSetBounds,
                btnSave
                );
            dataProcessor = DataProcessor.getInstance();
            controller = new DataController(dataProcessor);
            uiControls.DisableButtonsWithoutData();

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string dataFolder = controller.GetDirectory();

            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Metadata JSON (*.json)|*.json",
                InitialDirectory = dataFolder,
                Title = "Select MetaData File to Load From"
            };
            if (ofd.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            SensorData data = controller.onLoad(ofd.FileName);
            LoadData(data);
        }

        public void LoadData(SensorData data)
        {
            uiControls.LoadMetadata(data);
            uiControls.LoadDataintoGrid(data);
            (int index, int count) = controller.GetLoadedDataPosition();
            if (count == 1)
            {
                uiControls.EnableButtonsUponDataLoad();
            }
            uiControls.EnableDisableNavButtons(index, count);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string dataFolder = controller.GetDirectory();

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Metadata JSON (*.json)|*.json",
                InitialDirectory = dataFolder,
                Title = "Save Binary and MetaData"
            };
            if (sfd.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            controller.onSave(sfd.FileName);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            SensorData data = controller.PrevDataset();
            LoadData(data);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SensorData data = controller.NextDataset();
            LoadData(data);
        }

        private void btnSetBounds_Click(object sender, EventArgs e)
        {
            SensorData data = controller.GetData();
            uiControls.ColourInBounds(data);
        }

        private void btnClearBounds_Click(object sender, EventArgs e)
        {
            SensorData data = controller.GetData();
            uiControls.ClearBounds();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!uiControls.ParseSearchInput("Search", out float parsed))
            {
                return;
            }
            else
            {
                (ValueIndex result,string message) = controller.SearchNearest(parsed);
                MessageBox.Show(message);
                if (result != null)
                {
                    uiControls.SelectCell(result.row, result.col);
                }
            }
        }
    }
}
