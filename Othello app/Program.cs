using System;

namespace Othello_app

{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard game = new GameBoard();

            while (true)
            {
                game.Print();
                game.Userinput();
            }
            

            

            
        }
    }
}