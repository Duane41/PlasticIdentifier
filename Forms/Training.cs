using PlasticIdentifier.Helpers;
using PlasticIdentifier.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlasticIdentifier
{
    public partial class Training : Form
    {
        private PlasticDBContext db_context;
        private int selected_dataset_id = 0;
        private int selected_algorithm_id = 0;
        private Objects.DataSet selected_dataset;
        private Algorithm selected_algorithm;
        private static readonly string APP_DATA = @"~/Images/";

        public Training()
        {
            InitializeComponent();

            db_context = new PlasticDBContext();

            SelectDatSetListTrain.DataSource = db_context.DataSets.ToList();

            SelectDatSetListTrain.DisplayMember = "Name";

            SelectAlgorithmListTrain.DataSource = db_context.Algorithms.ToList();

            SelectAlgorithmListTrain.DisplayMember = "Name";

            Console.WriteLine("Training loaded");
        }

        private void StartTrainingBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (selected_dataset_id == 0 && selected_algorithm_id == 0)
                {

                    MessageBox.Show("Select a DataSet and an Algorithm");

                } else if (selected_algorithm_id == 0) {

                    MessageBox.Show("Select an Algorithm");

                } else if (selected_dataset_id == 0)
                {

                    MessageBox.Show("Select a DataSet");

                }
                else
                {
                    PlasticIdentifier.Helpers.AlgorithmHelper.TrainDataSetAvgVec(
                        APP_DATA + selected_dataset.Name + "_" + selected_dataset.Id,
                        selected_dataset.Name + "_" + selected_dataset.Id);

                    selected_dataset.Trained = true;

                    selected_dataset.AlgorithmId = selected_algorithm_id;

                    db_context.SaveChanges();

                    MessageBox.Show("Training Complete");
                    this.Close();
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SelectDatSetListTrain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selected_dataset = (Objects.DataSet) SelectDatSetListTrain.SelectedItem;

                selected_dataset_id = selected_dataset.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SelectAlgorithmListTrain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selected_algorithm = (Algorithm) SelectAlgorithmListTrain.SelectedItem;

                selected_algorithm_id = selected_algorithm.AlgorithmId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
