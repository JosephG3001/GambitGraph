using GambitGraph.Common.Repository;
using GambitGraph.Core.Types;
using GambitGraph.DataAccess;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GambitGraph.Core.Queries
{
    public class SpellQuery : ObjectGraphType
    {
        enum SpellQueryNames
        {
            spell,
            allspells,
            searchspells,
        }

        // .Net Core 3 added some additional DI features that prevent scoped services from being injectable into Singletons which is why we need to use a custom resolver
        public SpellQuery(/*ISpellRepository spellRepository*/)
        {
            Field<ListGraphType<SpellType>>(
                SpellQueryNames.allspells.ToString(), 
                resolve: context => context.GetService<ISpellRepository>().GetAll()
            );

            Field<ListGraphType<SpellType>>(
                SpellQueryNames.searchspells.ToString(),
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = nameof(Spells.English).ToLower() }
                ),
                resolve: context => {
                    string english = context.GetArgument<string>(nameof(Spells.English).LowerFirstLetter());
                    return context.GetService<ISpellRepository>().Search(english);
                }
            );

            Field<SpellType>(
                SpellQueryNames.spell.ToString(),
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = nameof(Spells.SpellId) }
                ),
                resolve: context => {
                    int spellId = context.GetArgument<int>(nameof(Spells.SpellId).LowerFirstLetter());
                    return context.GetService<ISpellRepository>().GetById(spellId);
                }
            );            
        }
    }
}
