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
        private int selected_dataset_id;
        private int selected_algorithm_id;
        private Objects.DataSet selected_dataset;
        private Algorithm selected_algorithm;

        public Training()
        {
            InitializeComponent();

            db_context = new PlasticDBContext();

            SelectDatSetListTrain.DataSource = db_context.DataSets.ToList();
            SelectDatSetListTrain.DisplayMember = "Name";

            SelectAlgorithmListTrain.DataSource = db_context.Algorithms.ToList();
            SelectAlgorithmListTrain.DisplayMember = "Name";
        }

        private void StartTrainingBtn_Click(object sender, EventArgs e)
        {
            try
            {
                selected_dataset.Trained = true;
                selected_dataset.AlgorithmId = selected_algorithm_id;
                db_context.SaveChanges();
                MessageBox.Show("Algorithm Added");
                this.Close();
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
