using GambitGraph.Core.Queries;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GambitGraph.Core
{
    public class GambitGraphSchema : Schema
    {
        public GambitGraphSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<SpellQuery>();
        }
    }
}
