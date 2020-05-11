using GambitGraph.DataAccess;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GambitGraph.Core.Types
{
    public class SpellInputType : InputObjectGraphType
    {
        public SpellInputType()
        {            
            Field<NonNullGraphType<StringGraphType>>(nameof(Spells.English));
        }
    }
}
