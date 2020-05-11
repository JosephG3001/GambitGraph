using GambitGraph.DataAccess;
using GraphQL.Types;
using System;

namespace GambitGraph.Core.Types
{
    public class SpellType : ObjectGraphType<Spells>
    {
        public SpellType()
        {
            //Field(m => m.Absorbs);
            Field(m => m.Alias);
            Field(m => m.Casttime);
            Field(m => m.CasttimeSpecified);
            Field(m => m.Duration);
            Field(m => m.Element);
            Field(m => m.English);
            //Field(m => m.Heals);
            Field(m => m.Id);
            Field(m => m.IdSpecified);
            Field(m => m.Index);
            Field(m => m.Mpcost);
            Field(m => m.MpcostSpecified);
            //Field(m => m.Nukes);
            Field(m => m.Prefix);
            Field(m => m.Recast);
            Field(m => m.RecastSpecified);
            Field(m => m.Skill);
            Field(m => m.SpellId);
            //Field(m => m.SpellJobLevels);
            Field(m => m.Targets);
            Field(m => m.Type);
        }
    }
}
