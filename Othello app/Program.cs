using System;

namespace Othello_app
{
    class Program
    {
        static void Main()
        {
            bool ContinueGame = true;
            bool Turn = true;
            GameBoard game = new GameBoard();
            
            while (ContinueGame)
            {
                Console.WriteLine();

                if (game.EndGame(Turn))
                {
                    Console.Clear();
                    if (Turn == true)
                    {
                        game.Score();
                        game.Print();
                        game.Userinput(Turn);
                        Turn = false;
                    }
                    else
                    {
                        game.Score();
                        game.Print();
                        game.Userinput(Turn);
                        Turn = true;
                    }
                }
                else
                {
                    game.Print();
                    Console.WriteLine("   Game has ended!");
                    game.Score();
                    ContinueGame = false;
                }

            }
        }
    }
}