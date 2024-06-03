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
    public partial class letterBox : Button
    {
        //Declares the three local variables for the classes colour, by default they are set to the dark mode variant
        private Color _baseColour = Color.FromArgb(20,20,20);
        private Color _alternateColour = Color.FromArgb(75,75,75);
        private Color _textColour = Color.White;
        //Declares the local letter variable with the default as empty
        private string _letter = "";
        //Declares the local variable for status with the default value of -1,
        //this signals the box is empty as 0 means an incorrect letter already
        private int _status = -1;

        //Public letter variable with get set method
        public string letter
        {
            //Get method that plays when the variable is read, returning the local variable
            get { return _letter; }
            set { 
                //Sets the local variable to the new value
                _letter = value; 
                //Redraws the whole object which plays the onpaint method which will draw the letter
                Invalidate();
            }
        }
        //three colours public variable with get set method
        public Color baseColour
        {
            get { return _baseColour; }
            set
            {
                _baseColour = value;
                //Changes the objects back color to the new value
                this.BackColor = baseColour;
                
            }
        }
        public Color alternateColour
        {
            get { return _alternateColour; }
            set
            {
                _alternateColour = value;
                //Changes the objects border color to the new value
                this.FlatAppearance.BorderColor = alternateColour;
                
            }
        }
        public Color textColour
        {
            get { return _textColour; }
            set
            {
                _textColour = value;
                //Changes the objects fore color to the new value
                this.ForeColor = textColour;
            }
        }
        //Public status variable with get set method
        public int status 
        { 
            get { return _status; }
            set {  _status = value; }
        } 

        public letterBox()
        {
            InitializeComponent();
            //Sets the default values for the object so when a developer places it onto the form
            //from the toolbox they are all the same and work properly
            this.Width = 125;
            this.Height = 125;
            this.Padding = new Padding(6,0,0,0);
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 3;
            this.FlatAppearance.BorderColor = _alternateColour;
            this.BackColor = _baseColour;
            this.Text = "";
            this.Enabled = false;
            this.ForeColor = _baseColour;
        }

        //Onpaint method that plays whenever the form is being rendered, mainly on launch and after the invalidate method
        protected override void OnPaint(PaintEventArgs e)
        {
            //Declares a font for the central letter
            Font letterFont = new Font("Arial", 24, FontStyle.Bold);

            //Declares the graphics objects to perform the drawing
            base.OnPaint(e);
            Graphics g = e.Graphics;

            //Declares the position variables that mean the letter is centered using the width of the string and class to calculate
            int x = (ClientSize.Width - (int)g.MeasureString(letter, letterFont).Width) / 2;
            int y = (ClientSize.Height - (int)g.MeasureString(letter, letterFont).Height) / 2;

            //Declares a new brush with the text color
            Brush brush = new SolidBrush(this.textColour);

            //Draws the string in the middle of the object
            g.DrawString(letter, letterFont, brush, x, y);
        }
    }
}
