using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Predator : CreatureBase
    {
        public override int TurnsTillBreed
        {
            get
            {
                return 8;
            }
        }

        public int TurnsSinceEaten { get; set; }

        public int TurnsTillStarve
        {
            get
            {
                return 3;
            }
        }

        public override CreatureType CreatureType
        {
            get
            {
                return CreatureType.Predator;
            }
        }

        public bool HasStarved()
        {
            return TurnsSinceEaten > TurnsTillStarve;
        }
    }
}
