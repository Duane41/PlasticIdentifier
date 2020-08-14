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
            ((System.ComponentModel.ISupportInitialize)(this.SelectedImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // AlgorithmListBox
            // 
            this.AlgorithmListBox.FormattingEnabled = true;
            this.AlgorithmListBox.Location = new System.Drawing.Point(12, 54);
            this.AlgorithmListBox.Name = "AlgorithmListBox";
            this.AlgorithmListBox.Size = new System.Drawing.Size(218, 43);
            this.AlgorithmListBox.TabIndex = 0;
            this.AlgorithmListBox.SelectedIndexChanged += new System.EventHandler(this.AlgorithmListBox_SelectedIndexChanged);
            // 
            // SelectImageToIDBtn
            // 
            this.SelectImageToIDBtn.Location = new System.Drawing.Point(12, 271);
            this.SelectImageToIDBtn.Name = "SelectImageToIDBtn";
            this.SelectImageToIDBtn.Size = new System.Drawing.Size(218, 43);
            this.SelectImageToIDBtn.TabIndex = 1;
            this.SelectImageToIDBtn.Text = "Select Button";
            this.SelectImageToIDBtn.UseVisualStyleBackColor = true;
            // 
            // SelectedImageBox
            // 
            this.SelectedImageBox.Location = new System.Drawing.Point(263, 238);
            this.SelectedImageBox.Name = "SelectedImageBox";
            this.SelectedImageBox.Size = new System.Drawing.Size(239, 107);
            this.SelectedImageBox.TabIndex = 2;
            this.SelectedImageBox.TabStop = false;
            // 
            // ImageIdentification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 563);
            this.Controls.Add(this.SelectedImageBox);
            this.Controls.Add(this.SelectImageToIDBtn);
            this.Controls.Add(this.AlgorithmListBox);
            this.Name = "ImageIdentification";
            this.Text = "ImageIdentification";
            ((System.ComponentModel.ISupportInitialize)(this.SelectedImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox AlgorithmListBox;
        private System.Windows.Forms.Button SelectImageToIDBtn;
        private System.Windows.Forms.PictureBox SelectedImageBox;
    }
}