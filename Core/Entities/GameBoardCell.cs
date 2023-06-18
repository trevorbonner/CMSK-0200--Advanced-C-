namespace Core.Entities
{
    public class GameBoardCell
    {
        public GameBoardCell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public CreatureBase Creature { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public void SetCell(CreatureBase creature)
        {
            Creature = creature;
            if (creature != null)
                creature.CurrentPosition = this;
        }

        public void WriteCell()
        {
            if (Creature == null)
            {
                Console.Write("-");
                return;
            }

            switch (Creature.CreatureType)
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
