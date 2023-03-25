using System.Collections.Generic;
using System.Threading.Tasks;
using SamuraiApp.Domain;

namespace SamuraiApp.Service.Interfaces
{
    public interface ISamuraisService
    {
        Task<IEnumerable<Samurai>> GetSamurais();
        Task<Samurai> GetSamuraiById(int samuraiId);
        Task<int> CreateSamurai(Samurai samurai);
        Task<bool> DeleteSamurai(int samuraiId);
        Task UpdateSamurai(int samuraiId, Samurai samurai);
    }
}