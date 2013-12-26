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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.elemCount = new System.Windows.Forms.NumericUpDown();
            this.maxVal = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sortButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.sortRuns = new System.Windows.Forms.NumericUpDown();
            this.selectionCheckBox = new System.Windows.Forms.CheckBox();
            this.insertionCheckBox = new System.Windows.Forms.CheckBox();
            this.quicksortCheckBox = new System.Windows.Forms.CheckBox();
            this.threewayQSCheckbox = new System.Windows.Forms.CheckBox();
            this.optimizedQSCheckbox = new System.Windows.Forms.CheckBox();
            this.optimizedQSSwitchAt = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.statusLogBox = new System.Windows.Forms.RichTextBox();
            this.runSpeedButton = new System.Windows.Forms.Button();
            this.arrayCountRaceButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.logPage = new System.Windows.Forms.TabPage();
            this.chartPage = new System.Windows.Forms.TabPage();
            this.raceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.elemCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortRuns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optimizedQSSwitchAt)).BeginInit();
            this.tabControl.SuspendLayout();
            this.logPage.SuspendLayout();
            this.chartPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.raceChart)).BeginInit();
            this.SuspendLayout();
            // 
            // elemCount
            // 
            this.elemCount.Location = new System.Drawing.Point(476, 13);
            this.elemCount.Margin = new System.Windows.Forms.Padding(2);
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
            this.elemCount.Size = new System.Drawing.Size(90, 20);
            this.elemCount.TabIndex = 1;
            this.elemCount.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // maxVal
            // 
            this.maxVal.Location = new System.Drawing.Point(476, 41);
            this.maxVal.Margin = new System.Windows.Forms.Padding(2);
            this.maxVal.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.maxVal.Name = "maxVal";
            this.maxVal.Size = new System.Drawing.Size(90, 20);
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
            this.label1.Location = new System.Drawing.Point(358, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of elements";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(403, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Max value";
            // 
            // sortButton
            // 
            this.sortButton.Location = new System.Drawing.Point(12, 10);
            this.sortButton.Margin = new System.Windows.Forms.Padding(2);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(75, 22);
            this.sortButton.TabIndex = 9;
            this.sortButton.Text = "Sort!";
            this.sortButton.UseVisualStyleBackColor = true;
            this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(379, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Sort Run Count";
            // 
            // sortRuns
            // 
            this.sortRuns.Location = new System.Drawing.Point(476, 70);
            this.sortRuns.Margin = new System.Windows.Forms.Padding(2);
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
            this.sortRuns.Size = new System.Drawing.Size(90, 20);
            this.sortRuns.TabIndex = 11;
            this.sortRuns.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // selectionCheckBox
            // 
            this.selectionCheckBox.AutoSize = true;
            this.selectionCheckBox.Checked = true;
            this.selectionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.selectionCheckBox.Location = new System.Drawing.Point(157, 14);
            this.selectionCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.selectionCheckBox.Name = "selectionCheckBox";
            this.selectionCheckBox.Size = new System.Drawing.Size(92, 17);
            this.selectionCheckBox.TabIndex = 13;
            this.selectionCheckBox.Text = "Selection Sort";
            this.selectionCheckBox.UseVisualStyleBackColor = true;
            // 
            // insertionCheckBox
            // 
            this.insertionCheckBox.AutoSize = true;
            this.insertionCheckBox.Checked = true;
            this.insertionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.insertionCheckBox.Location = new System.Drawing.Point(157, 42);
            this.insertionCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.insertionCheckBox.Name = "insertionCheckBox";
            this.insertionCheckBox.Size = new System.Drawing.Size(88, 17);
            this.insertionCheckBox.TabIndex = 14;
            this.insertionCheckBox.Text = "Insertion Sort";
            this.insertionCheckBox.UseVisualStyleBackColor = true;
            // 
            // quicksortCheckBox
            // 
            this.quicksortCheckBox.AutoSize = true;
            this.quicksortCheckBox.Checked = true;
            this.quicksortCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.quicksortCheckBox.Location = new System.Drawing.Point(157, 70);
            this.quicksortCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.quicksortCheckBox.Name = "quicksortCheckBox";
            this.quicksortCheckBox.Size = new System.Drawing.Size(71, 17);
            this.quicksortCheckBox.TabIndex = 15;
            this.quicksortCheckBox.Text = "Quicksort";
            this.quicksortCheckBox.UseVisualStyleBackColor = true;
            // 
            // threewayQSCheckbox
            // 
            this.threewayQSCheckbox.AutoSize = true;
            this.threewayQSCheckbox.Checked = true;
            this.threewayQSCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.threewayQSCheckbox.Location = new System.Drawing.Point(157, 98);
            this.threewayQSCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.threewayQSCheckbox.Name = "threewayQSCheckbox";
            this.threewayQSCheckbox.Size = new System.Drawing.Size(102, 17);
            this.threewayQSCheckbox.TabIndex = 16;
            this.threewayQSCheckbox.Text = "3-way Quicksort";
            this.threewayQSCheckbox.UseVisualStyleBackColor = true;
            // 
            // optimizedQSCheckbox
            // 
            this.optimizedQSCheckbox.AutoSize = true;
            this.optimizedQSCheckbox.Checked = true;
            this.optimizedQSCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optimizedQSCheckbox.Location = new System.Drawing.Point(157, 126);
            this.optimizedQSCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.optimizedQSCheckbox.Name = "optimizedQSCheckbox";
            this.optimizedQSCheckbox.Size = new System.Drawing.Size(120, 17);
            this.optimizedQSCheckbox.TabIndex = 17;
            this.optimizedQSCheckbox.Text = "Optimized Quicksort";
            this.optimizedQSCheckbox.UseVisualStyleBackColor = true;
            // 
            // optimizedQSSwitchAt
            // 
            this.optimizedQSSwitchAt.Location = new System.Drawing.Point(476, 99);
            this.optimizedQSSwitchAt.Margin = new System.Windows.Forms.Padding(2);
            this.optimizedQSSwitchAt.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.optimizedQSSwitchAt.Name = "optimizedQSSwitchAt";
            this.optimizedQSSwitchAt.Size = new System.Drawing.Size(38, 20);
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
            this.label4.Location = new System.Drawing.Point(354, 101);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Switch to insertion at";
            // 
            // statusLogBox
            // 
            this.statusLogBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLogBox.BackColor = System.Drawing.SystemColors.Window;
            this.statusLogBox.Location = new System.Drawing.Point(0, 0);
            this.statusLogBox.Name = "statusLogBox";
            this.statusLogBox.ReadOnly = true;
            this.statusLogBox.Size = new System.Drawing.Size(795, 387);
            this.statusLogBox.TabIndex = 20;
            this.statusLogBox.Text = "";
            // 
            // runSpeedButton
            // 
            this.runSpeedButton.Location = new System.Drawing.Point(12, 41);
            this.runSpeedButton.Name = "runSpeedButton";
            this.runSpeedButton.Size = new System.Drawing.Size(75, 23);
            this.runSpeedButton.TabIndex = 21;
            this.runSpeedButton.Text = "Run speeds";
            this.runSpeedButton.UseVisualStyleBackColor = true;
            this.runSpeedButton.Click += new System.EventHandler(this.runSpeedButton_Click);
            // 
            // arrayCountRaceButton
            // 
            this.arrayCountRaceButton.Location = new System.Drawing.Point(12, 72);
            this.arrayCountRaceButton.Name = "arrayCountRaceButton";
            this.arrayCountRaceButton.Size = new System.Drawing.Size(75, 23);
            this.arrayCountRaceButton.TabIndex = 22;
            this.arrayCountRaceButton.Text = "Race!";
            this.arrayCountRaceButton.UseVisualStyleBackColor = true;
            this.arrayCountRaceButton.Click += new System.EventHandler(this.arrayCountRaceButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.logPage);
            this.tabControl.Controls.Add(this.chartPage);
            this.tabControl.Location = new System.Drawing.Point(12, 165);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(803, 413);
            this.tabControl.TabIndex = 23;
            // 
            // logPage
            // 
            this.logPage.Controls.Add(this.statusLogBox);
            this.logPage.Location = new System.Drawing.Point(4, 22);
            this.logPage.Name = "logPage";
            this.logPage.Padding = new System.Windows.Forms.Padding(3);
            this.logPage.Size = new System.Drawing.Size(795, 387);
            this.logPage.TabIndex = 0;
            this.logPage.Text = "Log";
            this.logPage.UseVisualStyleBackColor = true;
            // 
            // chartPage
            // 
            this.chartPage.BackColor = System.Drawing.Color.White;
            this.chartPage.Controls.Add(this.raceChart);
            this.chartPage.Location = new System.Drawing.Point(4, 22);
            this.chartPage.Name = "chartPage";
            this.chartPage.Padding = new System.Windows.Forms.Padding(3);
            this.chartPage.Size = new System.Drawing.Size(795, 387);
            this.chartPage.TabIndex = 1;
            this.chartPage.Text = "Charts";
            // 
            // raceChart
            // 
            this.raceChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.raceChart.BackColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX.Title = "Array count";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            chartArea1.AxisY.Title = "Execution time in ms";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            chartArea1.Name = "ChartArea1";
            this.raceChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.raceChart.Legends.Add(legend1);
            this.raceChart.Location = new System.Drawing.Point(0, 0);
            this.raceChart.Name = "raceChart";
            this.raceChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            series1.LabelBackColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.Name = "Selection Sort";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            series2.Legend = "Legend1";
            series2.Name = "Insertion Sort";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            series3.Legend = "Legend1";
            series3.Name = "Quicksort";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            series4.Legend = "Legend1";
            series4.Name = "3-way Quicksort";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            series5.Legend = "Legend1";
            series5.Name = "Optimized Quicksort";
            this.raceChart.Series.Add(series1);
            this.raceChart.Series.Add(series2);
            this.raceChart.Series.Add(series3);
            this.raceChart.Series.Add(series4);
            this.raceChart.Series.Add(series5);
            this.raceChart.Size = new System.Drawing.Size(795, 387);
            this.raceChart.TabIndex = 0;
            this.raceChart.Text = "Race Chart";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            title1.Name = "Title1";
            title1.Text = "Array count race chart";
            this.raceChart.Titles.Add(title1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 590);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.arrayCountRaceButton);
            this.Controls.Add(this.runSpeedButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.optimizedQSSwitchAt);
            this.Controls.Add(this.optimizedQSCheckbox);
            this.Controls.Add(this.threewayQSCheckbox);
            this.Controls.Add(this.quicksortCheckBox);
            this.Controls.Add(this.insertionCheckBox);
            this.Controls.Add(this.selectionCheckBox);
            this.Controls.Add(this.sortRuns);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maxVal);
            this.Controls.Add(this.elemCount);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Specalg-Sort";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.elemCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortRuns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optimizedQSSwitchAt)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.logPage.ResumeLayout(false);
            this.chartPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.raceChart)).EndInit();
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
        private System.Windows.Forms.CheckBox selectionCheckBox;
        private System.Windows.Forms.CheckBox insertionCheckBox;
        private System.Windows.Forms.CheckBox quicksortCheckBox;
        private System.Windows.Forms.CheckBox threewayQSCheckbox;
        private System.Windows.Forms.CheckBox optimizedQSCheckbox;
        private System.Windows.Forms.NumericUpDown optimizedQSSwitchAt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox statusLogBox;
        private System.Windows.Forms.Button runSpeedButton;
        private System.Windows.Forms.Button arrayCountRaceButton;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage logPage;
        private System.Windows.Forms.TabPage chartPage;
        private System.Windows.Forms.DataVisualization.Charting.Chart raceChart;
    }
}