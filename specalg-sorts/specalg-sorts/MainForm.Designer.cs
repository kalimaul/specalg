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
            this.selectionCheckBox = new System.Windows.Forms.CheckBox();
            this.insertionCheckBox = new System.Windows.Forms.CheckBox();
            this.quicksortCheckBox = new System.Windows.Forms.CheckBox();
            this.threewayQSCheckbox = new System.Windows.Forms.CheckBox();
            this.optimizedQSCheckbox = new System.Windows.Forms.CheckBox();
            this.optimizedQSSwitchAt = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.elemCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortRuns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optimizedQSSwitchAt)).BeginInit();
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
            this.sortButton.Location = new System.Drawing.Point(527, 51);
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
            this.label3.Location = new System.Drawing.Point(350, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Sort Run Count";
            // 
            // sortRuns
            // 
            this.sortRuns.Location = new System.Drawing.Point(353, 51);
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
            // selectionCheckBox
            // 
            this.selectionCheckBox.AutoSize = true;
            this.selectionCheckBox.Checked = true;
            this.selectionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.selectionCheckBox.Location = new System.Drawing.Point(30, 113);
            this.selectionCheckBox.Name = "selectionCheckBox";
            this.selectionCheckBox.Size = new System.Drawing.Size(118, 21);
            this.selectionCheckBox.TabIndex = 13;
            this.selectionCheckBox.Text = "Selection Sort";
            this.selectionCheckBox.UseVisualStyleBackColor = true;
            // 
            // insertionCheckBox
            // 
            this.insertionCheckBox.AutoSize = true;
            this.insertionCheckBox.Checked = true;
            this.insertionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.insertionCheckBox.Location = new System.Drawing.Point(187, 113);
            this.insertionCheckBox.Name = "insertionCheckBox";
            this.insertionCheckBox.Size = new System.Drawing.Size(114, 21);
            this.insertionCheckBox.TabIndex = 14;
            this.insertionCheckBox.Text = "Insertion Sort";
            this.insertionCheckBox.UseVisualStyleBackColor = true;
            // 
            // quicksortCheckBox
            // 
            this.quicksortCheckBox.AutoSize = true;
            this.quicksortCheckBox.Checked = true;
            this.quicksortCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.quicksortCheckBox.Location = new System.Drawing.Point(353, 113);
            this.quicksortCheckBox.Name = "quicksortCheckBox";
            this.quicksortCheckBox.Size = new System.Drawing.Size(90, 21);
            this.quicksortCheckBox.TabIndex = 15;
            this.quicksortCheckBox.Text = "Quicksort";
            this.quicksortCheckBox.UseVisualStyleBackColor = true;
            // 
            // threewayQSCheckbox
            // 
            this.threewayQSCheckbox.AutoSize = true;
            this.threewayQSCheckbox.Checked = true;
            this.threewayQSCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.threewayQSCheckbox.Location = new System.Drawing.Point(471, 113);
            this.threewayQSCheckbox.Name = "threewayQSCheckbox";
            this.threewayQSCheckbox.Size = new System.Drawing.Size(131, 21);
            this.threewayQSCheckbox.TabIndex = 16;
            this.threewayQSCheckbox.Text = "3-way Quicksort";
            this.threewayQSCheckbox.UseVisualStyleBackColor = true;
            // 
            // optimizedQSCheckbox
            // 
            this.optimizedQSCheckbox.AutoSize = true;
            this.optimizedQSCheckbox.Checked = true;
            this.optimizedQSCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optimizedQSCheckbox.Location = new System.Drawing.Point(645, 113);
            this.optimizedQSCheckbox.Name = "optimizedQSCheckbox";
            this.optimizedQSCheckbox.Size = new System.Drawing.Size(157, 21);
            this.optimizedQSCheckbox.TabIndex = 17;
            this.optimizedQSCheckbox.Text = "Optimized Quicksort";
            this.optimizedQSCheckbox.UseVisualStyleBackColor = true;
            // 
            // optimizedQSSwitchAt
            // 
            this.optimizedQSSwitchAt.Location = new System.Drawing.Point(768, 145);
            this.optimizedQSSwitchAt.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.optimizedQSSwitchAt.Name = "optimizedQSSwitchAt";
            this.optimizedQSSwitchAt.Size = new System.Drawing.Size(51, 22);
            this.optimizedQSSwitchAt.TabIndex = 18;
            this.optimizedQSSwitchAt.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(624, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Switch to insertion at";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 399);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.optimizedQSSwitchAt);
            this.Controls.Add(this.optimizedQSCheckbox);
            this.Controls.Add(this.threewayQSCheckbox);
            this.Controls.Add(this.quicksortCheckBox);
            this.Controls.Add(this.insertionCheckBox);
            this.Controls.Add(this.selectionCheckBox);
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
            ((System.ComponentModel.ISupportInitialize)(this.optimizedQSSwitchAt)).EndInit();
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
        private System.Windows.Forms.CheckBox selectionCheckBox;
        private System.Windows.Forms.CheckBox insertionCheckBox;
        private System.Windows.Forms.CheckBox quicksortCheckBox;
        private System.Windows.Forms.CheckBox threewayQSCheckbox;
        private System.Windows.Forms.CheckBox optimizedQSCheckbox;
        private System.Windows.Forms.NumericUpDown optimizedQSSwitchAt;
        private System.Windows.Forms.Label label4;
    }
}