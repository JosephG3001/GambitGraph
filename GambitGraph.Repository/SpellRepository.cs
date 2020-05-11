using GambitGraph.Common.Repository;
using GambitGraph.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GambitGraph.Repository
{
    public class SpellRepository : Repository, ISpellRepository
    {
        public SpellRepository(Gambitbot13Context context) : base (context)
        {
        }

        public async Task<ICollection<Spells>> GetAll()
        {
            return await Context.Spells.ToListAsync();
        }

        public async Task<ICollection<Spells>> Search(string english)
        {
            return await Context.Spells
                .Where(m => m.English != null && m.English.Contains(english))
                .ToListAsync();
        }

        public async Task<Spells> GetById(int id)
        {
            return await Context.Spells.SingleOrDefaultAsync(m => m.SpellId == id);
        }

        public async Task<Spells> Add(Spells spell)
        {
            Context.Spells.Add(spell);
            await Context.SaveChangesAsync();
            return spell;
        }
    }
}
