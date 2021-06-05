using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Cell : UserControl
    {
        public int row { get; set; }
        public int col { get; set; }

        public Cell(int row, int col)
        {
            InitializeComponent();
            Name = row.ToString() + ", " + col.ToString();
            this.row = row;
            this.col = col;
        }
        
        public int CellColor
        {
            set
            {
                BackColor = Color.FromArgb(value);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, 1, ButtonBorderStyle.Inset
                , Color.Black, 1, ButtonBorderStyle.Inset
                , Color.Black, 1, ButtonBorderStyle.Inset
                ,Color.Black, 1, ButtonBorderStyle.Inset);
        }
    }
}
