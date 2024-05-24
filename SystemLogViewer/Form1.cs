using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemLogViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Handles the click event of the getLogsButton. Retrieves the log file path and loads the logs.
        /// </summary>
        /// <param name="sender"> The source of the event.</param>
        /// <param name="e"> An <see cref="EventArgs"/> that contains the event data. </param>
        private void getLogsButton_Click(object sender, EventArgs e)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string appFolderPath = Path.Combine(folderPath, "SystemLogger");
            string logFilePath = Path.Combine(appFolderPath, "SysLog.txt");

            LoadLogs(logFilePath);
        }

        /// <summary>
        /// Loads the logs from the specified log file path into the DataGridView.
        /// Clears the existing rows and adds new rows from the log file.
        /// </summary>
        /// <param name="logFilePath"> The path of the log file to load. </param>
        private void LoadLogs(string logFilePath)
        {
            try
            {
                dataGridView1.Rows.Clear();
                string[] lines = File.ReadAllLines(logFilePath);

                foreach (string line in lines)
                {
                    string[] values = line.Split(',');
                    if (values.Length >= 4)
                    {
                        dataGridView1.Rows.Add(values);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading logs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
