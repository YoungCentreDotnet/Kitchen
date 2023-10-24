using Kitchen.Backend.DataLayer;
using Kitchen.Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Backend.Repastories.AccountRepository
{
    public class AccountService : IAccountService
    {
        private readonly KitchenDbContext _context;

        public AccountService(KitchenDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SignUpAsync(User user)
        {
            if (user == null)
            {
                return false;
            }
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
