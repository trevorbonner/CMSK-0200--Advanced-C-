using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Prey : CreatureBase
    {
        public override int TurnsTillBreed
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
                return CreatureType.Prey;
            }
        }
    }
}
