using System;
using System.Collections.Generic;
using System.Text;

namespace Othello_app
{
    class Disk 
    {
        
        private int xCordinate;
        private int yCordinate;
        private char[,] diskCordinate;       

        public Disk(int x, int y, bool BorW)
        {
            xCordinate = x;
            yCordinate = y;
            diskCordinate = new char[xCordinate+1, yCordinate+1];

            if (BorW == true)
            {
                diskCordinate[xCordinate, yCordinate] = 'X';
            }
            if (BorW == false)
            {
                diskCordinate[xCordinate, yCordinate] = 'O';
            }
        }

        public char CreateDisk()
        {
            return diskCordinate[xCordinate, yCordinate];
        }
    }
}
