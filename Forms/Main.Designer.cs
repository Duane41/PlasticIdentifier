﻿namespace PlasticIdentifier
{
    partial class Main
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
            this.ObjectsViewBtn = new System.Windows.Forms.Button();
            this.CreateDataSetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ObjectsViewBtn
            // 
            this.ObjectsViewBtn.Location = new System.Drawing.Point(71, 184);
            this.ObjectsViewBtn.Name = "ObjectsViewBtn";
            this.ObjectsViewBtn.Size = new System.Drawing.Size(149, 23);
            this.ObjectsViewBtn.TabIndex = 0;
            this.ObjectsViewBtn.Text = "Objects";
            this.ObjectsViewBtn.UseVisualStyleBackColor = true;
            this.ObjectsViewBtn.Click += new System.EventHandler(this.BTN1_Click);
            // 
            // CreateDataSetButton
            // 
            this.CreateDataSetButton.Location = new System.Drawing.Point(71, 135);
            this.CreateDataSetButton.Name = "CreateDataSetButton";
            this.CreateDataSetButton.Size = new System.Drawing.Size(149, 23);
            this.CreateDataSetButton.TabIndex = 1;
            this.CreateDataSetButton.Text = "Create DataSet";
            this.CreateDataSetButton.UseVisualStyleBackColor = true;
            this.CreateDataSetButton.Click += new System.EventHandler(this.CreateDataSetButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.CreateDataSetButton);
            this.Controls.Add(this.ObjectsViewBtn);
            this.Name = "Main";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ObjectsViewBtn;
        private System.Windows.Forms.Button CreateDataSetButton;
    }
}

