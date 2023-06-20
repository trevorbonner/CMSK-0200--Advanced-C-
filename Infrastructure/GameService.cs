namespace Infrastructure
{
    public class GameService
    {
        public GameService(GameBoardService gameBoardService, CreatureService creatureService)
        {
            this.creatureService = creatureService;
            this.gameBoardService = gameBoardService;
        }

        private CreatureService creatureService { get; }
        private GameBoardService gameBoardService { get; set; }
        public int Iteration { get; set; }
        public bool IsGameOver { get; set; }

        public void StartGame(int width, int height, int preyCount, int predatorCount)
        {
            gameBoardService.CreateBoard(width, height);
            creatureService.InitializeCreatures(preyCount, predatorCount);
            gameBoardService.GenerateGameBoard();
            WriteIteration();
        }

        public void NextIteration()
        {
            Iteration++;
            creatureService.Move(0);
            if(creatureService.IsExtinction())
                IsGameOver = true;

            WriteIteration();
        }

        private void WriteIteration()
        {
            gameBoardService.GenerateGameBoard();
            Console.SetCursorPosition(0, gameBoardService.Height + 4);
            Console.WriteLine($"Iteration: {Iteration}");
        }
    }
}
