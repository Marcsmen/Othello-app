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