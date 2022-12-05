using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Othello_app
{
    class GameBoard 
    {
        private int ROWS = 10;  //Actual playable board is only 8x8, 
        private int COLS = 10;  //needs to be 10x10 to validate move in all directions.
        private char[,] board;
       
        public GameBoard()
        {
            board = new char[COLS, ROWS];

            // Initialize board to have all blank spaces
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

        //Prints current state of the board
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

        //Updates board in specific coordinates to either X or O.
        private void UpdateBoard(int x, int y, bool BorW)
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

        // Takes user input and first makes sure the input is and int,
        // then calls IsValidMove to check if the move makes any sence.
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

                
                if (!IsValidMove(inputX, inputY, BorW))
                {
                    Console.WriteLine("Invalid move, please try again! ");
                    Userinput(BorW);
                }
                else
                {
                    UpdateBoard(inputX, inputY, BorW);
                    FlipDisks(inputX, inputY, BorW);
                }

            }
            catch (SystemException)
            {
                Console.WriteLine("Please enter valid numbers!\n");
                Userinput(BorW);
            }

        }

        // Checks if a move can be made on a given x,y cordinate.
        private bool IsValidMove(int inputX, int inputY, bool BorW)
        {
            
            char opponent = 'O';
            if (BorW == false)
            {
                opponent = 'X';
            }

            if (board[inputX, inputY] == ' ')
            {

                if (board[inputX, inputY - 1] == opponent)
                {
                    for (int i = 2; inputY - i >= 1; i++)
                    {
                        if (board[inputX, inputY - i] != opponent)
                        {
                            if (board[inputX, inputY - i] != ' ')
                            {
                                return true;
                            }
                            break;
                        }
                    }
                }

                if (board[inputX + 1, inputY - 1] == opponent)
                {
                    for (int i = 2; inputY - i >= 1 && inputX + i <= 9; i++)
                    {
                        if (board[inputX + i, inputY - i] != opponent)
                        {
                            if (board[inputX + i, inputY - i] != ' ')
                            {
                                return true;
                            }
                            break;
                        }

                    }
                }

                if (board[inputX + 1, inputY] == opponent)
                {
                    for (int i = 2; inputX + i <= 9; i++)
                    {
                        if (board[inputX + i, inputY] != opponent)
                        {
                            if (board[inputX + i, inputY] != ' ')
                            {
                                return true;
                            }
                            break;
                        }
                    }
                }

                if (board[inputX + 1, inputY + 1] == opponent)
                {
                    for (int i = 2; inputY + i <= 9 && inputX + i <= 9; i++)
                    {
                        if (board[inputX + i, inputY + i] != opponent)
                        {
                            if (board[inputX + i, inputY + i] != ' ')
                            {
                                return true;
                            }
                            break;
                        }

                    }
                }

                if (board[inputX, inputY + 1] == opponent)
                {
                    for (int i = 2; inputY + i <= 9; i++)
                    {
                        if (board[inputX, inputY + i] != opponent)
                        {
                            if (board[inputX, inputY + i] != ' ')
                            {
                                return true;
                            }
                            break;
                        }
                    }
                }

                if (board[inputX - 1, inputY + 1] == opponent)
                {
                    for (int i = 2; inputX - i >= 1 && inputY + i <= 9; i++)
                    {
                        if (board[inputX - i, inputY + i] != opponent)
                        {
                            if (board[inputX - i, inputY + i] != ' ')
                            {
                                return true;
                            }
                            break;
                        }

                    }
                }

                if (board[inputX - 1, inputY] == opponent)
                {
                    for (int i = 2; inputX - i >= 1; i++)
                    {
                        if (board[inputX - i, inputY] != opponent)
                        {
                            if (board[inputX - i, inputY] != ' ')
                            {
                                return true;
                            }
                            break;
                        }
                        
                    }
                }

                if (board[inputX - 1, inputY - 1] == opponent)
                {
                    for (int i = 2; inputX - i >= 1 && inputY - i >= 1; i++)
                    {
                        if (board[inputX - i, inputY - i] != opponent)
                        {
                            if (board[inputX - i, inputY - i] != ' ')
                            {
                                return true;
                            }
                            return false;
                        }

                    }
                }

                
                return false;
            }
            else
            {
                
                return false;
            }
        }

        //Flips the appropriate "disks".
        //Also has some additonal validation to not flip disks illegaly.
        private void FlipDisks(int inputX, int inputY, bool BorW)
        {
            char own = 'X';
            char opponent = 'O';

            if (BorW == false)
            {
                own = 'O';
                opponent = 'X';
            }

            if (board[inputX, inputY - 1] == opponent)
            {
                bool validMove = false;
                for (int i = 1; inputY - i >= 1; i++)
                {
                    if (board[inputX, inputY - i] == ' ')
                    {
                        break;
                    }
                    if (board[inputX, inputY - i] == own)
                    {
                        validMove = true;
                        break;
                    }
                }
                if (validMove)
                {
                    for (int i = 1; inputY - i >= 1; i++)
                    {
                        if (board[inputX, inputY - i] == opponent)
                        {
                            board[inputX, inputY - i] = own; 
                        }
                        else if(board[inputX, inputY - i] != opponent)
                        {
                            break;
                        }
                    }
                }
            }
            if (board[inputX + 1, inputY - 1] == opponent)
            {
                bool validMove = false;
                for (int i = 1; inputX + i <= 9 && inputY - i >= 1; i++)
                {
                    if (board[inputX + i, inputY - i] == ' ')
                    {
                        break;
                    }
                    if (board[inputX + i, inputY - i] == own)
                    {
                        validMove = true;
                        break;
                    }
                }
                if (validMove)
                {
                    for (int i = 1;inputX + i <= 9 && inputY - i >= 1; i++)
                    {
                        if (board[inputX + i, inputY - i] == opponent)
                        {
                            board[inputX + i, inputY - i] = own;
                        }
                        else if (board[inputX + i, inputY - i] != opponent)
                        {
                            break;
                        }

                    }
                }

            }
            if (board[inputX + 1, inputY] == opponent)
            {
                bool validMove = false;
                for (int i = 1; inputX + i <= 9; i++)
                {
                    if (board[inputX + i, inputY] == ' ')
                    {
                        break;
                    }
                    if (board[inputX + i, inputY] == own)
                    {
                        validMove = true;
                        break;
                    }
                }
                if (validMove)
                {
                    for (int i = 1; inputX + i <= 9; i++)
                    {
                        if (board[inputX + i, inputY] == opponent)
                        {
                            board[inputX + i, inputY] = own;
                        }
                        else if (board[inputX + i, inputY] != opponent)
                        {
                            break;
                        }

                    }
                }

            }
            if (board[inputX + 1, inputY + 1] == opponent)
            {
                bool validMove = false;
                for (int i = 1; inputX + i <= 9 && inputY + i <= 9; i++)
                {
                    if (board[inputX + i, inputY + i] == ' ')
                    {
                        break;
                    }
                    if (board[inputX + i, inputY + i] == own)
                    {
                        validMove = true;
                        break;
                    }
                }
                if (validMove)
                {
                    for (int i = 1; inputX + i <= 9 && inputY + i <= 9; i++)
                    {
                        if (board[inputX + i, inputY + i] == opponent)
                        {
                            board[inputX + i, inputY + i] = own;
                        }
                        else if (board[inputX + i, inputY + i] != opponent)
                        {
                            break;
                        }
                    }
                }
            }
            if (board[inputX, inputY + 1] == opponent)
            {
                bool validMove = false;
                for (int i = 1; inputY + i <= 9; i++)
                {
                    if (board[inputX, inputY + i] == ' ')
                    {
                        break;
                    }
                    if (board[inputX, inputY + i] == own)
                    {
                        validMove = true;
                        break;
                    }
                }
                if (validMove)
                {
                    for (int i = 1; inputY + i <= 9; i++)
                    {
                        if (board[inputX, inputY + i] == opponent)
                        {
                            board[inputX, inputY + i] = own;
                        }
                        else if (board[inputX, inputY + i] != opponent)
                        {
                            break;
                        }

                    }
                }
            }
            if (board[inputX - 1, inputY + 1] == opponent)
            {
                bool validMove = false;
                for (int i = 1; inputX - i >= 1 && inputY + i <= 9; i++)
                {
                    if (board[inputX - i, inputY + i] == ' ')
                    {
                        break;
                    }
                    if (board[inputX - i, inputY + i] == own)
                    {
                        validMove = true;
                        break;
                    }
                }
                if (validMove)
                {
                    for (int i = 1; inputX - i >= 1 && inputY + i <= 9; i++)
                    {
                        if (board[inputX - i, inputY + i] == opponent)
                        {
                            board[inputX - i, inputY + i] = own;

                        }
                        else if (board[inputX - i, inputY + i] != opponent)
                        {
                            break;
                        }

                    }
                }
            }
            if (board[inputX - 1, inputY] == opponent)
            {
                bool validMove = false;
                for (int i = 1; inputX - i >= 1; i++)
                {
                    if (board[inputX - i, inputY] == ' ')
                    {
                        break;
                    }
                    if (board[inputX - i, inputY] == own)
                    {
                        validMove = true;
                        break;
                    }
                }
                if (validMove)
                {
                    for (int i = 1; inputX - i >= 1; i++)
                    {
                        if (board[inputX - i, inputY] == opponent)
                        {
                            board[inputX - i, inputY] = own;

                        }
                        else if (board[inputX - i, inputY] != opponent)
                        {
                            break;
                        }

                    }
                }
            }
            if (board[inputX - 1, inputY - 1] == opponent)
            {
                bool validMove = false;
                for (int i = 1; inputX - i >= 1 && inputY - i >= 1; i++)
                {
                    if (board[inputX - i, inputY - i] == ' ')
                    {
                        break;
                    }
                    if (board[inputX - i, inputY - i] == own)
                    {
                        validMove = true;
                        break;
                    }
                }
                if (validMove)
                {
                    for (int i = 1; inputX - i >= 1 && inputY - i >=1; i++)
                    {
                        if (board[inputX - i, inputY - i] == opponent)
                        {
                            board[inputX - i, inputY- i] = own;

                        }
                        else if (board[inputX - i, inputY - i] != opponent)
                        {
                            break;
                        }
                    }
                }

            }


        }

        // Checks if the board is full or if there are any valid moves to be made
        // If either are true, the game ends.
        public bool EndGame(bool BorW)
        {
            bool AnyValidMoves = false;
            bool AnyEmptyPlaces = false;
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (IsValidMove(i, j, BorW))
                    {
                        AnyValidMoves = true;
                    }  
                    if (board[i,j] == ' ')
                    {
                        AnyEmptyPlaces = true;
                    }
                }
            }
            
            if (AnyValidMoves | AnyEmptyPlaces)
            {
                return true;
            }
            return false;
        }

        //Keeps track of how many pieces of each type is pressent on board. 
        public void Score()
        {
            int ScoreO = 0;
            int ScoreX = 0;
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (board[i,j] == 'O')
                    {
                        ScoreO++;
                    }
                    if (board[i, j] == 'X')
                    {
                        ScoreX++;
                    }
                }
            }
            Console.WriteLine($"   Score:  O:{ScoreO}  X:{ScoreX}");
        }
    }
}
