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
        private int selected_algorithm_id;
        private int selected_dataset_id;
        private Algorithm selected_algorithm;
        private Objects.DataSet selected_dataset;


        public ImageIdentification()
        {
            InitializeComponent();

            db_context = new PlasticDBContext();
            List<Algorithm> alg_list = db_context.Algorithms.ToList();
            AlgorithmListBox.DataSource = db_context.Algorithms.ToList();
            AlgorithmListBox.DisplayMember = "Name";
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
                //Send through image location
                //Send through data set location
                AlgorithmHelper.PatchParameterProcess("", 0);

                //Set result
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
