using GambitGraph.DataAccess;
using GraphQL.Types;
using System;

namespace GambitGraph.Core.Types
{
    public class SpellType : ObjectGraphType<Spells>
    {
        public SpellType()
        {
            Field(m => m.English);
            Field(m => m.SpellId);
        }
    }
}
