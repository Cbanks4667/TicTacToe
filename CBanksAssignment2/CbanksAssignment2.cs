/*CBanksAssignment2
 * 
 * Tic Tac Toe Game
 * 
 * Revision History
 *      Created: Chris Banks Sept 30th 2016
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBanksAssignment2
{
 /// <summary>
///Namespace for the form 
/// </summary>
    public partial class CbanksAssignment2 : Form
    {
    /// <summary>
    /// List of available players
    /// </summary>
        public enum Player
        {
            X,
            O
        }
        const int ROWS = 3;
        const int COLUMNS = 3;
        int[,] Board = new int[ROWS, COLUMNS];
        int MoveNumber = 0;
        Player currentPlayer = Player.X;
        int playerNow = 0;
       
        /// <summary>
        /// Initializes the form and Loads a NewGame
        /// </summary>
        public CbanksAssignment2()
        {
            InitializeComponent();
            NewGame();
        }
        /// <summary>
        /// New Game method to reset all global fields and images
        /// </summary>
        private void NewGame()
        {
            

            currentPlayer = Player.X;
            MoveNumber = 0;
            for (int row = 0; row < ROWS; row++)
            {
                for (int column = 0; column < COLUMNS; column++)
                {
                   
                    Board[row, column] = -1;
                    
                }
            }
            pic00.Image = null;
            pic01.Image = null;
            pic02.Image = null;
            pic10.Image = null;
            pic11.Image = null;
            pic12.Image = null;
            pic20.Image = null;
            pic21.Image = null;
            pic22.Image = null;
        }
        /// <summary>
        /// Click event handler for the PictureBoxes
        ///Calls a method to load an image 
        ///Calls a method to check the status of the board
        ///Switches Player
        /// </summary>
        /// <param name="sender">Determines which button is pressed</param>
        /// <param name="e"></param>
        private void pic00_Click(object sender, EventArgs e)
        {
            var ImageButton = (PictureBox)sender;
            string location = "";
            int rows = 0;
            int columns = 0;
            location = ImageButton.Name.ToString();
            rows = int.Parse(location[3].ToString());
            columns = int.Parse(location[4].ToString());
            bool imageLoaded = false;

            imageLoaded = LoadImage(sender,rows,columns);
            if (imageLoaded)
            {
                if (MoveNumber < 9)
                {
                    MoveNumber++;
                    BoardState(rows, columns);
                    currentPlayer = currentPlayer ==
                        Player.X ? Player.O : Player.X;
                } 
                else
                {
                    MessageBox.Show(MoveNumber.ToString());
                } 
            }

        }
        /// <summary>
        /// Loads the Image to the picture box and the player to the board array
        /// </summary>
        /// <param name="sender">Represents which picture box was selected
            /// </param>
        /// <param name="r">The Row Index of the picture selected</param>
        /// <param name="c">The Column Index of the picture selected</param>
        private bool LoadImage(object sender,int r, int c)
        {
            int rows = r;
            int columns = c;
            var ImageButton = (PictureBox)sender;
            bool imageLoaded = true;
            if (ImageButton.Image == null)
            {
                if (currentPlayer == 0)
                {
                    ImageButton.Image = Properties.Resources.x;
                    Board[rows, columns] = 0;

                }
                else
                {
                    ImageButton.Image = Properties.Resources.o;
                    Board[rows, columns] = 1;
                }
                
            }
            else
            {
                MessageBox.Show("You have already selected this image");
                imageLoaded = false;
            }
            return imageLoaded;
        }
        /// <summary>
        /// Checks The win conditions of the game
        /// </summary>
        /// <param name="r">The Row Index of the picture selected</param>
        /// <param name="c">The Column Index of the picture selected</param>
        public void BoardState(int r, int c)
        {
            int rows = r;
            int columns = c;
            int location = Math.Abs(rows - columns);
            bool win = false;

            if (location == 1)
            {
                win = CheckHorizontal(rows, columns);
                if (win == false)
                {
                    win = CheckVerticle(rows, columns);
                }
            }
            else
            {
                win = CheckDiaganol();
                if (win==false)
                {
                    win = CheckHorizontal(rows, columns);
                }
                if(win==false)
                {
                    win = CheckVerticle(rows, columns);
                }
            }

            if (win)
            {
                MessageBox.Show("The Winner is " + currentPlayer);
                NewGame();
                currentPlayer = currentPlayer == Player.X ? Player.O : Player.X;
            }
           else if(MoveNumber ==9)
            {
                MessageBox.Show("it is a draw!");
                NewGame();
                currentPlayer = currentPlayer == Player.X ? Player.O : Player.X;
            }

        }
        /// <summary>
        /// Checks to see if a win condition has been met
            /// on the current row selected
        /// </summary>
        /// <param name="r">The Row Index of the picture selected</param>
        /// <param name="c">The Column Index of the picture selected</param>
        /// <returns>Win condition status</returns>
        public bool CheckHorizontal(int r, int c)
        {
            bool win = true;
            int row = r;
            SetPlayer();
            for ( int column = 0; column < COLUMNS; column++)
            {
                if(playerNow.Equals(Board[row,column]))
                {
                   
                }
                else
                {
                    win = false;
                }
            }
            return win;
        }
        /// <summary>
        /// Checks to see if a win condition has been met
            /// on the current column selected
        /// </summary>
        /// <param name="r">The Row Index of the picture selected</param>
        /// <param name="c">The Column Index of the picture selected</param>
        /// <returns>Win Condition Status</returns>
        public bool CheckVerticle(int r, int c)
        {
            bool win = true;
            int column = c;

            SetPlayer();
            for (int row = 0; row < ROWS; row++)
            {
                if (playerNow.Equals(Board[row, column]))
                {

                }
                else
                {
                    win = false;
                }
            }
            return win;
        }
        /// <summary>
        /// Sets an integer = to the current player index
        /// </summary>
        private void SetPlayer()
        {
            if (currentPlayer == Player.X)
            {
                playerNow = 0;
                //MessageBox.Show(playerNow.ToString());
            }
            else if (currentPlayer == Player.O)
            {
                playerNow = 1;
            }
        }
        /// <summary>
        /// Checks to see if a win condition has been met on the diagonal  
        /// </summary>
        /// <returns>Win condition status</returns>
        public bool CheckDiaganol()
        {
            SetPlayer();
            int row = 1;
            int column = 1;
            bool win = false;

            if (playerNow.Equals(Board[row, column]))
            {
                if (playerNow.Equals(Board[row - 1, column - 1]) &&
                    (playerNow.Equals(Board[row + 1, column + 1])) ||
                    (playerNow.Equals(Board[row - 1, column + 1])) &&
                    (playerNow.Equals(Board[row + 1, column - 1])))
                {
                    win = true;
                }
            }
            return win;
        }
    }
}
