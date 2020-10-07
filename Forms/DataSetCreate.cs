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
        private PlasticDBContext dataset_db;
        private string selected_file = "";

        public DataSetCreate()
        {
            InitializeComponent();
            dataset_db = new PlasticDBContext();
            Console.WriteLine("Create DataSet loaded");
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("File selected loaded...");

            using (var file_browser = new FolderBrowserDialog())
            {
                DialogResult result = file_browser.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(file_browser.SelectedPath))
                {
                    selected_file = file_browser.SelectedPath;

                    FileSelectedField.Text = selected_file;

                    Console.WriteLine("Selected: " + selected_file);
                }
            }
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

        private void FileSelectedField_Click(object sender, EventArgs e)
        {
            
        }

        private void InitTrainButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(selected_file) && DataSetNameField.Text != "Enter DataSet Name")
                {
                    Console.WriteLine("Processing Images...");

                    string[] files = Directory.GetFiles(selected_file);

                    Objects.DataSet new_dataset = new Objects.DataSet()
                    {
                        NumImages = files.Length,
                        Trained = false,
                        NumImagesNotPlastic = files.Length,
                        NumImagesPlastic = files.Length,
                        Name = DataSetNameField.Text
                    };

                    Console.WriteLine("Images Added To Set...");

                    dataset_db.DataSets.Add(new_dataset);

                    dataset_db.SaveChanges();

                    Console.WriteLine("Images Copying To Local Folder...");

                    ImageHelper.addImagesToSet(selected_file, new_dataset);

                    MessageBox.Show("DataSet created");

                    this.Close();
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(selected_file) && DataSetNameField.Text == "Enter DataSet Name")
                    {
                        MessageBox.Show("Please select a folder and a name for the DataSet");
                    }
                    else if (string.IsNullOrWhiteSpace(selected_file))
                    {
                        MessageBox.Show("Please select a folder");
                    }
                    else
                    {
                        MessageBox.Show("Please select a name");
                    }

                }
            } catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
           finally
            {
                this.Close();
            }     
        }

        private void DataSetNameField_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void DataSetNameField_Click(object sender, EventArgs e)
        {
            DataSetNameField.Text = "";
        }
    }
}
