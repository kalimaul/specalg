﻿namespace marley
{
    partial class MainWindow
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
            this.ImgsLoadButton = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // ImgsLoadButton
            // 
            this.ImgsLoadButton.Location = new System.Drawing.Point(15, 15);
            this.ImgsLoadButton.Name = "ImgsLoadButton";
            this.ImgsLoadButton.Size = new System.Drawing.Size(141, 35);
            this.ImgsLoadButton.TabIndex = 1;
            this.ImgsLoadButton.Text = "Load Images";
            this.ImgsLoadButton.UseVisualStyleBackColor = true;
            this.ImgsLoadButton.Click += new System.EventHandler(this.ImgsLoadButton_Click);
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(15, 188);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(732, 258);
            this.logBox.TabIndex = 2;
            this.logBox.Text = "";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 458);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.ImgsLoadButton);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ImgsLoadButton;
        private System.Windows.Forms.RichTextBox logBox;
    }
}