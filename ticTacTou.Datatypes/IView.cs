using System;

namespace ticTacTou.Datatypes
{
    public interface IView
    {
        int X { get; set; }
        int Y { get; set; }
        char Symbol { get; set; }
    }
}
