using PasswordManager.Models;

namespace PasswordManager.Repositories
{
    public class PasswordCardRepository : IPasswordCardRepository
    {
        private List<PasswordCard> _savedPasswords = new List<PasswordCard>();

        public void Add(PasswordCard savedPassword) => _savedPasswords.Add(savedPassword);

        public bool Delete(Guid id)
        {
            if (!FindById(id)) return false;

            _savedPasswords = _savedPasswords.Where(s => s.Id != id).ToList();
            return true;
        }

        public PasswordCard? Update(PasswordCard savedPassword)
        {
            var existingPassword = _savedPasswords.FirstOrDefault(s => s.Id == savedPassword.Id);

            if (existingPassword != null)
            {
                int index = _savedPasswords.FindIndex(s => s.Id == savedPassword.Id);
                if (index != -1)
                {
                    _savedPasswords[index] = savedPassword;
                    return _savedPasswords[index];
                }
            }

            return null;
        }

        public IEnumerable<PasswordCard> FindAll() => _savedPasswords;

        public IEnumerable<PasswordCard> FindByName(string searchParam) => _savedPasswords.Where(s => s.Name.ToLower()
                                                                                           .Contains(searchParam.ToLower()));

        private bool FindById(Guid id)
        {
            return _savedPasswords.Any(s => s.Id == id);
        }
    }
}
