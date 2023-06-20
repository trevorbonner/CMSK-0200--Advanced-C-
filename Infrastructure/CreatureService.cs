using Core;
using Core.Entities;

namespace Infrastructure
{
    public class CreatureService
    {
        public const int MoveMinValue = 1;
        public const int MoveMaxValue = 5;

        public CreatureService(GameBoardService gameBoardService)
        {
            this.gameBoardService = gameBoardService;
            Predators = new List<Predator>();
            Prey = new List<Prey>();
            preyToRemove = new List<Prey>();
            predatorsToRemove = new List<Predator>();
        }

        public List<Predator> Predators { get; set; }
        public List<Prey> Prey { get; set; }
        private GameBoardService gameBoardService { get; set; }
        private List<Predator> predatorsToRemove { get; set; }
        private List<Prey> preyToRemove { get; set; }

        public void InitializeCreatures(int preyCount, int predatorCount)
        {
            for (int i = 0; i < preyCount; i++)
            {
                var cell = gameBoardService.GetRandomEmptyCell();
                var prey = new Prey();
                Prey.Add(prey);
                cell.SetCell(prey);
            }

            for (int i = 0; i < predatorCount; i++)
            {
                var cell = gameBoardService.GetRandomEmptyCell();
                var predator = new Predator();
                Predators.Add(predator);
                cell.SetCell(predator);
            }
        }

        public void Move(int timeout)
        {
            var predatorCount = Predators.Count;
            for(int i = 0; i < predatorCount; i++)
            {
                Move(Predators[i]);
                Thread.Sleep(timeout);
            }

            foreach (var predator in predatorsToRemove)
            {
                Predators.Remove(predator);
            }

            foreach (var prey in preyToRemove)
            {
                Prey.Remove(prey);
            }

            var preyCount = Prey.Count;
            for (int i = 0; i < preyCount; i++)
            {
                Move(Prey[i]);
                Thread.Sleep(timeout);
            }
        }

        private void Move(CreatureBase creature)
        {
            creature.CurrentTurn++;
            var moveCell = gameBoardService.GetRandomDirectionalCell(creature.CurrentPosition);
            if (moveCell == null)
                return;

            creature.CurrentPosition.SetCell(null);
            moveCell.SetCell(creature);

            if (creature.CanBreed())
            {
                var freeCell = gameBoardService.GetRandomDirectionalCell(creature.CurrentPosition);

                if (freeCell == null)
                    return;

                switch (creature.CreatureType)
                {
                    case CreatureType.Predator:
                        var predator = new Predator();
                        freeCell.SetCell(predator);
                        Predators.Add(predator);
                        break;
                    case CreatureType.Prey:
                        var prey = new Prey();
                        freeCell.SetCell(prey);
                        Prey.Add(prey);
                        break;
                    default:
                        break;
                }
            }
        }

        private void Move(Predator predator)
        {
            //logic to eat
            var preyCell = gameBoardService.GetCellWithCreatureType(predator.CurrentPosition, CreatureType.Prey);
            if(preyCell != null)
            {
                predator.TurnsSinceEaten = 0;
                predator.CurrentPosition.SetCell(null);
                preyToRemove.Add((Prey)preyCell.Creature);
                preyCell.SetCell(predator);
            }
            else
            {
                predator.TurnsSinceEaten++;
            }

            Move((CreatureBase)predator);
            if (predator.HasStarved())
            {
                predator.CurrentPosition.SetCell(null);
                predatorsToRemove.Add(predator);
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
