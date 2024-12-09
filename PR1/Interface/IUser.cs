using PR1.ActionClass.HelperClass.DTO;

namespace PR1.Interface
{
    public interface IUser
    {
        // Добавление нового пользователя
        public List<string> AddAccount(AccountDTO account);

        // Информация о всех пользователях
        public List<AccountDTO> GetUsers();

        // Информация о пользователе
        public List<AccountDTO> GetUser(string login);

        //Обнавление данных пользователя
        public List<string> UpdateUser(int id, AccountDTO user);

        //Удаление пользователя и всех привязанных к нему счетов
        public List<string> DeletUser(long id);
    }
}
