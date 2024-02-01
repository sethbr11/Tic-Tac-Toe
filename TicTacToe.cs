/* AUTHORS: Abby Harris, Cody Nettesheim, Payton Womack, Seth Brock
 * SECTION: 001
 * IS 413 - Hilton
 * Assignment Name: Mission #4 - Tic-Tac-Toe
 * Short Description: a class file...
 */
/* PROJECT DESCRIPTION:
    - For this assignment, you will work in your teams to write a game of Tic-Tac-Toe in C#.
    - The program will be written in two classes:
        1) The “Driver” class (the Program.cs class with the main method where the program begins) 
           will:
            • Welcome the user to the game
            • Create a game board array to store the players’ choices
            • Ask each player in turn for their choice and update the game board array
            • Print the board by calling the method in the supporting class
            • Check for a winner by calling the method in the supporting class, and notify the players
                when a win has occurred and which player won the game
        2) The supporting class (with whichever name you choose) will:
            • Receive the “board” array from the driver class
            • Contain a method that prints the board based on the information passed to it
            • Contain a method that receives the game board array as input and returns if there is a
                winner and who it was
    - Each team will divide itself into half, and one half of the team will work on the driver class,
      while the other half of the team will work on the supporting class
    - Each half of the team will use the Paired Programming approach, where programmers work together 
      on the class to solve the problem. 
        1) The Driver (the individual at the keyboard) will type, while...
        2) ...the Navigator (the other team member) will help provide overall direction and watch for 
           any potential errors. 
    - You can switch those roles at any time, but both individuals should be working on their part of 
      the program together.
    - For the purposes of this assignment in trying to help you solidify your understanding of 
      objectoriented programming better, each half of the team should NOT look at the code of the 
      other half until after the project has been assembled and is functioning. You can communicate as
      much as you want as a team to understand what the other half is doing, but do not view or
      modify any of the code from the other half while you are building the program.
    - As always, write good, clean code with descriptive variable names, proper indentation, and clear
      commenting as appropriate to describe what the code is doing.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Tic_Tac_Toe {
    internal class TicTacToe {
        private char[] thisBoard = { 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x' };

        // Constructors
        public TicTacToe() { }
        public TicTacToe(char[] board) { this.thisBoard = board; }

        // Method to set the whole board after initiation
        public void setBoard(char[] board) { this.thisBoard = board; }

        // Method to update individual array indexes

        // Print Methods
        public string printBoard() { return printBoard(this.thisBoard); }
        public string printBoard(char[] board) {
            string print = "";
            string endLine = "";
            int boardLength = (int)Math.Sqrt(board.Length); // Only passing 3x3 but this makes it dynamic if we want to change anything later

            // Iterate through each character, create the grid
            for (int i = 0; i < board.Length; i++) {
                if ((i + 1) % boardLength == 0 && i != board.Length - 1) { endLine = $"\n--+---+--\n"; } // End of line
                else if (i != board.Length - 1) { endLine = " | "; } // Between characters same line
                else { endLine = " "; } // Very last character
                print += board[i].ToString() + endLine; // Appen to the return string
            };

            // Return the board as a string 
            return print;
        }

        // Method to check if there is a winner on the board
        public bool checkWinner() { return checkWinner(this.thisBoard); }
        public bool checkWinner(char[] board) {
            if (getWinner(board) == "The game is still going") { return false; }
            else { return true;  }
        }

        // getWinner methods to return who won (or if there was a tie)
        public string getWinner() { return getWinner(this.thisBoard); }
        public string getWinner(char[] board) {
            for (int i = 0; i < board.Length; i++) { Char.ToLower(board[i]); } // Convert each character to lowercase
            string winner = "";
            int boardLength = (int)Math.Sqrt(board.Length); // Only passing 3x3 but this makes it dynamic if we want to change anything later

            // Check each row for a winner
            for (int i = 0; i < boardLength; i++) {
                if ((board[0 + (i * 3)] == board[1 + (i * 3)] && board[1 + (i * 3)] == board[2 + (i * 3)])
                    && (board[0 + (i * 3)] == 'x' || board[0 + (i * 3)] == 'o')) { // Only 'x' or 'o' will fit criteria
                    winner = board[0 + (i * 3)].ToString() + " is the winner!";
                }
            }

            // If we haven't found a winner yet, check the columns
            if (winner == "") {
                for (int i = 0; i < boardLength; i++) {
                    if (board[0 + i] == board[3 + i] && board[3 + i] == board[6 + i]
                        && (board[0 + i] == 'x' || board[0 + i] == 'o')) { // Only 'x' or 'o' will fit criteria
                        winner = board[0 + i].ToString() + " is the winner!";
                    }
                }
            }

            // If still no winner, check the two diagonals
            if (winner == "") {
                if ((board[0] == board[4] && board[4] == board[8]) || (board[2] == board[4] && board[4] == board[6])
                     && (board[4] == 'x' || board[4] == 'o')) { // Only 'x' or 'o' will fit criteria
                    winner = board[4].ToString() + " is the winner!";
                }
            }

            // Check to see if the board is full
            bool boardFull = true;
            for (int i = 0; i < board.Length && boardFull; i++) {
                if (board[i] != 'x' || board[i] != 'o') { boardFull = false; }
            }
            Console.WriteLine(boardFull);
            // If still not winner, it's a tie game
            if (winner == "" && boardFull) { winner = "Tie game!"; } // Otherwise nobody won and it's a tie
            else { winner = "The game is still going!";  }

            // Return the winner
            return winner;
        }

        // Print board AND get winner
        public string printAndGetWinner() { return printAndGetWinner(this.thisBoard); }
        public string printAndGetWinner(char[] board) { return printBoard(board) + "\n" + getWinner(board) + "\n"; }
    }
}
