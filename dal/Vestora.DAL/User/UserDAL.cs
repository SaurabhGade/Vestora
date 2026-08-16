using Microsoft.EntityFrameworkCore;
using Vestora.DAL.Data;
using Vestora.DAL.Entities;

namespace Vestora.DAL.Users;

public class UserDAL : IUserDAL
{
    private readonly VestoraDbContext _dbContext;

    public UserDAL(VestoraDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(
                user => user.Email == email,
                cancellationToken);
    }

    public async Task<User?> GetByIdAsync(
        long userId,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(
                user => user.UserId == userId,
                cancellationToken);
    }

    public async Task<bool> EmailExistsAsync(
        string email,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users
            .AnyAsync(
                user => user.Email == email,
                cancellationToken);
    }

    public async Task<User> CreateAsync(
        User user,
        CancellationToken cancellationToken = default)
    {
        await _dbContext.Users.AddAsync(
            user,
            cancellationToken);

        await _dbContext.SaveChangesAsync(
            cancellationToken);

        return user;
    }

    public async Task UpdateAsync(
        User user,
        CancellationToken cancellationToken = default)
    {
        _dbContext.Users.Update(user);

        await _dbContext.SaveChangesAsync(
            cancellationToken);
    }
}