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
    public partial class ObjectsView : Form
    {
        private PlasticDBContext db_context;
        private BindingSource bindingsource_hardwareusage;
        private BindingSource bindingsource_images;
        private BindingSource bindingSource_datasets;
        private BindingSource bindingSource_algorithms;
        public ObjectsView()
        {

            
            try
            {
                InitializeComponent();
                /*

                var data = (from d in algorithm_db.Algorithms select d);
                AlgorithmsDataGrid.DataSource = data.ToList();
                */

                db_context = new PlasticDBContext();

                bindingSource_algorithms = new BindingSource();

                bindingSource_algorithms.DataSource = (from r in db_context.Algorithms
                                                       select new
                                                       {
                                                           AlgorithmId = r.AlgorithmId,
                                                           Name = r.Name
                                                       }).ToList();
                
                AlgorithmsDataGrid.DataSource = bindingSource_algorithms;




                //Loads dataset data
                bindingSource_datasets = new BindingSource();

                bindingSource_datasets.DataSource = (from r in db_context.DataSets
                                                     select new
                                                     {
                                                         Id = r.Id,
                                                         AlgorithmId = r.AlgorithmId,
                                                         Algorithm = r.Algorithm.Name,
                                                         NumImages = r.NumImages,
                                                         NumImagesPlastic = r.NumImagesPlastic,
                                                         NumImagesNotPlastic = r.NumImagesNotPlastic,
                                                         Name = r.Name,
                                                         Trained = r.Trained
                                                     }).ToList();

                DataSetsDataGrid.DataSource = bindingSource_datasets;

                //Load images data
                bindingsource_images = new BindingSource();

                bindingsource_images.DataSource = (from r in db_context.Images
                                                   select new
                                                   {
                                                       ImageId = r.Id,
                                                       ImageSize = r.ImageSize,
                                                       FileLocation = r.FileLocation,
                                                       IsPlasic = r.IsPlastic,
                                                       Id = r.Id
                                                   }).ToList();

                ImageDataGrid.DataSource = bindingsource_images;

                //Loads hardwareusage data
                bindingsource_hardwareusage = new BindingSource();

                bindingsource_hardwareusage.DataSource = (from r in db_context.HardwareUsages
                                                          select new
                                                          {
                                                              HardwareUsageId = r.Id,
                                                              Si_Unit = r.SI_Unit,
                                                              Id = r.Id
                                                          }).ToList();

                HardwareUsageDataGrid.DataSource = bindingsource_hardwareusage;

                AddAlgorithmBtn.Visible = false;

                AlgorithmInputField.Visible = false;

                Console.WriteLine("Objects view loaded");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurrer while initiating objects view: " + ex.ToString());
                Console.WriteLine(ex);
                System.Threading.Thread.CurrentThread.Abort();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void algorithmBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
        private void refresh_algorithms_view()
        {
            bindingSource_algorithms.DataSource = (from r in db_context.Algorithms
                                                   select new
                                                   {
                                                       AlgorithmId = r.AlgorithmId,
                                                       Name = r.Name
                                                   }).ToList();

            AlgorithmsDataGrid.DataSource = bindingSource_algorithms;
        }

        private void AddAlgorithmBtn_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(AlgorithmInputField.Text))
            {
                db_context.Algorithms.Add(new Algorithm()
                {
                    Name = AlgorithmInputField.Text
                });

                db_context.SaveChanges();

                Console.WriteLine("Algorithm added");

                AlgorithmInputField.Clear();

                refresh_algorithms_view();
            }
        }
        
        private void onClickAlgorithms()
        {
            AddAlgorithmBtn.Visible = true;

            AlgorithmInputField.Visible = true;
        }

        private void HideAddAlgorithms()
        {
            AddAlgorithmBtn.Visible = false;

            AlgorithmInputField.Visible = false;
        }

        private void ObjectViewTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ObjectViewTabs.SelectedTab.Name == "AlgorithmsPage")
            {
                onClickAlgorithms();
            } else
            {
                HideAddAlgorithms();
            }
        }
    }
}
