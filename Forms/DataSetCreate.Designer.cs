namespace PlasticIdentifier
{
    partial class DataSetCreate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectFileButton = new System.Windows.Forms.Button();
            this.FileSelectedField = new System.Windows.Forms.Label();
            this.DataSetNameField = new System.Windows.Forms.TextBox();
            this.InitDataSetCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectFileButton
            // 
            this.SelectFileButton.Location = new System.Drawing.Point(285, 185);
            this.SelectFileButton.Name = "SelectFileButton";
            this.SelectFileButton.Size = new System.Drawing.Size(75, 23);
            this.SelectFileButton.TabIndex = 1;
            this.SelectFileButton.Text = "Select";
            this.SelectFileButton.UseVisualStyleBackColor = true;
            this.SelectFileButton.Click += new System.EventHandler(this.SelectFileButton_Click);
            // 
            // FileSelectedField
            // 
            this.FileSelectedField.AutoSize = true;
            this.FileSelectedField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileSelectedField.Location = new System.Drawing.Point(242, 127);
            this.FileSelectedField.Name = "FileSelectedField";
            this.FileSelectedField.Size = new System.Drawing.Size(146, 20);
            this.FileSelectedField.TabIndex = 0;
            this.FileSelectedField.Text = "No file selected yet!";
            this.FileSelectedField.Click += new System.EventHandler(this.FileSelectedField_Click);
            // 
            // DataSetNameField
            // 
            this.DataSetNameField.Location = new System.Drawing.Point(208, 55);
            this.DataSetNameField.Name = "DataSetNameField";
            this.DataSetNameField.Size = new System.Drawing.Size(229, 20);
            this.DataSetNameField.TabIndex = 2;
            this.DataSetNameField.Text = "Enter DataSet Name";
            this.DataSetNameField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DataSetNameField.Click += new System.EventHandler(this.DataSetNameField_Click);
            this.DataSetNameField.TextChanged += new System.EventHandler(this.DataSetNameField_TextChanged);
            // 
            // InitDataSetCreate
            // 
            this.InitDataSetCreate.Location = new System.Drawing.Point(246, 256);
            this.InitDataSetCreate.Name = "InitDataSetCreate";
            this.InitDataSetCreate.Size = new System.Drawing.Size(142, 23);
            this.InitDataSetCreate.TabIndex = 3;
            this.InitDataSetCreate.Text = "CreateDataSet";
            this.InitDataSetCreate.UseVisualStyleBackColor = true;
            this.InitDataSetCreate.Click += new System.EventHandler(this.InitTrainButton_Click);
            // 
            // DataSetCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 291);
            this.Controls.Add(this.InitDataSetCreate);
            this.Controls.Add(this.DataSetNameField);
            this.Controls.Add(this.SelectFileButton);
            this.Controls.Add(this.FileSelectedField);
            this.Name = "DataSetCreate";
            this.Text = "DataSetCreate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SelectFileButton;
        private System.Windows.Forms.Label FileSelectedField;
        private System.Windows.Forms.TextBox DataSetNameField;
        private System.Windows.Forms.Button InitDataSetCreate;
    }
}