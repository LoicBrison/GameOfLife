using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class GameOfLife : Simulation
    {
        bool[,] Cells { get; set; }
        bool[,] NextCells { get; set; }
        public override void Initialize(int nbCol, int nbRow, int delay, Canvas canvas)
        {
            this.Canvas = canvas;
            this.Delay = delay;
            Cells = new bool[nbCol, nbRow];
            NextCells = new bool[nbCol, nbRow];

            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    Cells[i, j] = new Random().Next(0, 2) == 1;
                }
            }

            NextCells = (bool[,])Cells.Clone();

            this.Canvas?.Refresh();
        }

        public override void Start()
        {
            this.Live = true;
            this.Loop();
        }

        protected override async Task Loop()
        {
            while (this.Live)
            {
                for (int i = 0; i < Cells.GetLength(0); i++)
                {
                    for (int j = 0; j < Cells.GetLength(1); j++)
                    {
                        var nb = CountNeighbor(i, j);
                        if (nb == 3)
                        {
                            NextCells[i, j] = true;
                        }
                        else if (nb != 2)
                        {
                            NextCells[i, j] = false;
                        }
                    }
                }

                this.Canvas?.Refresh();
                await Task.Delay(this.Delay);
            }
        }

        public override void Stop()
        {
            this.Live = false;
            this.Cells = new bool[1, 1];
            this.NextCells = new bool[1, 1];
            this.Canvas?.Refresh();
        }

        public override void PaintCell(PaintEventArgs pe)
        {
            if(this.Canvas == null)
                return;

            var colSize = this.Canvas.Width / Cells.GetLength(0);
            var rowSize = this.Canvas.Height / Cells.GetLength(1);

            for (int i = 0; i < Cells.GetLength(0); i++) //X
            {
                for (int j = 0; j < Cells.GetLength(1); j++) //Y
                {
                    Cells = (bool[,])NextCells.Clone();
                    var color = Cells[i, j] ? Brushes.Black : Brushes.White;
                    pe.Graphics.FillRectangle(color, i * colSize, j * rowSize, colSize, rowSize);
                }
            }
        }

        protected int CountNeighbor(int x, int y)
        {
            var nb = 0;
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
                            if (Cells[x + i, y + j])
                            {
                                nb++;
                            }
                        }
                    }
                }
            }
            return nb;
        }
    }
}
