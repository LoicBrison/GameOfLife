namespace GameOfLife
{
    partial class ScreenOfLife
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenOfLife));
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.buttonGenerate = new Button();
            this.buttonStop = new Button();
            this.numericUpDownColNb = new NumericUpDown();
            this.numericUpDownRowNb = new NumericUpDown();
            this.numericUpDownDelay = new NumericUpDown();
            this.radioButton1 = new RadioButton();
            this.radioButton2 = new RadioButton();
            this.label4 = new Label();
            this.plotView1 = new OxyPlot.WindowsForms.PlotView();
            this.canvasOfLife = new Canvas();
            ((System.ComponentModel.ISupportInitialize)this.numericUpDownColNb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.numericUpDownRowNb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.numericUpDownDelay).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(680, 12);
            this.label1.Name = "label1";
            this.label1.Size = new Size(95, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Column number";
            // 
            // label2
            // 
            this.label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(680, 66);
            this.label2.Name = "label2";
            this.label2.Size = new Size(75, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Row number";
            // 
            // label3
            // 
            this.label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(680, 121);
            this.label3.Name = "label3";
            this.label3.Size = new Size(77, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Delay by step";
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.buttonGenerate.Location = new Point(680, 386);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new Size(108, 23);
            this.buttonGenerate.TabIndex = 12;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += this.buttonGenerate_Click;
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new Point(680, 415);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new Size(108, 23);
            this.buttonStop.TabIndex = 13;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += this.buttonStop_Click;
            // 
            // numericUpDownColNb
            // 
            this.numericUpDownColNb.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.numericUpDownColNb.Location = new Point(680, 30);
            this.numericUpDownColNb.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            this.numericUpDownColNb.Name = "numericUpDownColNb";
            this.numericUpDownColNb.Size = new Size(120, 23);
            this.numericUpDownColNb.TabIndex = 9;
            this.numericUpDownColNb.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // numericUpDownRowNb
            // 
            this.numericUpDownRowNb.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.numericUpDownRowNb.Location = new Point(680, 84);
            this.numericUpDownRowNb.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            this.numericUpDownRowNb.Name = "numericUpDownRowNb";
            this.numericUpDownRowNb.Size = new Size(120, 23);
            this.numericUpDownRowNb.TabIndex = 10;
            this.numericUpDownRowNb.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // numericUpDownDelay
            // 
            this.numericUpDownDelay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.numericUpDownDelay.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            this.numericUpDownDelay.Location = new Point(680, 139);
            this.numericUpDownDelay.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.numericUpDownDelay.Name = "numericUpDownDelay";
            this.numericUpDownDelay.Size = new Size(120, 23);
            this.numericUpDownDelay.TabIndex = 11;
            this.numericUpDownDelay.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numericUpDownDelay.ValueChanged += this.numericUpDownDelay_ValueChanged;
            // 
            // radioButton1
            // 
            this.radioButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new Point(681, 202);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new Size(94, 19);
            this.radioButton1.TabIndex = 14;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Game Of Life";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new Point(680, 227);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new Size(57, 19);
            this.radioButton2.TabIndex = 15;
            this.radioButton2.Text = "LENIA";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(680, 184);
            this.label4.Name = "label4";
            this.label4.Size = new Size(67, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "Simulation ";
            // 
            // plotView1
            // 
            this.plotView1.Location = new Point(12, 12);
            this.plotView1.Name = "plotView1";
            this.plotView1.PanCursor = Cursors.Hand;
            this.plotView1.Size = new Size(653, 426);
            this.plotView1.TabIndex = 17;
            this.plotView1.Text = "plotView1";
            this.plotView1.ZoomHorizontalCursor = Cursors.SizeWE;
            this.plotView1.ZoomRectangleCursor = Cursors.SizeNWSE;
            this.plotView1.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // canvasOfLife
            // 
            this.canvasOfLife.Location = new Point(12, 12);
            this.canvasOfLife.Name = "canvasOfLife";
            this.canvasOfLife.Size = new Size(662, 426);
            this.canvasOfLife.TabIndex = 18;
            this.canvasOfLife.Text = "canvas1";
            // 
            // ScreenOfLife
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.canvasOfLife);
            this.Controls.Add(this.plotView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.numericUpDownDelay);
            this.Controls.Add(this.numericUpDownRowNb);
            this.Controls.Add(this.numericUpDownColNb);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.Name = "ScreenOfLife";
            this.Text = "GameOfMelvin";
            ((System.ComponentModel.ISupportInitialize)this.numericUpDownColNb).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.numericUpDownRowNb).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.numericUpDownDelay).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Canvas canvasOfLife;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button buttonGenerate;
        private Button buttonStop;
        private NumericUpDown numericUpDownColNb;
        private NumericUpDown numericUpDownRowNb;
        private NumericUpDown numericUpDownDelay;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Label label4;
        private OxyPlot.WindowsForms.PlotView plotView1;
    }
}