using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Entities
{
    public class Monster : GameEntity
    {
        public Monster() : base(150, 100, 10)
        {
        }

        public override string Name => "Monster";

        public override bool StrongAgainst(GameEntity entity)
        {
            if (entity is Human || entity is Slime)
                return true;
            return false;
        }

        public override bool WeakAgainst(GameEntity entity)
        {
            if (entity is Human)
                return true;
            return false;
        }
    }
}
