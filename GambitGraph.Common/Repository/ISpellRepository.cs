using GambitGraph.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GambitGraph.Common.Repository
{
    public interface ISpellRepository
    {
        Task<ICollection<Spells>> GetAll();
        Task<Spells> GetById(int id);
        Task<ICollection<Spells>> Search(string english);
    }
}
