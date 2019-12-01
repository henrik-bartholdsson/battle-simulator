using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Entities
{
    public class Slime : GameEntity
    {
        public Slime() : base(50, 20, 5)
        {
        }

        public override string Name => "Slime";

        public override bool StrongAgainst(GameEntity entity)
        {
            return false;
        }

        public override bool WeakAgainst(GameEntity entity)
        {
            return true;
        }
    }
}
