namespace PlasticIdentifier
{
    partial class Training
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
            this.SelectAlgorithmListTrain = new System.Windows.Forms.ListBox();
            this.SelectDatSetListTrain = new System.Windows.Forms.ListBox();
            this.StartTrainingBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectAlgorithmListTrain
            // 
            this.SelectAlgorithmListTrain.FormattingEnabled = true;
            this.SelectAlgorithmListTrain.Location = new System.Drawing.Point(12, 37);
            this.SelectAlgorithmListTrain.Name = "SelectAlgorithmListTrain";
            this.SelectAlgorithmListTrain.Size = new System.Drawing.Size(260, 56);
            this.SelectAlgorithmListTrain.TabIndex = 0;
            this.SelectAlgorithmListTrain.SelectedIndexChanged += new System.EventHandler(this.SelectAlgorithmListTrain_SelectedIndexChanged);
            // 
            // SelectDatSetListTrain
            // 
            this.SelectDatSetListTrain.FormattingEnabled = true;
            this.SelectDatSetListTrain.Location = new System.Drawing.Point(12, 102);
            this.SelectDatSetListTrain.Name = "SelectDatSetListTrain";
            this.SelectDatSetListTrain.Size = new System.Drawing.Size(260, 56);
            this.SelectDatSetListTrain.TabIndex = 1;
            this.SelectDatSetListTrain.SelectedIndexChanged += new System.EventHandler(this.SelectDatSetListTrain_SelectedIndexChanged);
            // 
            // StartTrainingBtn
            // 
            this.StartTrainingBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartTrainingBtn.Location = new System.Drawing.Point(35, 182);
            this.StartTrainingBtn.Name = "StartTrainingBtn";
            this.StartTrainingBtn.Size = new System.Drawing.Size(210, 43);
            this.StartTrainingBtn.TabIndex = 2;
            this.StartTrainingBtn.Text = "Train";
            this.StartTrainingBtn.UseVisualStyleBackColor = true;
            this.StartTrainingBtn.Click += new System.EventHandler(this.StartTrainingBtn_Click);
            // 
            // Training
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.StartTrainingBtn);
            this.Controls.Add(this.SelectDatSetListTrain);
            this.Controls.Add(this.SelectAlgorithmListTrain);
            this.Name = "Training";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox SelectAlgorithmListTrain;
        private System.Windows.Forms.ListBox SelectDatSetListTrain;
        private System.Windows.Forms.Button StartTrainingBtn;
    }
}