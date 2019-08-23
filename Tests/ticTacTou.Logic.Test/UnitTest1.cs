using NUnit.Framework;
using ticTacTou.Logic;
using ticTacTou.Datatypes;

namespace Tests
{
    public class Tests
    {
        private readonly Map map = new Map();
        private readonly Player player = new Player('X', "Test-chan");
        
        [Test]
        public void MapTest1()
        {
            Assert.AreEqual(true, map.IsCellFree(0, 0));
        }

        [Test]
        public void MapTest2()
        {
            var cell = map.GetCell(2, 2);
            cell.Symbol = '0';
            Assert.AreEqual(false, map.IsCellFree(2, 2));
        }

        [Test]
        public void MapTest3()
        {
            map.SetCellSymbol(0, 0, player);
            map.SetCellSymbol(0, 1, player);
            map.SetCellSymbol(0, 2, player);
           
            Assert.AreEqual(true,  map.CheckRow(1, player.Symbol));
        }

        [Test]
        public void MapTest4()
        {
             
            map.SetCellSymbol(1, 1, player);

            Assert.AreEqual(false, map.IsCellFree(1, 1));
        }

        [Test]
        public void MapTest5()
        {
            map.Clean();
            map.SetCellSymbol(0, 1, player);   
            map.SetCellSymbol(1, 1, player);   
            map.SetCellSymbol(2, 1, player);   

            Assert.AreEqual(true, map.CheckColumn(2, player.Symbol));
        }

        [Test]
        public void MapTest6()
        {
            map.Clean();
            map.SetCellSymbol(0, 0, player);
            map.SetCellSymbol(1, 1, player);
            map.SetCellSymbol(2, 2, player);
            Assert.AreEqual(true, map.CheckDiagonals(player.Symbol));
        }

        [Test]
        public void MapTest7()
        {
            map.Clean();
            map.SetCellSymbol(0, 2, player);
            map.SetCellSymbol(1, 1, player);
            map.SetCellSymbol(2, 0, player);
            Assert.AreEqual(true, map.CheckDiagonals(player.Symbol));
        }
    }
}
