using System;
using System.Collections.Generic;
using System.Text;

namespace Othello_app
{
    class GameBoard 
    {
        private int ROWS = 10;
        private int COLS = 10;
        private char[,] board;
        public GameBoard()
        {
            board = new char[COLS, ROWS];

            // initialize board to have all blank spaces
            for (int i = 0; i < COLS; i++)
            {
                for (int j = 0; j < ROWS; j++)
                {
                    board[i, j] = ' ';
                }
            }

            // Add the starting pieces in the center
            
            board[4, 4] = 'X';
            board[4, 5] = 'O';
            board[5, 4] = 'O';
            board[5, 5] = 'X';
            
        }

        public void Print()
        {
            Console.Write("  ");
            for (int k = 1; k < COLS -1; k++)
            {
                Console.Write(" " + k  + " ");
            }
            Console.Write('\n');

            for (int i = 1; i < COLS -1; i++)
            {
                Console.Write(i  + " ");
                for (int j = 1; j < ROWS -1; j++)
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
            else if (BorW == false)
            {
                board[x, y] = 'O';
                
            }
  
        }

        public void Userinput(bool BorW)
        {
            try
            {
                if(BorW == true)
                {
                    Console.WriteLine("X's Turn"); 
                }
                else
                {
                    Console.WriteLine("O's Turn");
                }

                Console.Write("Which Column?");
                int inputY  = Int32.Parse(Console.ReadLine());

                Console.Write("Which Row?");
                int inputX  = Int32.Parse(Console.ReadLine());

                
                ValidMove(inputX, inputY, BorW);

                

            }
            catch (SystemException)
            {
                Console.WriteLine("Please enter valid numbers!\n");
                Userinput(BorW);
            }

        }

        public void ValidMove(int inputX, int inputY, bool BorW)
        {

            // Checks if placement of new disk is adjecent to oponents disk
            char opponent = 'O';
            
            if (BorW == false)
            {
                opponent = 'X';
            }
            
                
            if (board[inputX, inputY] == ' ' )
            {
                if (board[inputX, inputY -1 ] == opponent)  
                {
                    UpdateBoard(inputX, inputY, BorW);
                    UpdateBoard(inputX, inputY-1, BorW);

                }

                if (board[inputX + 1, inputY - 1] == opponent)
                {
                    UpdateBoard(inputX, inputY, BorW);
                    UpdateBoard(inputX + 1, inputY - 1, BorW);
                }

                if (board[inputX + 1, inputY] == opponent)
                {
                    UpdateBoard(inputX, inputY, BorW);
                    UpdateBoard(inputX + 1, inputY, BorW);
                }

                if (board[inputX + 1, inputY + 1] == opponent)
                {
                    UpdateBoard(inputX, inputY, BorW);
                    UpdateBoard(inputX + 1, inputY + 1, BorW);
                }

                if (board[inputX, inputY + 1] == opponent)
                {
                    UpdateBoard(inputX, inputY, BorW);
                    UpdateBoard(inputX, inputY + 1, BorW);
                }

                if (board[inputX - 1, inputY + 1] == opponent)
                {
                    UpdateBoard(inputX, inputY, BorW);
                    UpdateBoard(inputX - 1, inputY + 1, BorW);
                }

                if (board[inputX - 1, inputY] == opponent)
                {
                    UpdateBoard(inputX, inputY, BorW);
                    UpdateBoard(inputX - 1, inputY, BorW);
                }

                if (board[inputX - 1, inputY - 1] == opponent)
                {
                    UpdateBoard(inputX, inputY, BorW);
                    UpdateBoard(inputX - 1, inputY - 1, BorW);
                }

                

            }
            else
            {
                Console.WriteLine("\n invalid move, please try again. "  );
                Userinput(BorW);

            }
        }

       

        
    }
}
