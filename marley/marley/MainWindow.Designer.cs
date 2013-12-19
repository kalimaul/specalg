namespace marley
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
            this.imgLoadButton = new System.Windows.Forms.Button();
            this.generateMosaicButton = new System.Windows.Forms.Button();
            this.rowsCounter = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.colsCounter = new System.Windows.Forms.NumericUpDown();
            this.imageDBStructure = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rowsCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colsCounter)).BeginInit();
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
            // imgLoadButton
            // 
            this.imgLoadButton.Location = new System.Drawing.Point(188, 15);
            this.imgLoadButton.Name = "imgLoadButton";
            this.imgLoadButton.Size = new System.Drawing.Size(148, 35);
            this.imgLoadButton.TabIndex = 3;
            this.imgLoadButton.Text = "Load Main Image";
            this.imgLoadButton.UseVisualStyleBackColor = true;
            this.imgLoadButton.Click += new System.EventHandler(this.imgLoadButton_Click);
            // 
            // generateMosaicButton
            // 
            this.generateMosaicButton.Location = new System.Drawing.Point(375, 15);
            this.generateMosaicButton.Name = "generateMosaicButton";
            this.generateMosaicButton.Size = new System.Drawing.Size(152, 35);
            this.generateMosaicButton.TabIndex = 4;
            this.generateMosaicButton.Text = "Generate Mosaic";
            this.generateMosaicButton.UseVisualStyleBackColor = true;
            this.generateMosaicButton.Click += new System.EventHandler(this.generateMosaicButton_Click);
            // 
            // rowsCounter
            // 
            this.rowsCounter.Location = new System.Drawing.Point(443, 81);
            this.rowsCounter.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.rowsCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rowsCounter.Name = "rowsCounter";
            this.rowsCounter.Size = new System.Drawing.Size(120, 22);
            this.rowsCounter.TabIndex = 5;
            this.rowsCounter.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(375, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Rows";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(375, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Cols";
            // 
            // colsCounter
            // 
            this.colsCounter.Location = new System.Drawing.Point(443, 124);
            this.colsCounter.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.colsCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.colsCounter.Name = "colsCounter";
            this.colsCounter.Size = new System.Drawing.Size(120, 22);
            this.colsCounter.TabIndex = 8;
            this.colsCounter.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // imageDBStructure
            // 
            this.imageDBStructure.AllowDrop = true;
            this.imageDBStructure.FormattingEnabled = true;
            this.imageDBStructure.Items.AddRange(new object[] {
            "kdtree",
            "array"});
            this.imageDBStructure.Location = new System.Drawing.Point(188, 121);
            this.imageDBStructure.Name = "imageDBStructure";
            this.imageDBStructure.Size = new System.Drawing.Size(121, 24);
            this.imageDBStructure.TabIndex = 9;
            this.imageDBStructure.Text = "kdtree";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Color Matching Structure";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 458);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.imageDBStructure);
            this.Controls.Add(this.colsCounter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rowsCounter);
            this.Controls.Add(this.generateMosaicButton);
            this.Controls.Add(this.imgLoadButton);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.ImgsLoadButton);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            ((System.ComponentModel.ISupportInitialize)(this.rowsCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colsCounter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ImgsLoadButton;
        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.Button imgLoadButton;
        private System.Windows.Forms.Button generateMosaicButton;
        private System.Windows.Forms.NumericUpDown rowsCounter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown colsCounter;
        private System.Windows.Forms.ComboBox imageDBStructure;
        private System.Windows.Forms.Label label3;
    }
}