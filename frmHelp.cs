using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wordle_SDD.Properties;

namespace Wordle_SDD
{
    public partial class frmHelp : Form
    {
        //Defines all of the public colour variables with their default Dark Mode variants
        public Color baseColour = Color.FromArgb(20, 20, 20);
        public Color alternateColour = Color.FromArgb(75, 75, 75);
        public Color tertiaryColour = Color.DimGray;
        public Color correctColour = Color.FromArgb(83, 141, 78);
        public Color partialColour = Color.FromArgb(181, 159, 59);
        public Color textColour = Color.White;

        //Creates a new soundPlayer object with the audio file from resources file
        private SoundPlayer soundPlayer = new SoundPlayer(Resources.audioHelpMenuVoiceOver);

        //Defines the local variants of the two public booleans
        private bool _darkMode = true;
        private bool _highContrastMode = false;

        public bool darkMode
        {
            //Get method that plays when the boolean is read
            get { return _darkMode; }
            //Set method that plays when the boolean is changed
            set
            {
                //Assigns the local variant variable to the same value
                _darkMode = value;

                //Changes the back colour
                this.BackColor = baseColour;

                //For loop for all 40 example letterBoxes
                for (int i = 0; i <= 39; i++)
                {
                    //Creates string for this iterations desired letterbox
                    string selectedLetterBox = $"exampleLB{i}";

                    //Searches through all controls on the page
                    foreach (Control control in Controls)
                    {
                        //Runs code once the letterBox that matches the string defined earlier
                        //is found and allows us to use the simple LetterBox name to augment it
                        if (control.Name == selectedLetterBox && control is letterBox letterBox)
                        {
                            //Checks whether the letterBox has already been filled with a letter in
                            //the correct spot (status = 2), thus changing the shade of green to lighter/darker
                            if (letterBox.status == 2)
                            {
                                letterBox.baseColour = correctColour;
                                letterBox.alternateColour = correctColour;
                            }
                            //Checks whether the letterBox has already been filled with a letter in a
                            //partially correct spot (status = 1), thus changing the shade of yellow to lighter/darker
                            else if (letterBox.status == 1)
                            {
                                letterBox.baseColour = partialColour;
                                letterBox.alternateColour = partialColour;
                            }
                            //Checks whether the letterBox has already been filled with a letter in the
                            //incorrect spot (status = 0), thus changing the full colour grey to the lighter/darker
                            else if (letterBox.status == 0)
                            {
                                letterBox.baseColour = alternateColour;
                                letterBox.alternateColour = alternateColour;
                            }
                            //If all other checks have failed the letterbox must not have had a letter entered
                            //into it, thus the colour changes retain the border and the correct text colour
                            else
                            {
                                letterBox.baseColour = baseColour;
                                letterBox.alternateColour = alternateColour;
                                letterBox.textColour = textColour;
                            }
                        }

                        //Runs code when this pass of the search is a label, so all labels receive the same code
                        if (control is Label label)
                        {
                            //Changes the text colour of the label to the appropriate white or black
                            label.ForeColor = textColour;
                        }
                    }
                }

                //Changes the border colour to the correct light/dark for both buttons
                btnClose.ForeColor = baseColour;
                btnVoiceOver.ForeColor = baseColour;

                //Changes the two buttons image to the appropriate light/dark variant
                if (darkMode == true)
                {
                    btnClose.BackgroundImage = Resources.imgCrossIconLight;
                    btnVoiceOver.BackgroundImage = Resources.imgSpeakerDark;
                }
                else
                {
                    btnClose.BackgroundImage = Resources.imgCrossIconDark;
                    btnVoiceOver.BackgroundImage = Resources.imgSpeakerLight;
                }
            }
        }
        public bool highContrastMode
        {
            //Get method that plays when the boolean is read
            get { return _highContrastMode; }
            //Set method that plays when the boolean is changed
            set
            {
                //Changes the local variable to the same value
                _highContrastMode = value;

                //Checks if high Contrast was changed to true
                if (highContrastMode == true)
                {
                    //Assigns both partial and correct to their HC values
                    correctColour = Colours.highContrastCorrectColour;
                    partialColour = Colours.highContrastPartialColour;
                }
                //If high contrast was not true it must mean that it is being turned off, thus we have to change the variables to dark or light variants
                else if (darkMode == true)
                {
                    //Assigns both partial and correct to their dark variants
                    correctColour = Colours.darkCorrectColour;
                    partialColour = Colours.darkPartialColour;
                }
                else
                {
                    //Assigns both partial and correct to their light variants
                    correctColour = Colours.lightCorrectColour;
                    partialColour = Colours.lightPartialColour;
                }
                //Searches through all controls on the page
                foreach (Control control in Controls)
                {
                    //Calls code only when this iterations control is a letterBox
                    if (control is letterBox letterBox)
                    {
                        //Checks whether the letterBox has already been filled with a letter in
                        //the correct spot (status = 2), thus changing the shade of green to lighter/darker
                        if (letterBox.status == 2)
                        {
                            letterBox.baseColour = correctColour;
                            letterBox.alternateColour = correctColour;
                        }
                        //Checks whether the letterBox has already been filled with a letter in a
                        //partially correct spot (status = 1), thus changing the shade of yellow to lighter/darker
                        else if (letterBox.status == 1)
                        {
                            letterBox.baseColour = partialColour;
                            letterBox.alternateColour = partialColour;
                        }
                        //Checks whether the letterBox has already been filled with a letter in the
                        //incorrect spot (status = 0), thus changing the full colour grey to the lighter/darker
                        else if (letterBox.status == 0)
                        {
                            letterBox.baseColour = alternateColour;
                            letterBox.alternateColour = alternateColour;
                        }
                        //If all other checks have failed the letterbox must not have had a letter entered
                        //into it, thus the colour changes retain the border and the correct text colour
                        else
                        {
                            letterBox.baseColour = baseColour;
                            letterBox.alternateColour = alternateColour;
                            letterBox.textColour = textColour;
                        }
                    }
                }
            }
        }
                
        public frmHelp()
        {
            //Plays the designer code
            InitializeComponent();

            //Attaches the closing event to the frmHelp_Close method
            this.FormClosing += new FormClosingEventHandler(this.frmHelp_Close);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //Closes this form
            this.Close();
        }

        private void btnVoiceOver_Click(object sender, EventArgs e)
        {
            //Plays the soundplayer defined earlier
            soundPlayer.Play();
        }

        private void frmHelp_Close(object sender, FormClosingEventArgs e)
        {
            //Stops the soundplayer if the form is closed
            soundPlayer.Stop();
        }
    }
}
