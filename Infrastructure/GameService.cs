using Core.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class GameService
    {
        public GameService()
        {
            CreatureService = new CreatureService();
        }

        protected CreatureService CreatureService { get; }
        public GameBoard GameBoard { get; private set; }
        public int Iteration { get; set; }

        public bool IsGameOver { get; set; }

        public void StartGame(int x, int y, int preyCount, int predatorCount)
        {
            GameBoard = new GameBoard(x, y);
            CreatureService.InitializeCreatures(GameBoard, preyCount, predatorCount);
            GameBoard.GenerateGameBoard();
        }

        public void NextIteration()
        {
            Iteration++;
            CreatureService.Move();
            if(CreatureService.IsExtinction())
                IsGameOver = true;

            Console.WriteLine($"Iteration: {Iteration}");
        }
    }
}
