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
    
    public partial class ImageIdentification : Form
    {
        private AlgorithmContext algorithm_db;
        private DataSetContext dataset_db;

        private int selected_algorithm_id;

        public ImageIdentification()
        {
            InitializeComponent();

            algorithm_db = new AlgorithmContext();
            dataset_db = new DataSetContext();
            List<Algorithm> alg_list = algorithm_db.Algorithms.ToList();
            AlgorithmListBox.DataSource = algorithm_db.Algorithms.ToList();
            AlgorithmListBox.DisplayMember = "Name";
        }

        private void AlgorithmListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected_algorithm_id = AlgorithmListBox.SelectedIndex;
        }
    }
}
