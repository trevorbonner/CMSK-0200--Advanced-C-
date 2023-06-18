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

        public GameBoard(int xSpaces, int ySpaces)
        {
            Cells = new GameBoardCell[xSpaces, ySpaces];
            Width = xSpaces;
            Height = ySpaces;

            for (int x = 0; x < xSpaces; x++)
            {
                for(int y = 0; y < ySpaces; y++)
                {
                    Cells[x, y] = new GameBoardCell(x, y);
                }
            }
        }

        public GameBoardCell[,] Cells { get; }

        public void GenerateGameBoard()
        {
            Console.SetCursorPosition(0, 2);

            for (int x = 0; x < Width; x++)
            {                
                for (int y = 0; y < Height; y++)
                {
                    Cells[x, y].WriteCell();
                }

                Console.WriteLine();
            }           
        }
    }
}
