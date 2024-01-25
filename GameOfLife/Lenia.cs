using Microsoft.VisualBasic;
using NumpyDotNet;
using System.Windows.Forms;
using Brush = System.Drawing.Brush;
using Color = System.Drawing.Color;

namespace GameOfLife
{
    internal class Lenia : Simulation
    {
        const int R = 13;
        const double dt = 0.1;

        private ndarray k_lenia;

        ndarray Cells { get; set; }
        public override void Initialize(int nbCol, int nbRow, int delay, Canvas canvas)
        {
            this.Canvas = canvas;
            this.Delay = delay;
            this.k_lenia = this.InitLeniaFilter();

            var random = new np.random();
            Cells = random.rand(new shape(nbCol, nbRow));
            //Cells = np.array(new double[,] {
            //    { 0, 0, 0, 0, 0, 0, 0.1, 0.14, 0.1, 0, 0, 0.03, 0.03, 0, 0, 0.3, 0, 0, 0, 0 },
            //    {0, 0, 0, 0, 0, 0.08, 0.24, 0.3, 0.3, 0.18, 0.14, 0.15, 0.16, 0.15, 0.09, 0.2, 0, 0, 0, 0},
            //    {0, 0, 0, 0, 0, 0.15, 0.34, 0.44, 0.46, 0.38, 0.18, 0.14, 0.11, 0.13, 0.19, 0.18, 0.45, 0, 0, 0},
            //    {0, 0, 0, 0, 0.06, 0.13, 0.39, 0.5, 0.5, 0.37, 0.06, 0, 0, 0, 0.02, 0.16, 0.68, 0, 0, 0},
            //    {0, 0, 0, 0.11, 0.17, 0.17, 0.33, 0.4, 0.38, 0.28, 0.14, 0, 0, 0, 0, 0, 0.18, 0.42, 0, 0},
            //    {0, 0, 0.09, 0.18, 0.13, 0.06, 0.08, 0.26, 0.32, 0.32, 0.27, 0, 0, 0, 0, 0, 0, 0.82, 0, 0},
            //    {0.27, 0, 0.16, 0.12, 0, 0, 0, 0.25, 0.38, 0.44, 0.45, 0.34, 0, 0, 0, 0, 0, 0.22, 0.17, 0},
            //    {0, 0.07, 0.2, 0.02, 0, 0, 0, 0.31, 0.48, 0.57, 0.6, 0.57, 0, 0, 0, 0, 0, 0, 0.49, 0},
            //    {0, 0.59, 0.19, 0, 0, 0, 0, 0.2, 0.57, 0.69, 0.76, 0.76, 0.49, 0, 0, 0, 0, 0, 0.36, 0},
            //    {0, 0.58, 0.19, 0, 0, 0, 0, 0, 0.67, 0.83, 0.9, 0.92, 0.87, 0.12, 0, 0, 0, 0, 0.22, 0.07},
            //    {0, 0, 0.46, 0, 0, 0, 0, 0, 0.7, 0.93, 1, 1, 1, 0.61, 0, 0, 0, 0, 0.18, 0.11},
            //    {0, 0, 0.82, 0, 0, 0, 0, 0, 0.47, 1, 1, 0.98, 1, 0.96, 0.27, 0, 0, 0, 0.19, 0.1},
            //    {0, 0, 0.46, 0, 0, 0, 0, 0, 0.25, 1, 1, 0.84, 0.92, 0.97, 0.54, 0.14, 0.04, 0.1, 0.21, 0.05},
            //    {0, 0, 0, 0.4, 0, 0, 0, 0, 0.09, 0.8, 1, 0.82, 0.8, 0.85, 0.63, 0.31, 0.18, 0.19, 0.2, 0.01},
            //    {0, 0, 0, 0.36, 0.1, 0, 0, 0, 0.05, 0.54, 0.86, 0.79, 0.74, 0.72, 0.6, 0.39, 0.28, 0.24, 0.13, 0},
            //    {0, 0, 0, 0.01, 0.3, 0.07, 0, 0, 0.08, 0.36, 0.64, 0.7, 0.64, 0.6, 0.51, 0.39, 0.29, 0.19, 0.04, 0},
            //    {0, 0, 0, 0, 0.1, 0.24, 0.14, 0.1, 0.15, 0.29, 0.45, 0.53, 0.52, 0.46, 0.4, 0.31, 0.21, 0.08, 0, 0},
            //    {0, 0, 0, 0, 0, 0.08, 0.21, 0.21, 0.22, 0.29, 0.36, 0.39, 0.37, 0.33, 0.26, 0.18, 0.09, 0, 0, 0},
            //    {0, 0, 0, 0, 0, 0, 0.03, 0.13, 0.19, 0.22, 0.24, 0.24, 0.23, 0.18, 0.13, 0.05, 0, 0, 0, 0},
            //    {0, 0, 0, 0, 0, 0, 0, 0, 0.02, 0.06, 0.08, 0.09, 0.07, 0.05, 0.01, 0, 0, 0, 0, 0}
            //    });

            //Cells = np.array(new double[,] {
            //    { 0, 0, 0, 0, 0, 0, 0.1, 0.14, 0.1, 0, 0, 0.03, 0.03, 0, 0, 0.3, 0, 0, 0, 0 },
            //    {0, 0, 0, 0, 0, 0.08, 0.24, 0.3, 0.3, 0.18, 0.14, 0.15, 0.16, 0.15, 0.09, 0.2, 0, 0, 0, 0}
            //});

            this.Canvas?.Refresh();
        }

        public override void Start()
        {
            this.Live = true;
            this.Loop();
        }

        public override void Stop() 
        {
            this.Live = false;
            this.Cells = null;
            this.Canvas?.Refresh();
        }

        protected override async Task Loop()
        {
            while (this.Live)
            {
                this.Cells = this.Evolve(this.Cells);

                this.Canvas?.Refresh();
                await Task.Delay(this.Delay);
            }
        }

        public override void PaintCell(PaintEventArgs pe)
        {
            if (this.Canvas == null)
                return;
            else if(this.Cells == null)
            {
                pe.Graphics.Clear(System.Drawing.Color.White);
                return;
            }

            var colSize = this.Canvas.Width / Cells.Dim(0);
            var rowSize = this.Canvas.Height / Cells.Dim(1);

            
            for (int i = 0; i < Cells.Dim(0); i++) //X
            {
                for (int j = 0; j < Cells.Dim(1); j++) //Y
                {

                    var brush = new SolidBrush(
                        System.Drawing.Color.FromArgb(255, 0, 0, Convert.ToInt32((double)Cells[i,j] * 255)));
                    pe.Graphics.FillRectangle( brush, i * colSize, j * rowSize, colSize, rowSize);
                }
            }
        }
       
        protected ndarray Gauss(ndarray x, double mu, double sigma)
        {
            return np.exp(-0.5 * np.power(((x - mu) / sigma), 2));
        }

        public ndarray InitLeniaFilter()
        {
            // Test
            var t = np.ogrid(new Slice[] { new Slice(-R, R), new Slice(-R, R) });
            var x = (t as ndarray[])[0];
            var y = (t as ndarray[])[1];

            var distance = np.sqrt(np.power(1+x, 2) + np.power(1+y, 2)) / R;

            var mu = 0.5;
            var sigma = 0.15;
            var K = this.Gauss(distance, mu, sigma);
            K[distance > 1] = 0;
            K = K / np.sum(K);

            return K;
        }

        public ndarray Growth(ndarray u)
        {
            var mu = 0.15;
            var sigma = 0.015;
            return -1 + 2 * this.Gauss(u, mu, sigma);
        }

        public ndarray Evolve(ndarray X)
        {


            ndarray output = np.zeros_like(X);

            for(int i = 0; i < X.Dim(0); i++)
            {
                for(int j = 0; j < X.Dim(1); j++)
                {
                    output[i, j] = this.Convolve2d(X, this.k_lenia, i, j);
                }
            }

            var U = output;
            X = X + dt * this.Growth(U);
            X = np.clip(X, 0, 1);
            return X;
        }


        private double Convolve2d(ndarray X, ndarray K, int x, int y)
        {
            double sum = 0.0;
            var rows = X.shape[0];
            var cols = X.shape[1];

            var kRows = K.shape[0];
            var kCols = K.shape[1];

            for(int i = 0; i < kRows; i++)
            {
                for(int j = 0; j < kCols; j++)
                {
                    int xc = (int) mod(x + i - kRows / 2,  rows);
                    int yc = (int) mod(y + j - kCols / 2, cols);
                    sum += (double) X[xc, yc] * (double) K[i, j];
                }
            }

            return sum;

            long mod(long x, long m)
            {
                long r = x % m;
                return r < 0 ? r + m : r;
            }

        }


    }
}
