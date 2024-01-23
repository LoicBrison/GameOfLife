using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal abstract class Simulation
    {
        protected bool Live = false;
        public Canvas? Canvas { get; set; }
        public int Delay { get; set; }
        public abstract void Initialize(int nbCol, int nbRow, int delay, Canvas canvas);
        public abstract void Start();
        protected abstract Task Loop();
        public abstract void Stop();
        public abstract void PaintCell(PaintEventArgs pe);
    }
}
