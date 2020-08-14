namespace PlasticIdentifier
{
    partial class ImageIdentification
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
            this.AlgorithmListBox = new System.Windows.Forms.ListBox();
            this.SelectImageToIDBtn = new System.Windows.Forms.Button();
            this.SelectedImageBox = new System.Windows.Forms.PictureBox();
            this.SelectedAlgortihmField = new System.Windows.Forms.Label();
            this.DataSetListBox = new System.Windows.Forms.ListBox();
            this.SelectedDataSetField = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // AlgorithmListBox
            // 
            this.AlgorithmListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlgorithmListBox.FormattingEnabled = true;
            this.AlgorithmListBox.ItemHeight = 25;
            this.AlgorithmListBox.Location = new System.Drawing.Point(12, 54);
            this.AlgorithmListBox.Name = "AlgorithmListBox";
            this.AlgorithmListBox.Size = new System.Drawing.Size(314, 54);
            this.AlgorithmListBox.TabIndex = 0;
            this.AlgorithmListBox.SelectedIndexChanged += new System.EventHandler(this.AlgorithmListBox_SelectedIndexChanged);
            // 
            // SelectImageToIDBtn
            // 
            this.SelectImageToIDBtn.Location = new System.Drawing.Point(276, 559);
            this.SelectImageToIDBtn.Name = "SelectImageToIDBtn";
            this.SelectImageToIDBtn.Size = new System.Drawing.Size(218, 43);
            this.SelectImageToIDBtn.TabIndex = 1;
            this.SelectImageToIDBtn.Text = "Select Button";
            this.SelectImageToIDBtn.UseVisualStyleBackColor = true;
            this.SelectImageToIDBtn.Click += new System.EventHandler(this.SelectImageToIDBtn_Click);
            // 
            // SelectedImageBox
            // 
            this.SelectedImageBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.SelectedImageBox.Location = new System.Drawing.Point(196, 238);
            this.SelectedImageBox.Name = "SelectedImageBox";
            this.SelectedImageBox.Size = new System.Drawing.Size(398, 315);
            this.SelectedImageBox.TabIndex = 2;
            this.SelectedImageBox.TabStop = false;
            // 
            // SelectedAlgortihmField
            // 
            this.SelectedAlgortihmField.AutoSize = true;
            this.SelectedAlgortihmField.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedAlgortihmField.Location = new System.Drawing.Point(376, 72);
            this.SelectedAlgortihmField.Name = "SelectedAlgortihmField";
            this.SelectedAlgortihmField.Size = new System.Drawing.Size(231, 25);
            this.SelectedAlgortihmField.TabIndex = 3;
            this.SelectedAlgortihmField.Text = "Algorithm not selected!";
            this.SelectedAlgortihmField.Click += new System.EventHandler(this.SelectedAlgortihmField_Click);
            // 
            // DataSetListBox
            // 
            this.DataSetListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataSetListBox.FormattingEnabled = true;
            this.DataSetListBox.ItemHeight = 25;
            this.DataSetListBox.Location = new System.Drawing.Point(12, 139);
            this.DataSetListBox.Name = "DataSetListBox";
            this.DataSetListBox.Size = new System.Drawing.Size(314, 79);
            this.DataSetListBox.TabIndex = 4;
            this.DataSetListBox.SelectedIndexChanged += new System.EventHandler(this.DataSetListBox_SelectedIndexChanged);
            // 
            // SelectedDataSetField
            // 
            this.SelectedDataSetField.AutoSize = true;
            this.SelectedDataSetField.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedDataSetField.Location = new System.Drawing.Point(376, 166);
            this.SelectedDataSetField.Name = "SelectedDataSetField";
            this.SelectedDataSetField.Size = new System.Drawing.Size(218, 25);
            this.SelectedDataSetField.TabIndex = 5;
            this.SelectedDataSetField.Text = "DataSet not selected!";
            // 
            // ImageIdentification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 750);
            this.Controls.Add(this.SelectedDataSetField);
            this.Controls.Add(this.DataSetListBox);
            this.Controls.Add(this.SelectedAlgortihmField);
            this.Controls.Add(this.SelectedImageBox);
            this.Controls.Add(this.SelectImageToIDBtn);
            this.Controls.Add(this.AlgorithmListBox);
            this.Name = "ImageIdentification";
            this.Text = "ImageIdentification";
            ((System.ComponentModel.ISupportInitialize)(this.SelectedImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox AlgorithmListBox;
        private System.Windows.Forms.Button SelectImageToIDBtn;
        private System.Windows.Forms.PictureBox SelectedImageBox;
        private System.Windows.Forms.Label SelectedAlgortihmField;
        private System.Windows.Forms.ListBox DataSetListBox;
        private System.Windows.Forms.Label SelectedDataSetField;
    }
}