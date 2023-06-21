using Core;
using Core.Entities;

namespace Infrastructure
{
    public class GameBoardService
    {
        public GameBoardService()
        {
            random = new Random();
        }

        private Random random { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public GameBoard Board { get; set; }

        public void CreateBoard(int width, int height)
        {
            Width = width;
            Height = height;

            Board = new GameBoard(Width, Height);
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Board.Cells[x, y] = new GameBoardCell(x, y);
                }
            }
        }

        public GameBoardCell GetRandomEmptyCell()
        {
            bool findEmptyCell = true;
            GameBoardCell cell = null;

            while (findEmptyCell)
            {
                var x = random.Next(Width);
                var y = random.Next(Height);
                if (IsEmptyCell(x, y))
                {
                    findEmptyCell = false;
                    cell = Board.Cells[x, y];
                }
            }

            return cell;
        }

        public GameBoardCell GetRandomDirectionalCell(GameBoardCell cell)
        {
            int attempts = 0;
            while(attempts != 10)
            {
                var randomDirection = random.Next(4);
                Move move = (Move)randomDirection;              

                var potentialCell = EmptyDirectionCell(cell, move);
                if (potentialCell != null)
                    return potentialCell;
                else
                    attempts++;
            }

            return null;
        }

        private GameBoardCell EmptyDirectionCell(GameBoardCell cell, Move move)
        {
            switch (move)
            {
                case Move.Up:
                    if (cell.Y > 0 && Board.Cells[cell.X, cell.Y - 1].Creature == null)
                        return Board.Cells[cell.X, cell.Y - 1];
                    break;
                case Move.Down:
                    if (cell.Y < Height - 1 && Board.Cells[cell.X, cell.Y + 1].Creature == null)
                        return Board.Cells[cell.X, cell.Y + 1];
                    break;
                case Move.Left:
                    if (cell.X > 0 && Board.Cells[cell.X - 1, cell.Y].Creature == null)
                        return Board.Cells[cell.X - 1, cell.Y];
                    break;
                case Move.Right:
                    if (cell.X < Width - 1 && Board.Cells[cell.X + 1, cell.Y].Creature == null)
                        return Board.Cells[cell.X + 1, cell.Y];
                    break;
            }

            return null;
        }

        private bool IsEmptyCell(int x, int y)
        {
            return Board.Cells[x, y].Creature == null;
        }

        public GameBoardCell GetCellWithCreatureType(GameBoardCell cell, CreatureType type)
        {
            for(int i = 0; i < 4; i++)
            {
                switch ((Move)i)
                {
                    case Move.Up:
                        if (cell.Y > 0 && Board.Cells[cell.X, cell.Y - 1].Creature != null && Board.Cells[cell.X, cell.Y - 1].Creature.CreatureType == type)
                            return Board.Cells[cell.X, cell.Y - 1];
                        break;
                    case Move.Down:
                        if (cell.Y < Height - 1 && Board.Cells[cell.X, cell.Y + 1].Creature != null && Board.Cells[cell.X, cell.Y + 1].Creature.CreatureType == type)
                            return Board.Cells[cell.X, cell.Y + 1];
                        break;
                    case Move.Left:
                        if (cell.X > 0 && Board.Cells[cell.X - 1, cell.Y].Creature != null && Board.Cells[cell.X - 1, cell.Y].Creature.CreatureType == type)
                            return Board.Cells[cell.X - 1, cell.Y];
                        break;
                    case Move.Right:
                        if (cell.X < Width - 1 && Board.Cells[cell.X + 1, cell.Y].Creature != null && Board.Cells[cell.X + 1, cell.Y].Creature.CreatureType == type)
                            return Board.Cells[cell.X + 1, cell.Y];
                        break;
                }
            }

            return null;
        }

        public void GenerateGameBoard()
        {
            Console.SetCursorPosition(0, 2);

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    WriteCell(Board.Cells[x, y]);
                }

                Console.WriteLine();
            }
        }

        private void WriteCell(GameBoardCell cell)
        {
            if (cell.Creature == null)
            {
                Console.Write("-");
                return;
            }

            switch (cell.Creature.CreatureType)
            {
                case CreatureType.Predator:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("X");
                    break;
                case CreatureType.Prey:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("O");
                    break;
                default:
                    Console.Write("Unknown");
                    break;
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
