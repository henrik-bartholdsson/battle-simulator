using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Entities
{
    public class Human : GameEntity
    {
        public Human() : base(200, 50, 10)
        {
        }
        public override string Name => "Human";

        public override bool StrongAgainst(GameEntity entity)
        {
            if (entity is Monster || entity is Slime)
                return true;
            return false;
        }

        public override bool WeakAgainst(GameEntity entity)
        {
            if (entity is Monster || entity is Dragon)
                return true;
            return false;
        }
    }
}
