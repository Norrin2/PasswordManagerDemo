using PasswordManager.Models;

namespace PasswordManager.Repositories
{
    public interface IPasswordCardRepository
    {
        void Add(PasswordCard savedPassword);
        bool Delete(Guid id);
        IEnumerable<PasswordCard> FindAll();
        IEnumerable<PasswordCard> FindByName(string searchParam);
        PasswordCard? Update(PasswordCard savedPassword);
    }
}