using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class ScreenOfLife : Form
    {
        public ScreenOfLife()
        {
            InitializeComponent();
        }

        private void Generate()
        {
            this.canvasOfLife.Initialize((int)this.numericUpDownColNb.Value, 
                (int)this.numericUpDownRowNb.Value, 
                (int)this.numericUpDownDelay.Value,
                this.radioButton1.Checked,
                this.plotView1);

            this.canvasOfLife.Start();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            this.Generate();
            this.buttonGenerate.Enabled = false;
            this.buttonStop.Enabled = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            this.canvasOfLife.Stop();
            this.buttonGenerate.Enabled = true;
            this.buttonStop.Enabled = false;
        }

        private void numericUpDownDelay_ValueChanged(object sender, EventArgs e)
        {
            this.canvasOfLife.Delay((int)this.numericUpDownDelay.Value);
        }
    }
}
