using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public abstract class CreatureBase
    {
        public abstract int TurnsTillBreed { get; }
        public abstract CreatureType CreatureType { get; }
        public int CurrentTurn { get; set; }
        public GameBoardCell CurrentPosition { get; set; }

        public bool CanBreed()
        {
            return CurrentTurn % TurnsTillBreed == 0;
        }
    }
}
