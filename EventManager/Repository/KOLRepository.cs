using EventManager.Data;
using EventManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Repository
{
    public class KOLRepository:IKOLRepository
    {
        private readonly EventContext _context;

        public KOLRepository(EventContext context)
        {
            _context = context;
        }
        public async Task<List<KOLModel>> GetAllKOLsAsync()
        {
            var records = await _context.KOL.Select(x => new KOLModel()
            {
                CountryId = x.CountryId,
                CreatedBy = x.CreatedBy,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                IsDeleted = x.IsDeleted,
                KOLId = x.KOLId,
                ProfileImage = x.ProfileImage
            }).ToListAsync();
            return records;
        }

        public async Task<KOLModel> GetKOLByIdAsync(int kolId)
        {
            var records = await _context.KOL.Where(x => x.KOLId == kolId).Select(x => new KOLModel()
            {
                CountryId = x.CountryId,
                CreatedBy = x.CreatedBy,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                IsDeleted = x.IsDeleted,
                KOLId = x.KOLId,
                ProfileImage = x.ProfileImage               
            }).FirstOrDefaultAsync();
            return records;
        }
        public async Task<int> AddKOLAsync(KOLModel kolModel)
        {
            var kol = new KOL()
            {
                KOLId = kolModel.KOLId,
                CountryId = kolModel.CountryId,
                CreatedBy= kolModel.CreatedBy,
                Email = kolModel.Email,
                FirstName = kolModel.FirstName,
                LastName = kolModel.LastName,
                IsDeleted = kolModel.IsDeleted,
                ProfileImage= kolModel.ProfileImage
            };
            _context.KOL.Add(kol);
            await _context.SaveChangesAsync();
            return kol.KOLId;
        }

        public async Task UpdateKOLAsync(int kolId, KOLModel kolModel)
        {
            var kol = new KOL()
            {
                CountryId = kolModel.CountryId,
                CreatedBy = kolModel.CreatedBy,
                Email = kolModel.Email,
                FirstName = kolModel.FirstName,
                LastName = kolModel.LastName,
                IsDeleted = kolModel.IsDeleted,
                ProfileImage = kolModel.ProfileImage
            };
            _context.KOL.Update(kol);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteKOLAsync(int kolId)
        {
            var kol = new KOL() { KOLId = kolId };
            _context.KOL.Remove(kol);
            await _context.SaveChangesAsync();
        }
    }
}
