using Numpy;
using Numpy.Models;
using Brush = System.Drawing.Brush;
using Color = System.Drawing.Color;

namespace GameOfLife
{
    internal class Lenia : Simulation
    {
        const int R = 13;
        const double dt = 0.1;

        private NDarray k_lenia;

        NDarray Cells { get; set; }
        public override void Initialize(int nbCol, int nbRow, int delay, Canvas canvas)
        {
            this.Canvas = canvas;
            this.Delay = delay;
            this.k_lenia = this.InitLeniaFilter();

            Cells = np.random.rand(new int[] { nbCol, nbRow });
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
            else if (this.Cells == null)
            {
                pe.Graphics.Clear(System.Drawing.Color.White);
                return;
            }

            
            var colSize = this.Canvas.Width / Cells.shape.Dimensions[0];
            var rowSize = this.Canvas.Height / Cells.shape.Dimensions[1];

            int rMax = Color.Red.R;
            int rMin = Color.Black.R;

            int gMax = Color.Green.G;
            int gMin = Color.Black.G;

            int bMax = Color.Blue.B;
            int bMin = Color.Black.B;

            for (int i = 0; i < Cells.shape.Dimensions[0]; i++) //X
            {
                for (int j = 0; j < Cells.shape.Dimensions[1]; j++) //Y
                {
                    //var r = rMin + (int)((rMax - rMin) * (double) Cells[i, j] / 1);
                    //var g = gMin + (int)((gMax - gMin) * (double) Cells[i, j] / 1);
                    //var b = bMin + (int)((bMax - bMin) * (double) Cells[i, j] / 1);

                    var brush = new SolidBrush(
                        System.Drawing.Color.FromArgb(255, 0, 0, Convert.ToInt32((double)Cells[i, j] * 255)));
                    pe.Graphics.FillRectangle(brush, i * colSize, j * rowSize, colSize, rowSize);
                }
            }
        }

        protected NDarray Gauss(NDarray x, double mu, double sigma)
        {
            return np.exp(-0.5 * np.power(((x - mu) / sigma), (NDarray)2));
        }

        public NDarray InitLeniaFilter()
        {
            var x = np.arange(-R, R, 1);
            var y = np.arange(-R, R, 1);
            
            x = x.reshape(-1, 1);  //Column vector
            y = y.reshape(1, -1);

            var distance = np.sqrt(np.power(1 + x, (NDarray)2) + np.power(1 + y, (NDarray)2)) / R;

            var mu = 0.5;
            var sigma = 0.15;
            var K = this.Gauss(distance, mu, sigma);
            K[distance > 1] = (NDarray)0;
            K = K / np.sum(K);

            return K;
        }

        public NDarray Growth(NDarray u)
        {
            var mu = 0.15;
            var sigma = 0.015;
            return -1 + 2 * this.Gauss(u, mu, sigma);
        }

        public NDarray Evolve(NDarray X)
        {
            var U = this.Convolve2d_2(X, this.k_lenia);
            X = X + dt * this.Growth(U);
            X = np.clip(X, (NDarray)0, (NDarray)1);
            return X;
        }

        private NDarray Convolve2d(NDarray X, NDarray K)
        {
            var rows = X.shape[0];
            var cols = X.shape[1];

            var kRows = K.shape[0];
            var kCols = K.shape[1];

            var output = np.zeros_like(X);

            var padHeight = kRows - 1;
            var padWidth = kCols - 1;
            var paddedInput = np.zeros(new Shape(rows + (2 * padHeight), cols + (2 * padWidth)));
            paddedInput[new Slice(padHeight, rows + padHeight), new Slice(padWidth, cols + padWidth)] = X;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    var xSlice = new Slice(i, i + kRows);
                    var ySlice = new Slice(j, j + kCols);
                    var tmp = paddedInput[xSlice, ySlice] * K;
                    output[i, j] = np.sum(tmp);
                }
            }

            return output;
        }

        private NDarray Convolve2d_2(NDarray X, NDarray K)
        {
            var rows = X.shape[0];
            var cols = X.shape[1];

            var kRows = K.shape[0];
            var kCols = K.shape[1];

            var output = np.zeros_like(X);

            var padHeight = (int) np.floor_divide((NDarray)kRows, (NDarray)2);
            var padWidth = (int) np.floor_divide((NDarray)kCols, (NDarray)2);

            var ndarray = np.array(new int[,] { { padHeight, padHeight }, { padWidth, padWidth } });
            var paddedInput = np.pad(X, ndarray, "wrap");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    var xSlice = new Slice(i, i + kRows);
                    var ySlice = new Slice(j, j + kCols);
                    var region = paddedInput[xSlice, ySlice];
                    output[i, j] = np.sum(region * K);
                }
            }

            return output;
        }
    }
}
