using System;

namespace ticTacTou.Datatypes
{
    public class Player :  Actor
    {
        public Player (char symbol, string name)
        {
            Symbol = symbol;
            Name   = name;
        }  
    }
}
