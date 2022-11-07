using Microsoft.EntityFrameworkCore;
using MusicPlayerBackend.Data;
using MusicPlayerBackend.Helpers;
using MusicPlayerBackend.Models.DTOs;
using MusicPlayerBackend.Repositories.Interfaces;

namespace MusicPlayerBackend.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly IDbContextFactory<AppDbContext> _context;
        private readonly Validator _userCredentialsValidator;
        public SongRepository(IDbContextFactory<AppDbContext> context)
        {
            _context = context;
            _userCredentialsValidator = new Validator();
        }

        public Task<SongDTO?> AddAsync(SongDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync(string entity)
        {
            throw new NotImplementedException();
        }

        public Task<SongDTO?> UpdateAsync(SongDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
