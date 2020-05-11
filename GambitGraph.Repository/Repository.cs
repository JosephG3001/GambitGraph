using GambitGraph.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace GambitGraph.Repository
{
    public abstract class Repository
    {
        protected Gambitbot13Context Context { get; private set; }

        public Repository(Gambitbot13Context context)
        {
            Context = context;
        }
    }
}
