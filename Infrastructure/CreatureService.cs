using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class CreatureService
    {
        public const int MoveMinValue = 1;
        public const int MoveMaxValue = 5;

        public CreatureService()
        {
            Predators = new List<Predator>();
            Prey = new List<Prey>();
            Random = new Random();
        }

        internal Random Random { get; set; }
        public List<Predator> Predators { get; set; }
        public List<Prey> Prey { get; set; }
        public GameBoard Board { get; set; }

        public void InitializeCreatures(GameBoard board, int preyCount, int predatorCount)
        {
            Board = board;

            for (int i = 0; i < preyCount; i++)
            {
                var cell = GetRandomEmptyCell();
                var prey = new Prey();
                Prey.Add(prey);
                cell.SetCell(prey);
            }

            for (int i = 0; i < predatorCount; i++)
            {
                var cell = GetRandomEmptyCell();
                var predator = new Predator();
                Predators.Add(predator);
                cell.SetCell(predator);
            }
        }

        public GameBoardCell GetRandomEmptyCell()
        {
            bool findEmptyCell = true;
            GameBoardCell cell = null;

            while (findEmptyCell)
            {
                var x = Random.Next(Board.Width);
                var y = Random.Next(Board.Height);
                if (IsEmptyCell(x, y))
                {
                    findEmptyCell = false;
                    cell = Board.Cells[x, y];
                }
            }

            return cell;
        }

        bool IsEmptyCell(int x, int y)
        {
            return Board.Cells[x, y].Creature == null;
        }

        public void Move()
        {
            foreach(var prey in Prey)
            {
                Thread.Sleep(250); //Sleep half a second
            }

            foreach(var predator in Predators)
            {
                Thread.Sleep(250); //Sleep half a second

            }
        }

        public bool IsExtinction()
        {
            if(Prey.Count == 0 || Predators.Count == 0)
                return true;

            return false;
        }
    }
}
