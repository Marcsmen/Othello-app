using System;
using System.Collections.Generic;
using System.Text;

namespace Othello_app
{
    class GameBoard 
    {
        private int ROWS = 8;
        private int COLS = 8;
        private char[,] board;
        public GameBoard()
        {
            board = new char[ROWS, COLS];

            // initialize board to have all blank spaces
            for (int i = 0; i < COLS; i++)
            {
                for (int j = 0; j < ROWS; j++)
                {
                    board[i, j] = ' ';
                }
            }

            // Add the starting pieces in the center
            
            board[3, 3] = 'X';
            board[3, 4] = 'O';
            board[4, 3] = 'O';
            board[4, 4] = 'X';
        }

        public void Print()
        {
            Console.Write("  ");
            for (int k = 1; k <= COLS; k++)
            {
                Console.Write(" " + k + " ");
            }
            Console.Write('\n');

            for (int i = 0; i < COLS; i++)
            {
                Console.Write(i + 1 + " ");
                for (int j = 0; j < ROWS; j++)
                {
                    Console.Write("[" + board[i, j] + "]");
                }
                Console.Write('\n');
            }
        }

        public void UpdateBoard(int x, int y, bool BorW)
        {
            if(BorW == true)
            {
                board[x, y] = 'X';
            }
            if (BorW == false)
            {
                board[x, y] = 'O';
            }
        }

        public void Userinput()
        {
            Console.WriteLine("whats the X-cordinate?");
            int inputX = Int32.Parse( Console.ReadLine());
            Console.WriteLine("whats the Y-cordinate?");
            int inputY = Int32.Parse(Console.ReadLine());



            UpdateBoard(inputX -1 , inputY-1, true);


        }
    }
}
