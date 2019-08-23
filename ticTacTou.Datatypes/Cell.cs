using System;

namespace ticTacTou.Datatypes
{
    public class Cell : IView 
    {
        int _x = 0;
        int _y = 0;
        char _symbol = '-';

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }

        public char Symbol { get => _symbol; set => _symbol = value; } 
        
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
