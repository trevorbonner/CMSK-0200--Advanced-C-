using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class GameBoard
    {
        public int Width { get; }
        public int Height { get; }

        public GameBoard(int width, int height)
        {
            Cells = new GameBoardCell[width, height];
            Width = width;
            Height = height;          
        }

        public GameBoardCell[,] Cells { get; }
    }
}
