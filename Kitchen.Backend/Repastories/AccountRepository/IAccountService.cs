using Kitchen.Backend.Model;

namespace Kitchen.Backend.Repastories.AccountRepository
{
    public interface IAccountService
    {
        Task<bool> SignUpAsync(User user);
    }
}
