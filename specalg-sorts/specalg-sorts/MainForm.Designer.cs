namespace specalg_sorts
{
    partial class MainForm
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
            this.elemCount = new System.Windows.Forms.NumericUpDown();
            this.maxVal = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sortButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.sortRuns = new System.Windows.Forms.NumericUpDown();
            this.statusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.elemCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortRuns)).BeginInit();
            this.SuspendLayout();
            // 
            // elemCount
            // 
            this.elemCount.Location = new System.Drawing.Point(30, 51);
            this.elemCount.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.elemCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.elemCount.Name = "elemCount";
            this.elemCount.Size = new System.Drawing.Size(120, 22);
            this.elemCount.TabIndex = 1;
            this.elemCount.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // maxVal
            // 
            this.maxVal.Location = new System.Drawing.Point(187, 51);
            this.maxVal.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.maxVal.Name = "maxVal";
            this.maxVal.Size = new System.Drawing.Size(120, 22);
            this.maxVal.TabIndex = 2;
            this.maxVal.Value = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of elements";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Max value";
            // 
            // sortButton
            // 
            this.sortButton.Location = new System.Drawing.Point(353, 101);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(75, 23);
            this.sortButton.TabIndex = 9;
            this.sortButton.Text = "Sort!";
            this.sortButton.UseVisualStyleBackColor = true;
            this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Sort Run Count";
            // 
            // sortRuns
            // 
            this.sortRuns.Location = new System.Drawing.Point(187, 99);
            this.sortRuns.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.sortRuns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sortRuns.Name = "sortRuns";
            this.sortRuns.Size = new System.Drawing.Size(120, 22);
            this.sortRuns.TabIndex = 11;
            this.sortRuns.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(27, 167);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(46, 17);
            this.statusLabel.TabIndex = 12;
            this.statusLabel.Text = "status";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 399);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.sortRuns);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maxVal);
            this.Controls.Add(this.elemCount);
            this.Name = "MainForm";
            this.Text = "Specalg-Sort";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.elemCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortRuns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown elemCount;
        private System.Windows.Forms.NumericUpDown maxVal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown sortRuns;
        private System.Windows.Forms.Label statusLabel;
    }
}