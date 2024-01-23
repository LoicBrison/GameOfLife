using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Brush = System.Drawing.Brush;
using Brushes = System.Drawing.Brushes;
using Color = System.Windows.Media.Color;

namespace GameOfLife
{
    internal class Canvas : Control
    {
        private Simulation simulation;

        public Canvas()
        {
            this.SetStyle(ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer, true);
        }

        public void Initialize(int nbCol, int nbRow, int delay, bool isGameOfLife)
        {
            this.simulation = isGameOfLife ? new GameOfLife() : new Lenia();
            this.simulation?.Initialize(nbCol, nbRow, delay, this);
        }

        public void Start()
        {
            this.simulation?.Start();
        }
        public void Stop()
        {
            this.simulation?.Stop();
            this.simulation = null;
        }

        public void Delay(int delay)
        {
            if(simulation != null)
                this.simulation.Delay = delay;   
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.simulation?.PaintCell(e);
        }
    }
}
