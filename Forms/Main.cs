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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void BTN1_Click(object sender, EventArgs e)
        {
            ObjectsView obj_view = new ObjectsView();
            obj_view.ShowDialog();
        }

        private void CreateDataSetButton_Click(object sender, EventArgs e)
        {
            DataSetCreate dataset_create_view = new DataSetCreate();
            dataset_create_view.ShowDialog();
        }

        private void IdentifyImageBtn_Click(object sender, EventArgs e)
        {
            ImageIdentification identification_view = new ImageIdentification();
            identification_view.ShowDialog();
        }

        private void TrainingBtn_Click(object sender, EventArgs e)
        {
            Training training_view = new Training();
            training_view.ShowDialog();
        }
    }
}
