using System;
using ticTacTou.Datatypes;

namespace ticTacTou.Logic
{
    public class RenderObj
    {
        private IView Obj    { get; set; }
        private IView[] Objs { get; set; }
    
        public RenderObj(IView obj)
        {
            Obj = obj;
        }

        public RenderObj(IView[] objs)
        {
            Objs = objs;
        }
        
        public void Render(IView obj)
        {
            int pLeft = Console.CursorLeft;
            int pTop  = Console.CursorTop;
            Console.SetCursorPosition(obj.Y, obj.X);
            Console.Write(obj.Symbol);
            Console.SetCursorPosition(pLeft, pTop);
        }
        public void RenderWithOffset(IView obj, int offsetX, int offsetY)
        {
            int pLeft = Console.CursorLeft;
            int pTop  = Console.CursorTop;
            Console.SetCursorPosition(obj.X + offsetX, obj.Y + offsetY);
            Console.Write(obj.Symbol);
            Console.SetCursorPosition(pLeft, pTop);
        }

        public void Render()
        {
            Render(Obj);
        }
        
        public void RenderObjs()
        {
            foreach (var item in Objs)
                Render(item);
        }
    }
}
