using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Entities
{
    public class Dragon : GameEntity
    {
        public Dragon() : base(2000, 200, 30)
        {

        }

        public override string Name => "Dragon";

        public override bool StrongAgainst(GameEntity entity)
        {
            return true;
        }

        public override bool WeakAgainst(GameEntity entity)
        {
            return false;
        }
    }
}
