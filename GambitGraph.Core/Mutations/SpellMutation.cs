using GambitGraph.Common.Repository;
using GambitGraph.Core.Types;
using GambitGraph.DataAccess;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GambitGraph.Core.Mutations
{
    public class SpellMutation : ObjectGraphType
    {
        public SpellMutation()
        {
            Field<SpellType>(
                "addSpell",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<SpellInputType>> { Name = "spell" }
                ),
                resolve: context => {
                    var spell = context.GetArgument<Spells>("spell");
                    return context.GetService<ISpellRepository>().Add(spell);
                }
            );
        }
    }
}
