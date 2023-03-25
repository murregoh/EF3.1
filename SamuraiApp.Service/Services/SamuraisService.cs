using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using SamuraiApp.Service.Interfaces;

namespace SamuraiApp.Service.Services
{
    public class SamuraisService : ISamuraisService
    {
        private readonly SamuraiContext samuraiContext;

        public SamuraisService(SamuraiContext samuraiContext)
        {
            this.samuraiContext = samuraiContext;
        }

        public async Task<Samurai> GetSamuraiById(int samuraiId) =>
            await samuraiContext.Samurais.FindAsync(samuraiId);

        public async Task<IEnumerable<Samurai>> GetSamurais() =>
            await samuraiContext.Samurais.ToListAsync();

        public async Task<int> CreateSamurai(Samurai samurai)
        {
            await samuraiContext.Samurais.AddAsync(samurai);
            await samuraiContext.SaveChangesAsync();
            return samurai.Id;
        }

        public async Task<bool> DeleteSamurai(int samuraiId)
        {
            Samurai samurai = await samuraiContext.Samurais.FindAsync(samuraiId);
            if (samurai == null)
                return false;

            samuraiContext.Samurais.Remove(samurai);
            await samuraiContext.SaveChangesAsync();
            return true;
        }

        public async Task UpdateSamurai(int samuraiId, Samurai samurai)
        {
            if (!samuraiId.Equals(samurai.Id))
                throw new System.ArgumentException("The Samuria does not match with the Id");

            samuraiContext.Entry(samurai).State = EntityState.Modified;
            await samuraiContext.SaveChangesAsync();
        }
    }
}