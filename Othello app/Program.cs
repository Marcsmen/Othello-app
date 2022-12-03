using System;

namespace Othello_app

{
    class Program
    {
        static void Main()
        {
            
            bool Turn = true;
            GameBoard game = new GameBoard();
          
            while (true)
            {
                Console.WriteLine("In main loop");
                if(Turn == true)
                {
                    game.Print();
                    game.Userinput(Turn);
                    Turn = false;
                }
                else 
                {
                    game.Print();
                    game.Userinput(Turn);
                    Turn = true;
                }

                
            }
            
        }
    }
}