using System;
using ticTacTou.Datatypes;
using ticTacTou.Logic;

namespace ticTacTou.Logic
{
    public class Game
    {
        public Player PlayerBuilder(string name, char sym)
            => new Player(sym, name);        
    
        private Map _map;
        private RenderObj _renderCells;     
       
        private void DrawPlayer(Actor actor, int x, int y) 
        {
            _map.SetCellSymbol(x, y, actor);
            
        }
        
        private void Init()
        {
            _map = new Map();
            _renderCells = new RenderObj(_map.Cells);
        }

        public Game() 
        {
            Init();
        }
        
        public void DrawMap()
        {
            _renderCells.RenderObjs();
        }
        
        public void PlayerTurn(Actor actor)
        {
            Console.SetCursorPosition(0, 4);
            Console.WriteLine(actor.Name + " your turn");
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());
            DrawPlayer(actor, x, y);
        }

        public void Start()
        {
            var player    = PlayerBuilder("Test-chan", 'X');
            var playerOne = PlayerBuilder("TestOne-chan", '0');
            while(true)
            {
                DrawMap(); 
                PlayerTurn(player);
                if (_map.IsActoreWin(player)) 
                {
                   Console.Clear();
                   Console.WriteLine(player.Name + " win");
                   break;
                }
                Console.Clear();
                DrawMap();
                PlayerTurn(playerOne);
                if (_map.IsActoreWin(playerOne)) 
                {
                   Console.Clear();
                   Console.WriteLine(playerOne.Name + " win");
                   break;
                }
                Console.Clear();
            }
        } 
    }
}
