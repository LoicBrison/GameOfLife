using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Brush = System.Drawing.Brush;
using Color = System.Drawing.Color;

namespace GameOfLife
{
    internal class Lenia : Simulation
    {
        const int R = 15;

        double[,] Cells { get; set; }
        double[,] NextCells { get; set; }
        public override void Initialize(int nbCol, int nbRow, int delay, Canvas canvas)
        {
            this.Canvas = canvas;
            this.Delay = delay;
            Cells = new double[nbCol, nbRow];
            NextCells = new double[nbCol, nbRow];

            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    Cells[i, j] = new Random().NextDouble();
                }
            }

            NextCells = (double[,])Cells.Clone();

            this.Canvas?.Refresh();
        }
        public override void Start()
        {
            this.Live = true;
            this.Loop();
        }
        public override void Stop() 
        {
            
        }
        protected override async Task Loop()
        {
            while (this.Live)
            {
                for (int i = 0; i < Cells.GetLength(0); i++)
                {
                    for (int j = 0; j < Cells.GetLength(1); j++)
                    {
                        var t = GrowthLenia(i, j);
                        //if (nb == 3)
                        //{
                        //    NextCells[i, j] = true;
                        //}
                        //else if (nb != 2)
                        //{
                        //    NextCells[i, j] = false;
                        //}
                    }
                }

                this.Canvas?.Refresh();
                await Task.Delay(this.Delay);
            }
        }

        public override void PaintCell(PaintEventArgs pe)
        {
            if (this.Canvas == null)
                return;

            var colSize = this.Canvas.Width / Cells.GetLength(0);
            var rowSize = this.Canvas.Height / Cells.GetLength(1);

            int rMax = Color.Red.R;
            int rMin = Color.Black.R;

            int gMax = Color.Green.G;
            int gMin = Color.Black.G;

            int bMax = Color.Blue.B;
            int bMin = Color.Black.B;

          

            for (int i = 0; i < Cells.GetLength(0); i++) //X
            {
                for (int j = 0; j < Cells.GetLength(1); j++) //Y
                {
                    Cells = (double[,])NextCells.Clone();

                    var r = rMin + (int)((rMax - rMin) * Cells[i, j] / 1);
                    var g = gMin + (int)((gMax - gMin) * Cells[i, j] / 1);
                    var b = bMin + (int)((bMax - bMin) * Cells[i, j] / 1);

                    var brush = new SolidBrush(
                        System.Drawing.Color.FromArgb(255,r,g,b));
                    pe.Graphics.FillRectangle( brush, i * colSize, j * rowSize, colSize, rowSize);
                }
            }
        }

        

        protected double CountNeighbor (int x, int y)
        {
            double sum = 0;
            for (int i = -1; i < 2; i++)
            {
                if (x + i >= 0 && x + i < Cells.GetLength(0))
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if (y + j >= 0 && y + j < Cells.GetLength(1))
                        {
                            if (i == 0 && j == 0)
                            {
                                continue;
                            }
                        }
                    }
                }
            }
            return sum; 
        }

        protected double GrowthLenia(int x, int y)
        {
            var mu = 0.5;
            var sigma = 0.1;
            var dist = this.GetDistance(x, y);
            return this.Gauss(dist, mu, sigma);
        }

        protected double Gauss(double dist, double mu, double sigma)
        {
            return Math.Exp(-0.5 * Math.Pow((dist - mu) / sigma, 2));
        }

        protected double GetDistance(int x, int y)
        {
            return Math.Sqrt(Math.Pow((1+x),2) + Math.Pow((1+y),2) / R);
        }
    }
}
