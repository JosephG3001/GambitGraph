using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public static class ContextExtensions
    {
        public static T GetService<T>(this ResolveFieldContext<object> context)
        {
            return ((Schema)context.Schema).DependencyResolver.Resolve<T>();
        }
    }
}
