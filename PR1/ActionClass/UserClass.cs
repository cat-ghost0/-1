using PR1.ActionClass.HelperClass.DTO;
using PR1.Interface;
using System.Collections.Generic;
using System.Data;
using PR1.ActionClass.Account;
using PR1.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace PR1.ActionClass
{
    public class UserClass : IUser
    {
        private readonly InformationTechnologyCircleContext _context;
        public UserClass(InformationTechnologyCircleContext context) => _context = context;


        public List<string> AddAccount(AccountDTO account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account), "Учетная запись не может быть нулевой.");
            }

            if (_context.Users.Any(x => x.Email == account.Email))
            {

                return new List<string> { "Пользователь с таким email уже существует" };
            }

            // Создание новой сущности для добавления в базу данных
            var entity = new User
            {
                Name = account.Name, // Имя
                Surname = account.Surname, // Фамилия
                Fname = account.Fname, // Отчество
                Sex = account.Sex,
                Phone = account.Phone,
                Email = account.Email,
                Password = account.Password,
            };

            // Добавление новой сущности в контекст
            _context.Users.Add(entity);
            _context.SaveChanges();

            Results.Created();
            return new List<string> { "Пользователь успешно добавлен" };
        }


        // Информация о всех пользователях
        public List<AccountDTO> GetUsers()
        {
            try
            {

                var data = _context.Users.Select(
                    x => new AccountDTO()
                    {
                        Id = x.IdUser,
                        Name = x.Name, // Имя
                        Surname = x.Surname, // Фамилия
                        Fname = x.Fname, // Отчество
                        Sex = x.Sex,
                        Phone = x.Phone,
                        Email = x.Email,
                        Password = x.Password,
                        Role = x.Role.Name,
                    }
                    ).ToList();
                return (List<AccountDTO>)data;
            }
            catch
            {
                Results.BadRequest();
                throw;
            }
        }

        // Информация о пользователе
        public List<AccountDTO> GetUser(string login)
        {
            try
            {
                var data = string.IsNullOrEmpty(login)
                    ? _context.Users
                    : _context.Users.Where(x => x.Email.Contains(login));

                var result = data.Select(x => new AccountDTO()
                {
                    Id = x.IdUser,
                    Surname = x.Surname,
                    Fname = x.Fname,
                    Name = x.Name,
                    Sex = x.Sex,
                    Phone = x.Phone,
                    Email = x.Email,
                    Password = x.Password,
                    Role = x.Role.Name,
                }).ToList();

                Results.Ok();
                return result;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return new List<AccountDTO>();
            }
        }

        //Обнавление данных пользователя
        public List<string> UpdateUser(int id, AccountDTO user)
        {

            try
            {
                var userData = _context.Users.FirstOrDefault(x => x.IdUser == id);

                if (userData == null)
                {
                    return ["Пользователь не найден"];
                }


                userData.Phone = user.Phone;
                userData.Email = user.Email;

                _context.SaveChanges();

                return ["Данные пользователя успешно обновлены!"];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ["Ошибка при обновлении данных пользователя"];
            }
        }



        //Удаление пользователя и всех привязанных к нему счетов
        public List<string> DeletUser(long id)
        {
            try
            {
                var existingUser = _context.Users.FirstOrDefault(u => u.IdUser == id);
                if (existingUser == null)
                {
                    return new List<string> { "Пользователь не найден" };
                }

                _context.Users.Remove(existingUser);
                _context.SaveChanges();

                return new List<string> { "Пользователь успешно удален" };
            }
            catch (Exception ex)
            {
                return new List<string> { "Ошибка в выполнении запроса" + ex.Message };
            }
        }
    }
}
