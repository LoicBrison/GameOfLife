using Numpy;
using Numpy.Models;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System.Drawing.Imaging;
using Brush = System.Drawing.Brush;
using Color = System.Drawing.Color;

namespace GameOfLife
{
    internal class Lenia : Simulation
    {
        const int R = 13;
        const double dt = 0.1;

        private NDarray k_lenia;

        public PlotView PlotView { get; set; }

        NDarray Cells { get; set; }
        PlotModel plotModel;

        public override void Initialize(int nbCol, int nbRow, int delay, Canvas control)
        {
            this.Canvas = control;
            this.Delay = delay;
            this.k_lenia = this.InitLeniaFilter();

            Cells = np.random.rand(new int[] { nbCol, nbRow });

            this.plotModel = new PlotModel { Title = "Heatmap" };
            this.plotModel.Axes.Add(new LinearColorAxis
            {
                Palette = OxyPalettes.Inferno(255)
            });


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

                var CellsArr = new double[Cells.shape.Dimensions[0], Cells.shape.Dimensions[1]];

                for (int i = 0; i < Cells.shape.Dimensions[0]; i++) //X
                {
                    for (int j = 0; j < Cells.shape.Dimensions[1]; j++) //Y
                    {
                        CellsArr[i, j] = (double)Cells[i, j];
                    }
                }

                var heatMapSeries = new HeatMapSeries
                {
                    X0 = 0,
                    X1 = 1,
                    Y0 = 0,
                    Y1 = 1,
                    Interpolate = false,
                    RenderMethod = HeatMapRenderMethod.Bitmap,
                    Data = CellsArr
                };

                this.plotModel.Series.Clear();
                this.PlotView.InvalidatePlot(true);

                this.plotModel.Series.Add(heatMapSeries);
                this.PlotView.Model = this.plotModel;
                this.PlotView.Refresh();
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

           

            

            
            //this.Control.Refresh();
            ////////// WHITOUT COLOR MAP //////////

            //var colSize = this.Canvas.Width / Cells.shape.Dimensions[0];
            //var rowSize = this.Canvas.Height / Cells.shape.Dimensions[1];

            //int rMax = Color.Red.R;
            //int rMin = Color.Black.R;

            //int gMax = Color.Green.G;
            //int gMin = Color.Black.G;

            //int bMax = Color.Blue.B;
            //int bMin = Color.Black.B;

            //for (int i = 0; i < Cells.shape.Dimensions[0]; i++) //X
            //{
            //    for (int j = 0; j < Cells.shape.Dimensions[1]; j++) //Y
            //    {
            //        //var r = rMin + (int)((rMax - rMin) * (double) Cells[i, j] / 1);
            //        //var g = gMin + (int)((gMax - gMin) * (double) Cells[i, j] / 1);
            //        //var b = bMin + (int)((bMax - bMin) * (double) Cells[i, j] / 1);

            //        var brush = new SolidBrush(
            //            System.Drawing.Color.FromArgb(255, 0, 0, Convert.ToInt32((double)Cells[i, j] * 255)));
            //        pe.Graphics.FillRectangle(brush, i * colSize, j * rowSize, colSize, rowSize);
            //    }
            //}
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

            var padHeight = (int)np.floor_divide((NDarray)kRows, (NDarray)2);
            var padWidth = (int)np.floor_divide((NDarray)kCols, (NDarray)2);

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
