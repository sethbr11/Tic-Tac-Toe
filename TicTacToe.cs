/* AUTHORS: Abby Harris, Cody Nettesheim, Payton Womack, Seth Brock
 * SECTION: 001
 * IS 413 - Hilton
 * Assignment Name: Mission #4 - Tic-Tac-Toe
 * Short Description: a class file...
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe {
    internal class TicTacToe {
        int board = 1;
        public TicTacToe() {
            board = 2;
        }
        public void printBoard() {
            Console.WriteLine("Hello, World!" + board);
        }
    }
}
