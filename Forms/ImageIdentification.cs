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
    
    public partial class ImageIdentification : Form
    {
        private PlasticDBContext db_context;
        private int selected_algorithm_id = 0;
        private int selected_dataset_id = 0;
        private Algorithm selected_algorithm;
        private Objects.DataSet selected_dataset;
        private static readonly string APP_DATA = @"~/Images/";
        private string selected_image_path = "";

        public ImageIdentification()
        {
            InitializeComponent();

            db_context = new PlasticDBContext();
            List<Algorithm> alg_list = db_context.Algorithms.ToList();
            AlgorithmListBox.DataSource = db_context.Algorithms.ToList();
            AlgorithmListBox.DisplayMember = "Name";

            Console.WriteLine("Identify Image Loaded!");
        }

        private void AlgorithmListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selected_algorithm = (Algorithm)AlgorithmListBox.SelectedItem;
                selected_algorithm_id = selected_algorithm.AlgorithmId;
                SelectedAlgortihmField.Text = selected_algorithm.Name;
                PopulateDataSetList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SelectImageToIDBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (var file_browser = new OpenFileDialog())
                {
                    DialogResult result = file_browser.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(file_browser.FileName))
                    {
                        SelectedImageBox.Image = System.Drawing.Image.FromFile(file_browser.FileName);
                        SelectedImageBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        selected_image_path = file_browser.FileName;
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        
        private void SelectedAlgortihmField_Click(object sender, EventArgs e)
        {
            
        }

        private void PopulateDataSetList()
        {
            try
            {
                List<Objects.DataSet> data_set_associated = db_context.DataSets.Where(d => d.AlgorithmId == selected_algorithm_id).ToList();

                if (data_set_associated.Count == 0)
                {
                    SelectedDataSetField.Text = "DataSet not created for this algorithm";

                    DataSetListBox.DataSource = data_set_associated;
                }
                else
                {
                    DataSetListBox.DataSource = data_set_associated;

                    DataSetListBox.DisplayMember = "Name";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DataSetListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selected_dataset = (Objects.DataSet)DataSetListBox.SelectedItem;
                selected_dataset_id = selected_dataset.Id;
                if (!selected_dataset.Trained)
                {
                    SelectedDataSetField.Text = "Selected DataSet needs training!";
                }
                else if (selected_dataset.Trained)
                {
                    
                    SelectedDataSetField.Text = selected_dataset.Name + "; #Image in set: " + selected_dataset.NumImages;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool? result = null;
                if (selected_dataset_id == 0 && selected_algorithm_id == 0 && selected_image_path == "")
                {
                    MessageBox.Show("Select a DataSet and an Algorithm");
                }
                else if (selected_dataset_id == 0)
                {
                    MessageBox.Show("Select a DataSet");
                }
                else if (selected_algorithm_id == 0)
                {
                    MessageBox.Show("Select an Algorithm");
                } 
                else if (selected_image_path == "") {
                    MessageBox.Show("Select an image to identify");
                }
                else
                {
                    //Send through image location
                    //Send through data set location
                    switch(selected_algorithm_id)
                    {
                        case 4:

                            result = AlgorithmHelper.IDPixelVecEuclid(
                            APP_DATA + selected_dataset.Name + "_" + selected_dataset.Id,
                            selected_dataset.Name + "_" + selected_dataset.Id,
                            selected_image_path);

                            break;
                        case 5:

                            result = AlgorithmHelper.IDHistVecEuclid(
                            APP_DATA + selected_dataset.Name + "_" + selected_dataset.Id,
                            selected_dataset.Name + "_" + selected_dataset.Id,
                            selected_image_path);

                            break;
                        case 6:

                            result = AlgorithmHelper.IDPixelManhattan(
                            APP_DATA + selected_dataset.Name + "_" + selected_dataset.Id,
                            selected_dataset.Name + "_" + selected_dataset.Id,
                            selected_image_path);

                            break;
                        case 7:

                            result = AlgorithmHelper.IDHistManhattan(
                            APP_DATA + selected_dataset.Name + "_" + selected_dataset.Id,
                            selected_dataset.Name + "_" + selected_dataset.Id,
                            selected_image_path);

                            break;
                        case 8:

                            result = AlgorithmHelper.IDPixelCosine(
                            APP_DATA + selected_dataset.Name + "_" + selected_dataset.Id,
                            selected_dataset.Name + "_" + selected_dataset.Id,
                            selected_image_path);

                            break;
                        case 9:

                            result = AlgorithmHelper.IDHistCosine(
                            APP_DATA + selected_dataset.Name + "_" + selected_dataset.Id,
                            selected_dataset.Name + "_" + selected_dataset.Id,
                            selected_image_path);

                            break;
                        default:
                            break;
                    }
                    
                    MessageBox.Show(result.Value ? "This image is of the same set" : "This image is not of the same set");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
