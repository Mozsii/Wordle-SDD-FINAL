
//Student Name: George Allman  Grade: Twelve
//Assesment Task: Two          Year: 2024

//Declaration:
//I hereby certify that this assignment is entirely my own work,
//except where i have acknowledged all material and sources used
//in the preparation of the assignment. I certify 'that all
//typing/keystrokes have been done by me.

//I also certify that the material contained in this assignment has not been previously 'submitted by me for assessment in any formal course of study, and that i have not copied 'in part or whole, or otherwise plagiarised the work of other students and/or persons.

//This program is designed as a free user friendly, interactive and recreational product.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wordle_SDD.Properties;

namespace Wordle_SDD
{
	public partial class frmWordle : Form
	{
		//Declares the local variables for all of the public
		//booleans and colours, signifys the local variant with an '_' prefix
		private int currentRow = 0;
		private int currentColumn = 0;
		private char[,] letterGrid = new char[5, 6];
		private string correctWord = "";
        private int[] resultArray = new int[5];
        private int numberCorrectLetters = 0;
		private int animationLength = 2;
		private string[] wordListArray;
		private bool animationOngoing = false;

		//Declares instance of this form to pass through to the other forms
		private frmHelp FrmHelp = new frmHelp();


        //Declares the public variables, they will be accessed by the frmSettings so thus need to be public
        public Color baseColour = Color.FromArgb(20, 20, 20);
		public Color alternateColour = Color.FromArgb(75, 75, 75);
		public Color tertiaryColour = Color.DimGray;
		public Color correctColour = Color.FromArgb(83, 141, 78);
		public Color partialColour = Color.FromArgb(181, 159, 59);
		public Color textColour = Color.White;
		public bool checkDictionary = true;
		public bool hardMode = false;

		

		//Declares a local variable of _darkMode to assign the initial value of the public darkMode variable
		private bool _darkMode = true;

		//Declares a local variable of _highContrast to assign the initial value of the public hightContrast variable
		private bool _highContrast = false;

		//Declares the public darkMode variable, using the get & set method to enable
		//both a value to be received (get) and code to play when the value is altered (set)
		//This allows all of the visual augments of swapping between darkmode and lightmode
		//to be intuitively ran whenever the boolean is swapped.
		public bool darkMode
		{
            //Get method that plays when the boolean is read
            get { return _darkMode; }
            //Set method that plays when the boolean is changed
            set
            { 
				//Alters the private variable to the new value that has just been passed
				_darkMode = value;
				//Assigns the unique controls(all controls that are not the onscreen keyboard or letterBoxes) to the relevant colour
				btnHelp.ForeColor = baseColour;
				btnSettings.ForeColor = baseColour;
				lblTitle.ForeColor = textColour;
				this.BackColor = baseColour;
                linUIline.alternateColour = alternateColour;

                //Changes the two icon-buttons to the appropriate img out of the resources file
                if (darkMode == true)
				{
					btnHelp.BackgroundImage = Resources.imgHelpIconLight;
					btnSettings.BackgroundImage = Resources.imgSettingsIconLight;
				}
				else
				{
					btnHelp.BackgroundImage = Resources.imgHelpIconDark;
					btnSettings.BackgroundImage = Resources.imgSettingsIconDark;
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
                    if (control is Button button) // Assuming letterboxes are TextBox controls
                    {
                        //This if condition differentiates the buttons of the onscreen keyboard
                        //from the navigation buttons and inherited button properties of the letterBoxes
                        if (button.Name.StartsWith("btn") &&
                           (button.Name.Length == 4 || // Single character buttons (btnA to btnZ)
                            button.Name == "btnEnter" || // Special buttons
                            button.Name == "btnDelete")) // Special buttons
                        {
                            //Checks whether the button has already been filled with a colour to represent its
                            //correct status in the grid, thus changing the shade of green to lighter/darker
                            if (button.BackColor == Colours.lightCorrectColour || button.BackColor == Colours.darkCorrectColour || button.BackColor == Colours.highContrastCorrectColour)
                            {
                                button.BackColor = correctColour;
                                button.ForeColor = Colours.darkTextColour;
                            }
                            //Checks whether the button has already been filled with a colour to represent its
                            //partially correct status in the grid, thus changing the shade of yellow to lighter/darker
                            else if (button.BackColor == Colours.lightPartialColour || button.BackColor == Colours.darkPartialColour || button.BackColor == Colours.highContrastPartialColour)
                            {
                                button.BackColor = partialColour;
                                button.ForeColor = Colours.darkTextColour;
                            }
                            //Checks whether the button has already been filled with a colour to represent its
                            //incorrect status in the grid, thus changing the shade of grey to lighter/darker
                            else if (button.BackColor == Colours.lightAlternateColour || button.BackColor == Colours.darkAlternateColour)
                            {
                                button.BackColor = alternateColour;
                                button.ForeColor = Colours.darkTextColour;
                            }
                            else
                            {
                                button.BackColor = tertiaryColour;
                                button.ForeColor = textColour;
                            }
                            //All buttons have the same border colour thus it gets excluded from the if statement
                            button.FlatAppearance.BorderColor = alternateColour;

                        }
                    }
                }

				//Sets all of the colour variables on the help form to what they are on this form
				FrmHelp.textColour = textColour;
                FrmHelp.correctColour = correctColour;
				FrmHelp.partialColour = partialColour;
				FrmHelp.baseColour = baseColour;
				FrmHelp.alternateColour = alternateColour;
				//Changes the dark mode bool on the help menu, activating the set method which repaints that form
				FrmHelp.darkMode = darkMode;

				//Calls the highContrast set method again without changing the value to repaint
				//anything that was wrongly changed in the dark mode get method
				highContrast = highContrast;
				
            }
		}

		//Public highContrast mode variable with get, set methods to call code when the variable has its value changed
		public bool highContrast
		{
            //Get method that plays when the boolean is read
            get { return _highContrast; }
            //Set method that plays when the boolean is changed
            set
            {
				//Stores the updated value in the local variable
				_highContrast = value;

				//Changes the correct and partial colour variables, which are the only things that the high contrast mode alters
				//It first checks if high contrast mode is on and will change the variables appropriately, if it is not on it
				//means we are turning off high contrast mode and thus have to check whether it is dark mode or light mode
				if (highContrast == true)
				{
					correctColour = Colours.highContrastCorrectColour;
					partialColour = Colours.highContrastPartialColour;
				}
				else if (darkMode == true)
				{
					correctColour = Colours.darkCorrectColour;
					partialColour = Colours.darkPartialColour;
				}
				else
				{
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
					if (control is Button button) // Assuming letterboxes are TextBox controls
					{
						//This if condition differentiates the buttons of the onscreen keyboard
						//from the navigation buttons and inherited button properties of the letterBoxes
						if (button.Name.StartsWith("btn") &&
						   (button.Name.Length == 4 || // Single character buttons (btnA to btnZ)
							button.Name == "btnEnter" || // Special buttons
							button.Name == "btnDelete")) // Special buttons
						{
							//Checks whether the button has already been filled with a colour to represent its
							//correct status in the grid, thus changing the shade of green to lighter/darker
							if (button.BackColor == Colours.lightCorrectColour || button.BackColor == Colours.darkCorrectColour || button.BackColor == Colours.highContrastCorrectColour)
							{
								button.BackColor = correctColour;
								button.ForeColor = Colours.darkTextColour;
							}
							//Checks whether the button has already been filled with a colour to represent its
							//partially correct status in the grid, thus changing the shade of yellow to lighter/darker
							else if (button.BackColor == Colours.lightPartialColour || button.BackColor == Colours.darkPartialColour || button.BackColor == Colours.highContrastPartialColour)
							{
								button.BackColor = partialColour;
								button.ForeColor = Colours.darkTextColour;
							}
							//Checks whether the button has already been filled with a colour to represent its
							//incorrect status in the grid, thus changing the shade of grey to lighter/darker
							else if (button.BackColor == Colours.lightAlternateColour || button.BackColor == Colours.darkAlternateColour)
							{
								button.BackColor = alternateColour;
								button.ForeColor = Colours.darkTextColour;
							}
							else
							{
								button.BackColor = tertiaryColour;
								button.ForeColor = textColour;
							}
							//All buttons have the same border colour thus it gets excluded from the if statement
							button.FlatAppearance.BorderColor = alternateColour;

						}
					}
				}

				//Changes and calls the help forms high contrast variable.
				//Because the method on this form is called after darkMode plays and when the variable is changed,
				//the following method will also be called every time darkMode or highContrast is changed
				FrmHelp.highContrastMode = highContrast;
			}
		}

		public frmWordle()
		{
			//Calls the constructor
			InitializeComponent();
			
			//Sets the forms icon to the logo.ico file in the resources
			//folder so it is continous across devices
			this.Icon = Resources.wordleLogo;


            //Attaches any physical keypresses to the event handler
            //KeyPreview enables key presses to be interpretted at
            //the form level, enabling the use of btn.performClick,
            //unifying the two keyboards under the same code
            this.KeyDown += frmWordle_KeyDown;
			this.KeyPreview = true;
			//Attaches all of the onscreen keys to the event handler 'KeyboardInput'
			btnA.Click += keyboardInput;
			btnB.Click += keyboardInput;
			btnC.Click += keyboardInput;
			btnD.Click += keyboardInput;
			btnE.Click += keyboardInput;
			btnF.Click += keyboardInput;        
			btnG.Click += keyboardInput;
			btnH.Click += keyboardInput;
			btnI.Click += keyboardInput;
			btnJ.Click += keyboardInput;
			btnK.Click += keyboardInput;
			btnL.Click += keyboardInput;
			btnM.Click += keyboardInput;
			btnN.Click += keyboardInput;
			btnO.Click += keyboardInput;
			btnP.Click += keyboardInput;
			btnQ.Click += keyboardInput;
			btnR.Click += keyboardInput;
			btnS.Click += keyboardInput;
			btnT.Click += keyboardInput;
			btnU.Click += keyboardInput;
			btnV.Click += keyboardInput;
			btnW.Click += keyboardInput;
			btnX.Click += keyboardInput;
			btnY.Click += keyboardInput;
			btnZ.Click += keyboardInput;
			btnEnter.Click += keyboardInput;
			btnDelete.Click += keyboardInput;

            //Calls the extractWordList method to convert the text file to a usable array
            wordListArray = extractWordList(Resources.wordList);

            //assigns this games correctWord through a return statement in the GenerateCorrectWord function
            correctWord = generateCorrectWord();
            //Produces the correct word in the console for skipping and debug purposes
            Console.WriteLine(correctWord);
        }

		//Method that plays each time a key is pressed and decides the pathway that the code should take depending on position and the key pressed
		private void keyboardInput(object sender, EventArgs e)
		{
			//Guard clause so no keys can be input while the correct word animation is playing
			if (animationOngoing)
			{
				return;
			}
			//Removes the focus on the button just pressed to prevent unwanted actions
            this.ActiveControl = null;
            //Declares clickedButton as the button triggering the event handler
            if (sender is Button clickedButton)
			{
				//Accesses the clicked buttons text to identify whether it is a letter, delete or enter
				string input = clickedButton.Text;

				//Checks if the button was Delete and that there are letters
				//before it (not in the first position in the row)
				if (input == "Delete" && currentColumn > 0)
				{
					deleteLetter(currentColumn - 1, currentRow);
				}
				//Checks if the button was Enter and that the row is a full word
				else if (input == "Enter" && currentColumn == 5)
				{
					//Uses the custom function to get the string "currentWord" from the current row of the 2D char array
					string word = convertRowOf2DCharGridToString(letterGrid, currentRow);
                    //and inputs it as a parameter into the enterWord method
                    enterWord(word);                   
                }
				//Checks if the button was a key and that the row has spots available for another letter
                else if (input != "Enter" && input != "Delete" && currentColumn < 5)
                {
                    appendLetter(input, currentColumn, currentRow);
                }		
				//Checks if the button was Enter, but the row was not a full word
				else if (input == "Enter" && currentColumn != 5)
				{
					//Runs the invalid word animation on each column simultaneously where i is the collumn parameter
					for (int i = 0; i < 5; i++)
					{
						//Calls the invalid word animation function, passing the parameter i and currentRow
						invalidWordAnimation(i, currentRow);
					}
				}
            }
		}
	    
		//Async method for animations that runs separately to the rest of the code for each animation
		private async void keyPressAnimation(int col, int row)
		{ 
			//Declares a string in the format of letterBoxCR with CR representing the desired location in the grid
			string selectedLetterBox = $"letterBox{col:D1}{row:D1}";

			//Searches through all controls on the page
			foreach (Control control in Controls)
			{
				//Runs code once the letterBox that matches the string defined earlier
				//is found and allows us to use the simple LetterBox name to augment it
				if (control.Name == selectedLetterBox && control is letterBox letterBox)
				{
					//	Expand	//

					//For loop runs for the universal animation length constant
					for (int i = 0; i <= animationLength*1.5; i++)
					{
						//Increases size of letterbox by 2 pixels down and right each iteration
						letterBox.Size = new Size(
							letterBox.Size.Width+2, 
							letterBox.Size.Height+2
							);
						//When increasing size, it expands from the bottom right, moving
						//it to the top left by 1 pixel each iteration keeps the control static
						letterBox.Location = new Point(
							letterBox.Location.X-1, 
							letterBox.Location.Y-1
							);
						//Creates a 1 millisecond gap between each iteration of the for loop
						await Task.Delay(1);
					}

                    //	Shrink	//

                    for (int i = 0; i <= animationLength* 1.5; i++)
					{
						//The signs on both size and location are reversed
						//to cause the opposite effect to expanding
						letterBox.Size = new Size(
						letterBox.Size.Width - 2,
						letterBox.Size.Height - 2
							 );
						letterBox.Location = new Point(
							letterBox.Location.X + 1,
							letterBox.Location.Y + 1
							);
						await Task.Delay(1);
					}
                    //Exits the foreach Loop as it is no longer needed
                    break;
                }
			}
		}

		private async void invalidWordAnimation(int col, int row)
		{
            //Declares a string in the format of letterBoxCR with CR representing the desired location in the grid
            string selectedLetterBox = $"letterBox{col:D1}{row:D1}";

            //Searches through all controls on the page
            foreach (Control control in Controls)
			{
                //Runs code once the letterBox that matches the string defined earlier
                //is found and allows us to use the simple LetterBox name to augment it
                if (control.Name == selectedLetterBox && control is letterBox letterBox) // Assuming letterboxes are TextBox controls
				{

					//	Shift left	//

					//Moves the letterBox to the left by 1 pixel every iteration
					for (int i = 0; i <= animationLength; i++)
					{
						letterBox.Location = new Point(
							letterBox.Location.X - 1,
							letterBox.Location.Y
							);
						await Task.Delay(1);
					}

                    //	Shift right	//

                    //Moves the letterBox to the right by 2 pixel every iteration so it ends up offset to the right
                    for (int i = 0; i <= animationLength; i++)
					{
						letterBox.Location = new Point(
							letterBox.Location.X + 2,
							letterBox.Location.Y
							);
						await Task.Delay(1);
					}

                    //	Shift left	//

                    //Moves the letterBox to the left by 1 pixel every iteration so it returns to the center, completing the 'bounce' effect
                    for (int i = 0; i <= animationLength; i++)
					{
						letterBox.Location = new Point(
							letterBox.Location.X - 1,
							letterBox.Location.Y
							);
						await Task.Delay(1);
					}
                    //Exits the foreach Loop as it is no longer needed
                    break;
                }
			}
		}

        private async void correctWordAnimation(int row, string currentWord)
        {
			//Sets the animationOngoing flag to true so that no more letters or buttons can be pressed, preventing bugs
			animationOngoing = true;

			//Converts the input current word parameter to a char array
			char[] currentWordArray = currentWord.ToCharArray();

            //For loop for each letterBox in the row
            for (int i = 0; i <= 5; i++)
            {
                //Declares a string in the format of letterBoxCR with CR representing the desired
				//location in the grid, in this case the iteration in the for loop is the column
				//and the row is constant and defined by a parameter
                string selectedLetterBox = $"letterBox{i:D1}{row:D1}";
                //Searches through all controls on the page
                foreach (Control control in Controls)
                {
                    //Runs code once the letterBox that matches the string defined earlier
                    //is found and allows us to use the simple LetterBox name to augment it
                    if (control.Name == selectedLetterBox && control is letterBox letterBox) // Assuming letterboxes are TextBox controls
                    {
						//Completes the green colour change inside the animation to give the 1 by 1 effect of jumping and colouring.
                        letterBox.baseColour = correctColour;
                        letterBox.alternateColour = correctColour;
                        letterBox.textColour = Color.White;
						letterBox.status = 2;
						
						//Colours the button that has the same letter as the square being animated, passing the desired letter through
						//with currentWordArray[i] and the correctColour as this function is used elsewhere for both partial and incorrect
                        colourButton(currentWordArray[i], correctColour);
						//Same for loops as the other two animation, however multiplying animation length by 3 to make the animation more striking and pronounced
                        for (int j = 0; j <= animationLength * 3; j++)
                        {

							//	Up	//

							//Moves the square up two pixels each iteration
                            letterBox.Location = new Point(
                                letterBox.Location.X,
                                letterBox.Location.Y - 2
                                );
                            await Task.Delay(1);
                        }
                        for (int j = 0; j <= animationLength * 3; j++)
                        {

							//	Down	//

                            //Moves the square down two pixels each iteration
                            letterBox.Location = new Point(
                                letterBox.Location.X,
                                letterBox.Location.Y + 2
                                );
                            await Task.Delay(1);
                        }
                    }
                }
            }
            //Calls the gameWon function, passing the number of guesses it took to win as a parameter.
            //The gameWon function playing after the animation ensures they do not reset the
            //game while the animation is playing, preventing a bug
            gameWon(row);
			//Returns the animationOngoing flag back to false to enable the other buttons to be pressed
			animationOngoing = false;
        }

		//Method that adds letters to the next position in the grid
        private void appendLetter(string input, int col, int row)
		{
			//Adds the letter to the internal 2D array
			letterGrid[currentColumn, currentRow] = Convert.ToChar(input);

            //Declares a string in the format of letterBoxCR with CR representing the desired location in the grid
            string selectedLetterBox = $"letterBox{col:D1}{row:D1}";

            //Searches through all controls on the page
            foreach (Control control in Controls)
			{
                //Runs code once the letterBox that matches the string defined earlier
                //is found and allows us to use the simple LetterBox name to augment it
                if (control.Name == selectedLetterBox && control is letterBox letterBox)
				{
					//Changes the public 'letter' variable on the letterBox to the input, which will then display it in the center of the square
					letterBox.letter = input;
					//Exits the foreach Loop as it is no longer needed
					break;
				}
			}
			//Plays keyPressAnimation to bounce the letter just entered
			keyPressAnimation(currentColumn, currentRow);
			//Increments current column
			currentColumn++;
		}
		
		//Method that removes the previous letter in the grid
		private void deleteLetter(int col, int row)
		{
			//Removes the previous grid positions letter in the array, the parameter is
			//entered as (currentColumn - 1) so nothing has to be decremented here
			letterGrid[col, row] = Convert.ToChar(" ");
			//Creates a string for the letterBox that needs to be changed
			string selectedLetterBox = $"letterBox{col:D1}{row:D1}";
			//Cycles through all controls on screen
			foreach (Control control in Controls)
			{
				//If this iterations control is the control assigned by the string above it calls this code
				if (control.Name == selectedLetterBox && control is letterBox letterBox) 
				{
					//Deletes the letter from the letterbox and thus off the screen
					letterBox.letter = "";
					break; // Exit the loop once the letterbox is found and updated
				}
			}
			//Bounces the letterBox that just had the letter removed from it
			keyPressAnimation(col, row);
			//Decrements the current Column
			currentColumn--;
		}

		//Method that plays when the enter key is pressed and position is at the end of the word,
		//diverges to the majority of the code including word checking, win/loss screens, colouring and resetting
		private void enterWord(string currentWord)
		{
			//Checks if the word is a valid word out of the word pool
			if (checkValidWord(currentWord))
			{
				//Plays the key press animation for all 5 letter boxes simultaneously when word is entered
				for (int i = 0; i <= 4; i++)
				{
                    keyPressAnimation(i, currentRow);
                }
							
				//Calls the checkEnteredRow function which handles the wordle Logic for which square is correct, partially correct and incorrect.
				//Additionally, The functions and logic that handle the colouring of the squares and onscreen keyboard are children of this function.
				resultArray = checkEnteredRow(currentWord.ToCharArray(), correctWord.ToCharArray());

				//Checks if the row was completely correct and thus the game has been won
				if (numberCorrectLetters == 5)
				{
                    //Plays the correct word animation, passing through the row and currentWord
                    //the current word is needed as a parameter as the colouring is done by the animation
                    correctWordAnimation(currentRow, currentWord);
                    //Return statement to exit out of the two if statements and prevent the four lines below the else from being called
                    return;
				}
				//If the game has not been won (First condition above) and it is on Row 5 the game has been lost
				else if (currentRow == 5)
				{
					//Calls the colouring functions, passing the resultArray, row and current word through as parameters
					colourCompleteWord(resultArray, currentRow, currentWord.ToCharArray());

					//Calls the gameLost function passing through the word that was failed to be guessed through as a parameter
					gameLost(correctWord);

                    //Return statement to exit out of the two IF statements and prevent the four lines at the bottom from being called
                    return;
				}
				else
				{
                    //Calls the colouring functions, passing the resultArray, row and current word through as parameters
                    colourCompleteWord(resultArray, currentRow, currentWord.ToCharArray());
				}
				//Clears the result array ready for the next word
				Array.Clear(resultArray, 0, resultArray.Length);
				//increments the current row
				currentRow++;
				//Resets the current column to the start
				currentColumn = 0;
				//Resets the number of correct letters as it is a new row
				numberCorrectLetters = 0;
			}
		}

		//Method that plays after the correct word animation is complete and presents the user with a win screen and then resets the game
		private void gameWon(int row)
		{
            //Returns a personalised victory message to the user, telling them how many
			//guesses it took them and a congradulatory/conscillatory message
            if (row == 0)
			{
                MessageBox.Show("You won after " + (row + 1) + " guess. How?");
            }
            if (row == 1 || row == 2)
            {
                MessageBox.Show("You won after " + (row + 1) + " guesses. Impressive guessing!");
            }
            if (row == 3 || row == 4)
            {
                MessageBox.Show("You won after " + (row + 1) + " guesses. Well done!");
            }
            if (row == 5)
            {
                MessageBox.Show("You won after " + (row + 1) + " guesses. Close one!");
            }

            //Calls the reset function to allow the user to continue playing with a new word
            gameReset();
		}

		//Method that plays when the user fails to guess the word, presenting them with a loss screen and resets the game
		private void gameLost(string correctWord)
		{
			//Creates new string as lowercase variant of correct word
			string word = correctWord.ToLower();
			//Capitilises the first letter of the word
			word = (word.Substring(0, 1)).ToUpper() + word.Substring(1,4);
			
			//Returns a defeat message to the user, telling them what the word they failed to guess was
			MessageBox.Show("You failed to guess the correct word in 6 guesses. \nThe correct word was '" + word + "'. Better luck next time");

            //Calls the reset function to allow the user to continue playing with a new word
            gameReset();
		}

		//Method that generates a new word and then resets every single object and variable back to default values
		public void gameReset()
		{
			//Generates a new correctWord
			correctWord = generateCorrectWord();

			//Writes in the newly generated word in the console for the developer/debugging
			Console.WriteLine(correctWord);

			//Resets column and row to 0 to return to the first place in the grid
			currentColumn = 0;
			currentRow = 0;

			//Resets the number of correct letters
			numberCorrectLetters = 0;

			//Fully clears the letterGrid and resultArray, ready for a new game
			Array.Clear(letterGrid, 0, letterGrid.Length);
			Array.Clear(resultArray, 0, resultArray.Length);

            //Searches through all controls on the page
			//The letterBoxes and buttons need to be reset so we can use the same foreach loop to search through the controls and use if statements to tell when they are
            foreach (Control control in Controls)
			{
				//Checks whether the control is a letterBox
				if (control is letterBox letterBox) 
				{
					//Resets the square's letter to nothing
					letterBox.letter = "";
					//Resets the letterBox inner colour to normal grey/white
					letterBox.baseColour = baseColour;
					//Resets the border colour to grey
					letterBox.alternateColour = alternateColour;
					//Resets the text colour to black/white
					letterBox.textColour = textColour;
					//Resets the status of the letterBox
					letterBox.status = -1;

				}
				//Checks whether the control is a button
				else if (control is Button button)
				{ 
					//Checks whether the button is a key, like btnX (length 4) or btnEnter or btnDelete, this differentiates
					//it from the navigation buttons, and the letterBoxes which inherit their button status
					if (button.Name.Length == 4 || 
						button.Name == "btnEnter" || 
						button.Name == "btnDelete") 
					{
						//Resets the inside colour to grey/white
						button.BackColor = tertiaryColour;
						//Resets the text colour to white/black
						button.ForeColor = textColour;
					}
				}
			}
		}

		//Method that handles all logic for checking the words correctness
		private int[] checkEnteredRow(char[] currentWordArray, char[] correctWordArray)
		{
			//Declares a boolean array with bounds 5
			bool[] alreadyChecked = new bool[5];

            // !	Check for correct  ! \\ 

            //Create for loop with 5 iterations, one for each column
            for (int i = 0; i <= 4; i++)
			{
				//Check if the current word matches the correct word at the specific position defined
				//by the iteration of the for loop, if they match the position i is correct
				if (currentWordArray[i] == correctWordArray[i]) 
				{
                    //Assigns a 2 to the respective position in the resultArray, meaning a correct
                    //This will be used later for colouring
                    resultArray[i] = 2;
					//Swaps the respective position in the already checked array to true
					alreadyChecked[i] = true;
					//Increments the number of correct letters
					numberCorrectLetters++;
				}
			}

            // !	Check for partially correct  ! \\

			//Create for loop with 5 iterations, one for each column
            for (int i = 0; i <= 4; ++i)
			{
				//Checks that the current position hasnt already been assigned correct
				if (resultArray[i] == 0)
				{
					//Creates a second for loop to search the other 4 squares
					for (int j = 0; j <= 4; j++)
					{
						//Checks whether the j position has not already been partially or
						//correctly paired to another square. This is the check that prevents double or triple letter
						//guesses or double letter answers from breaking and showing an extra partial or some other malfunction in logic
						if ((alreadyChecked[j] == false))
						{
							if (currentWordArray[i] == correctWordArray[j])
							{
                                //Sets this positions array to 1, meaning a partially correct
                                resultArray[i] = 1;
								//Sets the j position, the square paired to the i position to already checked to prevent double up
								alreadyChecked[j] = true;
								//Exits out of both for loops to prevent the i position from finding another pairing, which would be incorrect
								break;
							}
						}
					}
				}
			}
			//Returns the result array to the parent function
			return resultArray;
		}

		//Method that colours each letter in a row depending on whether they are correct, partial or incorrect
		private void colourCompleteWord(int[] resultArray, int row, char[] currentWordArray)
		{
			//For loop for all 5 letterBoxes in the row
			for (int i = 0; i <= 4; i++)
			{
				//Creates new string for this iterations desired letterBox
				string selectedLetterBox = $"letterBox{i:D1}{row:D1}";
				//Cycles through all letterBoxes on screen
				foreach (Control control in Controls)
				{
					//Calls code once the desired letterBox is found
					if (control.Name == selectedLetterBox && control is letterBox letterBox) // Assuming letterboxes are TextBox controls
					{
						//If the letter is in the correct letter and correct spot, if number of correct letters is 5,
						//the word is correct and the letterboxes will be coloured sequentially in the animation
						letterBox.textColour = Color.White;
						if (resultArray[i] == 2 && numberCorrectLetters != 5)
						{
							//Colours the letterBox fully green/orange
							letterBox.baseColour = correctColour;
							letterBox.alternateColour = correctColour;
							//Calls the colour button function with the letter and correct colour as parameters to change the onscreen keyboards colour
							colourButton(currentWordArray[i], correctColour);
							//Sets the letterBoxes status to 2 so the program can easily tell what colour it is later
							letterBox.status = 2;
						}
						//if the letter is correct, although in the wrong location
						else if (resultArray[i] == 1)
						{
                            //Colours the letterBox fully yellow/blue
                            letterBox.baseColour = partialColour;
							letterBox.alternateColour = partialColour;
                            //Calls the colour button function with the letter and correct colour as parameters to change the onscreen keyboards colour
                            colourButton(currentWordArray[i], partialColour);
                            //Sets the letterBoxes status to 1 so the program can easily tell what colour it is later
                            letterBox.status = 1;
                        }
						else
						{
                            //Colours the letterBox fully grey
                            letterBox.baseColour = alternateColour;
                            //Calls the colour button function with the letter and correct colour as parameters to change the onscreen keyboards colour
                            colourButton(currentWordArray[i], alternateColour);
                            //Sets the letterBoxes status 0 so the program can easily tell what colour it is later
                            letterBox.status = 0;
                        }
					}
				}
			}
		}

		//Method that plays when colouring in the row but colours the onscreen buttons appropriately
		private void colourButton(char letter, Color colour)
		{
			//Creates a string of the desired button
			string selectedButton = $"btn{letter:D1}";
			//Cycles through all controls on the page
			foreach (Control control in Controls)
			{
				//Plays code once desired letterbox is found
				if (control.Name == selectedButton && control is Button button) // Assuming letterboxes are TextBox controls
				{
					//Checks whether the button has already been coloured green as to not wrongly overwrite it with yellow
					if (button.BackColor != correctColour)
					{
						//Changes the colour to colour passed as a parameter
						button.BackColor = colour;
						//Filled in keys are always white so it always changes it to white
						button.ForeColor = Colours.darkTextColour;
					}
				}
			}
		}

		//Generates a new correct word out of a small word pool
		private string generateCorrectWord()
		{
			//Creates a new random number generator object
            Random random = new Random();
			//Checks whether hard mode is disabled
			//If hard mode is disabled the word list will be restricted so the correct word is a common word
            if (hardMode == false)
			{
                //Creates a temporary string of the correct word that is being overwritten
                string tempNoRepeat = correctWord;
                //Declares the correctWordPool, a far condensed version of wordList.txt that only includes common words
                string[] correctWordPool = {
                "HOUSE", "PLACE", "RIGHT", "SMALL", "LARGE", "WATER", "WHERE", "AFTER", "UNDER",
                "WHILE", "NEVER", "OTHER", "ABOUT", "THESE", "WOULD", "COULD", "THEIR", "ARISE",
                "THERE", "WHERE", "WHICH", "THOSE", "AGAIN", "WORLD", "THREE", "GREAT", "STILL",
                "EVERY", "FOUND", "MIGHT", "FIRST", "THOSE", "AFTER", "COULD", "EVERY", "WHERE",
                "NEVER", "OTHER", "UNDER", "ABOUT", "WOULD", "THERE", "WHICH", "WHERE", "WORLD",
                "RIGHT", "LARGE", "SMALL", "PLACE", "IRATE", "AUDIO",
				};
                
                //Returns a random word from the correctWordPool
                string newWord = correctWordPool[random.Next(0, correctWordPool.Length)];
                //Generates new word if the random word was the same as last time
                while (newWord == tempNoRepeat)
                {
                    //Returns a random word from the correctWordPool
                    newWord = correctWordPool[random.Next(0, correctWordPool.Length)];
                }
                //Returns the new word that is not the same as last time
                return newWord;
            }
			//If hard mode is not disabled, the correct word could be anything
			else
			{
				//Returns the random word
				return wordListArray[random.Next(0, wordListArray.Length)];
			}

		}

		//Function used to easily convert a singular row of a 2d char grid, primarily the letter grid to a singular string
		private string convertRowOf2DCharGridToString(char[,] grid, int row)
		{
			//Concatenates all 5 columns character of the row passed through
			return (
				grid[0, row].ToString() +
				grid[1, row].ToString() +
				grid[2, row].ToString() +
				grid[3, row].ToString() +
				grid[4, row].ToString()
				);
		}

		//Method that compares guesses to the word dictionary
		private bool checkValidWord(string word)
		{
			//Guard clause that exits the method if checkDictionary is false
			if (checkDictionary == false)
			{
				//Returns true as all words are valid in this case
				return true;
			}

			//Checks whether the input word exists in the array
			if (Array.Exists(wordListArray, element => element.Equals(word, StringComparison.OrdinalIgnoreCase))) 
			{
				//returns true as it exists in the array
				return true;
			}
			else
			{
                //Runs the invalid word animation on each column simultaneously where i is the collumn parameter
                for (int i = 0; i < 5; i++)
                {
                    //Calls the invalid word animation function, passing the parameter i and currentRow
                    invalidWordAnimation(i, currentRow);
                }
				//Returns false is it does not exist in the array
				return false;
            }		
		}

		//Method that plays at the start to convert the text file to an array
		private string[] extractWordList(string wordList)
		{
            //Creates and returns an array out of the given text file
            return wordList.Split(',');
        }

		//Method handler for button clicks
        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Guard Clause to prevent button from being pressed while animation is playing
            if (animationOngoing == true)
            {
				//Exits the method
                return;
            }
            //Removes the focus from the button just pressed
            this.ActiveControl = null;
			//Opens the FrmHelp instance created at the start
			//ShowDialog means they cannot click off it until they close the form
            FrmHelp.ShowDialog();
        }

        //Method handler for button clicks
        private void btnSettings_Click(object sender, EventArgs e)
		{
			//Guard Clause to prevent button from being pressed while animation is playing
			if (animationOngoing == true)
			{
				//Exits the method
				return;
			}
            //Removes the focus from the button just pressed
            this.ActiveControl = null;

            frmSettings FrmSettings = new frmSettings(this);

			//Brings the settings instance up on screen and shows dialog so the
			//user cannot click off it until they close the form
			FrmSettings.ShowDialog();
        }

        //Method handler for keyboard clicks while the form is focused
        private void frmWordle_KeyDown(object sender, KeyEventArgs e)
		{
			//Switchcase for what keycode has been physically pressed
			//simulates a digital click of one of the onscreen buttons
			//to remove repetitions and more variables
			switch (e.KeyCode)
			{
				case Keys.A:
					btnA.PerformClick();
					break;
				case Keys.B:
					btnB.PerformClick();
					break;
				case Keys.C:
					btnC.PerformClick();
					break;
				case Keys.D:
					btnD.PerformClick();
					break;
				case Keys.E:
					btnE.PerformClick();
					break;
				case Keys.F:
					btnF.PerformClick();
					break;
				case Keys.G:
					btnG.PerformClick();
					break;
				case Keys.H:
					btnH.PerformClick();
					break;
				case Keys.I:
					btnI.PerformClick();
					break;
				case Keys.J:
					btnJ.PerformClick();
					break;
				case Keys.K:
					btnK.PerformClick();
					break;
				case Keys.L:
					btnL.PerformClick();
					break;
				case Keys.M:
					btnM.PerformClick();
					break;
				case Keys.N:
					btnN.PerformClick();
					break;
				case Keys.O:
					btnO.PerformClick();
					break;
				case Keys.P:
					btnP.PerformClick();
					break;
				case Keys.Q:
					btnQ.PerformClick();
					break;
				case Keys.R:
					btnR.PerformClick();
					break;
				case Keys.S:
					btnS.PerformClick();
					break;
				case Keys.T:
					btnT.PerformClick();
					break;
				case Keys.U:
					btnU.PerformClick();
					break;
				case Keys.V:
					btnV.PerformClick();
					break;
				case Keys.W:
					btnW.PerformClick();
					break;
				case Keys.X:
					btnX.PerformClick();
					break;
				case Keys.Y:
					btnY.PerformClick();
					break;
				case Keys.Z:
					btnZ.PerformClick();
					break;
				case Keys.Enter:
					btnEnter.PerformClick();
					break;
				case Keys.Delete:
					btnDelete.PerformClick();
					break;
				case Keys.Back:
					btnDelete.PerformClick();
					break;
			}
		}
    }

    //Public class to access every Colour variant for light/darkmode and high contrast mode.
    public static class Colours
	{
        public static Color lightBaseColour = Color.FromArgb(245, 245, 245);
        public static Color darkBaseColour = Color.FromArgb(20, 20, 20);
        public static Color lightAlternateColour = Color.FromArgb(150, 150, 150);
        public static Color darkAlternateColour = Color.FromArgb(75, 75, 75);
        public static Color lightTertiaryColour = Color.FromArgb(200, 200, 200);
        public static Color darkTertiaryColour = Color.DimGray;
        public static Color lightCorrectColour = Color.FromArgb(106, 170, 100);
        public static Color darkCorrectColour = Color.FromArgb(83, 141, 78);
        public static Color lightPartialColour = Color.FromArgb(201, 180, 88);
        public static Color darkPartialColour = Color.FromArgb(181, 159, 59);
        public static Color lightTextColour = Color.Black;
        public static Color darkTextColour = Color.White;
		public static Color highContrastCorrectColour = Color.FromArgb(255, 119, 0);
		public static Color highContrastPartialColour = Color.FromArgb(43, 143, 224);
    }
}