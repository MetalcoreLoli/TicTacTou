using System;
using ticTacTou.Datatypes;
using System.Linq;
using System.Collections.Generic;

namespace ticTacTou.Logic
{
    public class Map
    {
        public const int MAP_WIDHT  = 3;
        public const int MAP_HEIGTH = 3;

        public Cell[] Cells { get; private set; }
        private Dictionary<int, Cell[]> _rows;
        private Dictionary<int, Cell[]> _columns;

        public Map()
        {
            Cells = new Cell[MAP_WIDHT * MAP_HEIGTH];
            Init();
            _rows = new Dictionary<int, Cell[]> {
                [1] = Cells.Take(3).ToArray(),
                [2] = Cells.Skip(3).Take(3).ToArray(),
                [3] = Cells.Skip(6).Take(3).ToArray(),
            };

            _columns = new Dictionary<int, Cell[]> {
                [1] = Cells.Where(cell => cell.Y.Equals(0)).ToArray(),
                [2] = Cells.Where(cell => cell.Y.Equals(1)).ToArray(),
                [3] = Cells.Where(cell => cell.Y.Equals(2)).ToArray(),
            };
       
        }
       
        private void Init()
        {
            for (int x = 0; x < MAP_WIDHT; x++)
                for (int y = 0; y < MAP_HEIGTH; y++)
                {
                    Cells[x * MAP_WIDHT + y] = new Cell(x, y);
                }
        }
        
        public void Clean()
        {
            foreach (var cell in Cells)
                cell.Symbol = '-';
        }
            
        public bool IsCellFree(int x, int y) {
            return Cells[x * MAP_HEIGTH + y].Symbol == '-';
        }
       
        public Cell GetCell(int x, int y) => Cells[x * MAP_HEIGTH + y];
        
        public void SetCellSymbol(int x, int y, Actor actor) 
        {
            if (IsCellFree(x, y))
                GetCell(x, y).Symbol = actor.Symbol;
        }
        
        public bool IsActoreWin(Actor actor)
        {
            return (CheckRow(1, actor.Symbol) || CheckRow(2, actor.Symbol) || CheckRow(3, actor.Symbol)) 
                || (CheckColumn(1, actor.Symbol)) || (CheckColumn(2, actor.Symbol)) || (CheckColumn(3, actor.Symbol)) 
                || CheckDiagonals(actor.Symbol);    
        } 
        
        public bool CheckRow(int rowNumber, char symbol)
        {
            return _rows[rowNumber].All(cell => cell.Symbol.Equals(symbol));
        }
        
        public bool CheckColumn(int columnNumber, char symbol)
        {
            return _columns[columnNumber].All(cell => cell.Symbol.Equals(symbol));
        } 
        /*
         * 0,0 0,1 0,2
         * 1,0 1,1 1,2
         * 2,0 2,1 2,2 
         */
        public bool CheckDiagonals(char symbol)
        {
            var falseD = Cells.Where(cell => (cell.X + cell.Y).Equals(MAP_WIDHT - 1));
            var mainD = Cells.Where(cell => (cell.X == cell.Y));
            return falseD.All(cell => cell.Symbol.Equals(symbol)) || mainD.All(cell => cell.Symbol.Equals(symbol));
        } 
    }
 }
