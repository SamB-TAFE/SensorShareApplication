using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SensorDataApplication
{
    internal class DataView
    {
        private DataGridView dataGrid;
        private TextBox titleDisplay;
        private TextBox avgDisplay;
        private TextBox upperBoundInput;
        private TextBox lowerBoundInput;
        private TextBox searchInput;
        private List<Button> datasetNavIcons;
        private Button loadButton;
        private Button saveButton;
        private Button searchButton;
        private Button setBoundsButton;
        private Button clearBoundsButton;


        public DataView(
            DataGridView dataGrid,
            TextBox titleDisplay,
            TextBox avgDisplay,
            TextBox upperBoundInput,
            TextBox lowerBoundInput,
            TextBox searchInput,
            Button datasetPrev,
            Button datasetNext,
            Button loadButton,
            Button saveButton,
            Button searchButton,
            Button setBoundsButton,
            Button clearBoundsButton
            )
        {
            this.dataGrid = dataGrid;
            this.titleDisplay = titleDisplay;
            this.avgDisplay = avgDisplay;
            this.upperBoundInput = upperBoundInput;
            this.lowerBoundInput = lowerBoundInput;
            this.searchInput = searchInput;
            datasetNavIcons.Append(datasetPrev);
            datasetNavIcons.Append(datasetNext);
            this.loadButton = loadButton;
            this.saveButton = saveButton;
            this.searchButton = searchButton;
            this.setBoundsButton = setBoundsButton;
            this.clearBoundsButton = clearBoundsButton;
        }


    }
}
