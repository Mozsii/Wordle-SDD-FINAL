using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wordle_SDD
{
    public partial class UILine : UserControl
    {
        private Color _alternateColour = Colours.darkAlternateColour;

        public Color alternateColour
        {
            get { return _alternateColour; }
            set {
                _alternateColour = value;
                Invalidate();            
            }
        }


        public UILine()
        {
            InitializeComponent();
            this.Width = 300;
            this.Height = 3;
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            ControlPaint.DrawBorder(g, ClientRectangle,
                alternateColour, 0, ButtonBorderStyle.Solid,
                alternateColour, 1, ButtonBorderStyle.Solid,
                alternateColour, 0, ButtonBorderStyle.Solid,
                alternateColour, 0, ButtonBorderStyle.Solid
                );
        }
    }
}
