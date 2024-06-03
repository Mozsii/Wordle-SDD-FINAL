using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wordle_SDD.Properties;

namespace Wordle_SDD
{
    public partial class frmSettings : Form
    {
        //Creates FrmWordle instance to refer to variables on that form
        private frmWordle FrmWordle = new frmWordle();
        //Accepts the instance of frmWordle assigned
        //to this form when it was instantiated

        private bool justOpenedFlag;

        public frmSettings(frmWordle frmWordleInstance)
        {
            //Constructs form
            InitializeComponent();
            //Makes the new instance of the wordle form equal
            //to the one already on screen, enabling us to actively edit
            //variables and invoke methods to instantly perform the
            //necessary visual augments of dark mode
            FrmWordle = frmWordleInstance;
            //Checks if the main form is in dark mode or not and assigns the appropriate value here
            //This is so when you change the mode, close the settings form and then reopen it it is on the correct setting
            if (FrmWordle.darkMode == true )
            {
                chkDarkMode.Checked = true;
            }
            else 
            { 
                chkDarkMode.Checked = false; 
            }
            //Completes the same check for checkDictionary
            if (FrmWordle.checkDictionary == true )
            {
                chkCheckDictionary.Checked = true;
            }
            else
            {
                chkCheckDictionary.Checked = false;
            }
            //Completes the same check for highContrast
            if (FrmWordle.highContrast == true)
            {
                chkHighContrast.Checked = true;
            }
            else
            {
                chkHighContrast.Checked = false;
            }
            //Completes the same check for hardMode
            if (FrmWordle.hardMode == true)
            {
                //Sets the justOpened flag to true
                justOpenedFlag = true;
                chkHardMode.Checked = true;
            }
            else
            {
                chkHardMode.Checked = false;
            }
        }

        //Method that handles the chkDarkMode checkedChanged event
        private void chkDarkMode_CheckedChanged(object sender, EventArgs e)
        {            
            //Checks whether the darkMode check was changed to true or false
            //In this case true
            if (chkDarkMode.Checked == true)
            {
                //Changes the btn close image to the dark mode variant
                btnClose.BackgroundImage = Resources.imgCrossIconLight;

                //Changes all of the main forms public colour variables to the dark variant
                FrmWordle.baseColour = Colours.darkBaseColour;
                FrmWordle.alternateColour = Colours.darkAlternateColour;
                FrmWordle.tertiaryColour = Colours.darkTertiaryColour;
                FrmWordle.correctColour = Colours.darkCorrectColour;
                FrmWordle.partialColour = Colours.darkPartialColour;
                FrmWordle.textColour = Colours.darkTextColour;
                //Finally changes the main forms dark mode bool, calling the set method
                FrmWordle.darkMode = true;
                
            }
            //In this case false
            else
            {
                //Changes the btn close image to the dark mode variant
                btnClose.BackgroundImage = Resources.imgCrossIconDark;

                //Changes all of the main forms public colour variables to the light variant
                FrmWordle.baseColour = Colours.lightBaseColour;
                FrmWordle.alternateColour = Colours.lightAlternateColour;
                FrmWordle.tertiaryColour = Colours.lightTertiaryColour;
                FrmWordle.correctColour = Colours.lightCorrectColour;
                FrmWordle.partialColour = Colours.lightPartialColour;
                FrmWordle.textColour = Colours.lightTextColour;
                //Finally changes the main forms dark mode bool, calling the set method
                FrmWordle.darkMode = false;
            }
            //Changes all of the graphics on this form according to the variables just changed above
            this.BackColor = FrmWordle.baseColour;
            btnClose.ForeColor = FrmWordle.baseColour;
            chkDarkMode.ForeColor = FrmWordle.textColour;
            chkCheckDictionary.ForeColor = FrmWordle.textColour;
            chkHighContrast.ForeColor = FrmWordle.textColour;
            lblGraphicsTitle.ForeColor = FrmWordle.textColour;
            lblChkDictWarning.ForeColor = FrmWordle.textColour;
            lblHardModeWarning.ForeColor = FrmWordle.textColour;
            chkHardMode.ForeColor = FrmWordle.textColour;
        }

        //Method that handles the chkHighContrast checkedChanged event
        private void chkHighContrast_CheckedChanged(object sender, EventArgs e)
        {
            //This method does not change any colours directly as it is done by the set method on the main form
            //This is because the high contrast mode is also used by darkMode

            //Checks whether the check box was checked or unchecked

            //In this case checked
            if (chkHighContrast.Checked == true)
            {
                //Changes the main forms bool and calls the set method
                FrmWordle.highContrast = true;
            }
            //In this case unchecked
            else
            {
                //Changes the main forms bool and calls the set method
                FrmWordle.highContrast = false;
            }
        }

        //Method that handles the chkCheckDictionary checkedChanged event
        private void chkCheckDictionary_CheckedChanged(object sender, EventArgs e)
        {
            //Checks whether the check box was checked or unchecked

            //In this case checked
            if (chkCheckDictionary.Checked == true)
            {
                //Changes the main forms checkDictionary bool
                FrmWordle.checkDictionary = true;
            }
            //In this case unchecked
            else
            {
                //Changes the main forms checkDictionary bool 
                FrmWordle.checkDictionary = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //Closes this form
            Close();
        }

        //Method that handles the chkHardMode checkedChanged event
        private void chkHardMode_CheckedChanged(object sender, EventArgs e)
        {
            //Guard clause to not reset the game if the form was just opened
            //This is to prevent the game from resetting when the settings
            //form is opened mid game with hardmode on as it will trigger
            //the checkedchanged method
            if (justOpenedFlag == true)
            {
                justOpenedFlag = false;
                return;
            }
            if (chkHardMode.Checked == true)
            {
                //Changes the main forms hardMode bool 
                FrmWordle.hardMode = true;
            }
            //In this case unchecked
            else
            {
                //Changes the main forms hardMode bool
                FrmWordle.hardMode = false;
            }
            //Calls the frmWordle game reset function so the game restarts with hard mode now on
            FrmWordle.gameReset();
        }
    }
}
