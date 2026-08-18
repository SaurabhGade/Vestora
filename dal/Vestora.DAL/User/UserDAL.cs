using Microsoft.EntityFrameworkCore;
using Vestora.DAL.Data;
using Vestora.DAL.Entities;
using Vestora.DAL.Users;
namespace Vestora.DAL.Users;

public class UserDAL : IUserDAL
{
    private readonly VestoraDbContext m_objVestoraDbContext;

    public UserDAL(VestoraDbContext i_objVestoraDbContext)
    {
        m_objVestoraDbContext = i_objVestoraDbContext;
    }

    public async Task<User?> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken = default)
    {
        return await m_objVestoraDbContext.Users
            .FirstOrDefaultAsync(
                user => user.Email == email,
                cancellationToken);
    }

    public async Task<User?> GetByIdAsync(
        long userId,
        CancellationToken cancellationToken = default)
    {
        return await m_objVestoraDbContext.Users
            .FirstOrDefaultAsync(
                user => user.UserId == userId,
                cancellationToken);
    }

    public async Task<bool> EmailExistsAsync(
        string email,
        CancellationToken cancellationToken = default)
    {
        return await m_objVestoraDbContext.Users
            .AnyAsync(
                user => user.Email == email,
                cancellationToken);
    }

    public async Task<Entities.User?> GetUserByIdAsync(
    long userId)
    {
        return await m_objVestoraDbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(
                user => user.UserId == userId);
    }
        public async Task<User> CreateAsync(
        User user,
        CancellationToken cancellationToken = default)
    {
        await m_objVestoraDbContext.Users.AddAsync(
            user,
            cancellationToken);

        await m_objVestoraDbContext.SaveChangesAsync(
            cancellationToken);

        return user;
    }

    public async Task UpdateAsync(
        User user,
        CancellationToken cancellationToken = default)
    {
        m_objVestoraDbContext.Users.Update(user);

        await m_objVestoraDbContext.SaveChangesAsync(
            cancellationToken);
    }

}