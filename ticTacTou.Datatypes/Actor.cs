using System;

namespace ticTacTou.Datatypes
{
    public abstract class Actor : IView, IActor
    {
        int _x = 0;
        int _y = 0;
        char _symbol = ' ';
        
        string _name = "";

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public char Symbol { get => _symbol; set => _symbol = value; }
        public string Name { get => _name;   set => _name = value; }

    }
}
