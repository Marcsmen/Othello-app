using System;

namespace Othello_app

{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard game = new GameBoard();
            game.UpdateBoard(2,2);
            game.Print();



            Console.ReadLine();
        }
    }
}