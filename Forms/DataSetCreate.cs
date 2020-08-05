using PlasticIdentifier.Helpers;
using PlasticIdentifier.Objects;
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

namespace PlasticIdentifier
{
    public partial class DataSetCreate : Form
    {
        private DataSetContext dataset_db;


        public DataSetCreate()
        {
            InitializeComponent();
            dataset_db = new DataSetContext();
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            FileSelectedField.Text = "Loading...";

            using (var file_browser = new FolderBrowserDialog())
            {
                DialogResult result = file_browser.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(file_browser.SelectedPath))
                {
                    FileSelectedField.Text = "Processing Images...";

                    string[] files = Directory.GetFiles(file_browser.SelectedPath);

                    Objects.DataSet new_dataset = new Objects.DataSet()
                    {
                        NumImages = files.Length,
                        Trained = false,
                        NumImagesNotPlastic = files.Length,
                        NumImagesPlastic = files.Length,
                        Name = "Test DataSet"
                    };

                    FileSelectedField.Text = "Images Added To Set...";

                    dataset_db.DataSets.Add(new_dataset);

                    dataset_db.SaveChanges();

                    FileSelectedField.Text = "Images Copying To Local Folder...";

                    ImageHelper.addImagesToSet(file_browser.SelectedPath, new_dataset);
                }
            }

            FileSelectedField.Text = "Complete!";
        }

        private bool ValidFiles(string path)
        {
            try
            {
                return false;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
