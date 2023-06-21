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
    }
}
