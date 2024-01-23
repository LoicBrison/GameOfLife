using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace GameOfLife
{
    internal class Cell : Control
    {
        private bool isAlive;
        public bool IsAlive { 
            get => isAlive; 
            set {
                isAlive = value;
                if (isAlive)
                    this.BackColor = System.Drawing.Color.Black;
                else
                    this.BackColor = System.Drawing.Color.White;
            }
        }
        public int x { get; set; }
        public int y { get; set; }

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.IsAlive = false;
        }
    }
}
