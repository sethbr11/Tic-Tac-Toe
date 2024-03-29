﻿/* AUTHORS: Abby Harris, Cody Nettesheim, Payton Womack, Seth Brock
 * SECTION: 001
 * IS 413 - Hilton
 * Assignment Name: Mission #4 - Tic-Tac-Toe
 * Short Description: 
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

using Tic_Tac_Toe;

TicTacToe ttt = new TicTacToe();

// welcomes to the game
Console.WriteLine("Welcome to our game!");

bool gameOver = false; // sets gameOver to false until a winner is chosen 
char[] gameBoard = Enumerable.Repeat(' ', 9).ToArray(); //sets the gameboard to empty array of 9

// start of the while loop
while (gameOver == false)
{
    if (ttt.checkWinner(gameBoard))
    {
        gameOver = true; // check to see if gameOver is true or if we should continue with game
    }
    else
    {
        // Player 1 turn
        Console.WriteLine("Player 1: which square do you want to mark? (1-9)");

        int p1Choice = 0;

        // while loop to check if they put in a valid input for player 1
        if (!int.TryParse(Console.ReadLine(), out p1Choice) || p1Choice < 1 || p1Choice > 9)
        {
            Console.WriteLine("Invalid input. Please enter a valid number between 1 and 9.");
            continue; // Continue with the next iteration of the loop
        }

        gameBoard[p1Choice - 1] = 'x';

        gameOver = ttt.checkWinner(gameBoard);

        Console.WriteLine(ttt.printBoard(gameBoard)); 

        if (!ttt.checkWinner(gameBoard)) //see if player 1 wins on their turn, if not have player 2 guess
        {

            // Player 2 turn
            Console.WriteLine("Player 2: which square do you want to mark? (1-9)");

            int p2Choice = 0;

            // while loop to check if they put in a valid input for player 2
            while (!int.TryParse(Console.ReadLine(), out p2Choice) || p2Choice < 1 || p2Choice > 9)
            {
                Console.WriteLine("Invalid input. Please enter a valid number between 1 and 9.");
                Console.WriteLine(ttt.printBoard(gameBoard));
                Console.WriteLine("Player 2: which square do you want to mark? (1-9)");
            }

            gameBoard[p2Choice - 1] = 'o';

            gameOver = ttt.checkWinner(gameBoard);

            Console.WriteLine(ttt.printBoard(gameBoard));

        }

    }
}

// determine the winner 
Console.WriteLine(ttt.printAndGetWinner(gameBoard));


