﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace GambitGraph.DataAccess
{
    public partial class Absorbs
    {
        public int AbsorbId { get; set; }
        public int SpellId { get; set; }
        public int? StatusEffectId { get; set; }
        public int Priority { get; set; }
        public bool EnabledByDefault { get; set; }
        public int ActionTypeId { get; set; }

        public virtual Spells Spell { get; set; }
    }
}