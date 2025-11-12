using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
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
        private Button datasetPrev;
        private Button datasetNext;
        private Button searchButton;
        private Button clearBoundsButton;
        private Button setBoundsButton;


        public DataView(
            DataGridView dataGrid,
            TextBox titleDisplay,
            TextBox avgDisplay,
            TextBox upperBoundInput,
            TextBox lowerBoundInput,
            TextBox searchInput,
            Button datasetPrev,
            Button datasetNext,
            Button search,
            Button clearBounds,
            Button setBounds
            )
        {
            this.dataGrid = dataGrid;
            this.titleDisplay = titleDisplay;
            this.avgDisplay = avgDisplay;
            this.upperBoundInput = upperBoundInput;
            this.lowerBoundInput = lowerBoundInput;
            this.searchInput = searchInput;
            this.datasetPrev = datasetPrev;
            this.datasetNext = datasetNext;
            this.searchButton = search;
            this.clearBoundsButton = clearBounds;
            this.setBoundsButton = setBounds;
        }

        public void DisableButtonsWithoutData()
        {
            DisableButton(datasetPrev);
            DisableButton(datasetNext);
            DisableButton(searchButton);
            DisableButton(clearBoundsButton);
            DisableButton(setBoundsButton);
        }

        public void EnableButtonsUponDataLoad()
        {
            EnableButton(datasetPrev);
            EnableButton(datasetNext);
            EnableButton(searchButton);
            EnableButton(clearBoundsButton);
            EnableButton(setBoundsButton);
        }

        public void ClearBounds()
        {
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (row.IsNewRow) continue;

                // Start at 1 to skip the "Row" header column
                for (int c = 1; c < dataGrid.Columns.Count; c++)
                {
                    DataGridViewCell cell = row.Cells[c];

                    cell.Style.BackColor = Color.White;

                }
            }
        }

        public void ColourInBounds(SensorData data)
        {
            bool bounds = TryGetBounds(data, out float upperBound, out float lowerBound);

            if (bounds)
            {
                foreach (DataGridViewRow row in dataGrid.Rows)
                {
                    if (row.IsNewRow) continue;

                    // Start at 1 to skip the "Row" header column
                    for (int c = 1; c < dataGrid.Columns.Count; c++)
                    {
                        DataGridViewCell cell = row.Cells[c];

                        if (cell.Value == null) continue;

                        // Try parse the cell value into a float
                        if (float.TryParse(cell.Value.ToString(), out float value))
                        {
                            if (value < lowerBound)
                            {
                                cell.Style.BackColor = Color.SkyBlue; // below lower
                            }
                            else if (value > upperBound)
                            {
                                cell.Style.BackColor = Color.DarkSalmon; // above upper
                            }
                            else
                            {
                                cell.Style.BackColor = Color.PaleGreen;  // within range
                            }
                        }
                        else
                        {
                            // Not numeric (could be text header column)
                            cell.Style.BackColor = Color.White;
                        }
                    }
                }
            }
        }

        public bool TryGetBounds(SensorData data, out float upperBound, out float lowerBound)
        {
            // set values if false
            upperBound = float.NaN;
            lowerBound = float.NaN;

            // get text
            string upperBoundText = upperBoundInput.Text.Trim();
            string lowerBoundText = lowerBoundInput.Text.Trim();

            if (!ParseBoundInput(upperBoundText, "Upper Boundary", out upperBound)) return false;
            if (!ParseBoundInput(lowerBoundText, "Lower Boundary", out lowerBound)) return false;

            if (upperBound == 0 && lowerBound == 0) // Set Bounds on empty inputs
            {
                (upperBound, lowerBound) = SetDefaultBounds(data);
                upperBoundInput.Text = $"{upperBound} (Standard Var)";
                lowerBoundInput.Text = $"{lowerBound} (Standard Var)";
                return true;
            }

            if (float.IsNaN(upperBound) || float.IsNaN(lowerBound)) // Set Bounds with one input
            {
                if (float.IsNaN(upperBound))
                {
                    upperBound = float.MaxValue;
                }
                if (lowerBound == 0)
                {
                    lowerBound = float.MinValue;
                }
                return true;
            }

            if (upperBound < lowerBound)
            {
                MessageBox.Show("Upper Boundary must be greater than or equal to Lower Boundary.");
                return false;
            }

            return true; // return properly parsed bounds

        }

        public (float,float) SetDefaultBounds(SensorData data)
        {
            float average = data.getAverage();
            float standardVar = data.getSV();
            float upperDefault = average + standardVar;
            float lowerDefault = average - standardVar;
            return (upperDefault,lowerDefault);
        }

        public bool ParseBoundInput(string text, string fieldTitle, out float parsed)
        {
            // Blank/whitespace means "missing" (will be set to default)
            if (string.IsNullOrWhiteSpace(text))
            {
                parsed = float.NaN;
                return true;     
            }

            // Try to parse a non-blank entry
            if (!float.TryParse(text, NumberStyles.Float, CultureInfo.CurrentCulture, out parsed))
            {
                MessageBox.Show($"Please enter a valid number. ({fieldTitle})");
                return false;
            }

            return true;
        }

        public bool ParseSearchInput(string text, string textboxTitle, out float parsed)
        {
            if (!string.IsNullOrWhiteSpace(text) || !float.TryParse(text, out parsed))
            {
                MessageBox.Show($"Please enter a valid input. ({textboxTitle})");
                parsed = 0;
                return false;
            }
            else
            {
                return true;
            }
        }

        public void EnableDisableNavButtons(int loadedDataIndex, int loadedDataCount)
        {
            if (loadedDataIndex == 0)
            {
                DisableButton(datasetPrev);
            }
            if (loadedDataIndex == loadedDataCount - 1)
            {
                DisableButton(datasetNext);
            }
            if (loadedDataIndex > 0)
            {
                EnableButton(datasetPrev);
            }
            if (loadedDataIndex < loadedDataCount - 1)
            {
                EnableButton(datasetNext);
            }
        }

        public void EnableButton(Button butt)
        {
            butt.Enabled = true;
            Color control = Color.Gainsboro;
            butt.BackColor = control;
        }

        public void DisableButton(Button butt)
        {
            butt.Enabled = false;
            Color darken = Color.Silver;
            butt.BackColor = darken;
        }

        
        public void LoadMetadata(SensorData data)
        {
            string title = data.metaData.dataset_label;
            string average = data.getAverage().ToString();
            titleDisplay.Text = title;
            avgDisplay.Text = average;
        }

        public void LoadDataintoGrid(SensorData data)
        {
            MetaData meta = data.metaData;
            float[,] values = data.getValues();

            int rows = meta.rows;
            int cols = meta.cols;


            string[] rowHeaders = (meta.row_labels ?? Array.Empty<string>());
            if (rowHeaders.Length != rows)
                rowHeaders = Enumerable.Range(0, rows).Select(i => $"Row {i}").ToArray();

            string[] colHeaders = (meta.col_labels ?? Array.Empty<string>());
            if (colHeaders.Length != cols)
                colHeaders = Enumerable.Range(0, cols).Select(j => $"Col {j}").ToArray();

            DataTable table = new DataTable();
            table.Columns.Add("Row Headers", typeof(string));
            foreach (var header in colHeaders)
                table.Columns.Add(header, typeof(float));

            for (int r = 0; r < rows; r++)
            {
                var row = table.NewRow();
                row[0] = rowHeaders[r];

                for (int c = 0; c < cols; c++)
                {
                    float v = values[r, c];
                    row[c + 1] = v;
                }

                table.Rows.Add(row);
            }

            // Add to the grid
            dataGrid.AutoGenerateColumns = true;
            dataGrid.DataSource = table;

            // Set how it's used
            dataGrid.AllowUserToAddRows = false;
            dataGrid.ReadOnly = true;
            dataGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGrid.RowHeadersVisible = false;
        }


    }
}
