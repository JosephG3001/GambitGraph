﻿using Newtonsoft.Json.Linq;
using System;

namespace GambitGraph.Common
{
    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}
