using LibraryApp.Dto;
using LibraryApp.Models;

namespace LibraryApp.Tests.TestsHelpers.Builders
{
    public class UserBuilder
    {
        public string Id;
        public string Username;
        public bool isAdmin;
        public string phoneNumber;
        public string email;
        public string password;
        public string gender;
        public string name;
        public string surname;
        public string patronymic;

        public UserBuilder() { }

        public UserBuilder WithId(string Id)
        {
            this.Id = Id;
            return this;
        }

        public UserBuilder WithUsername(string Username)
        {
            this.Username = Username;
            return this;
        }

        public UserBuilder WithIsAdmin(bool IsAdmin)
        {
            this.isAdmin = IsAdmin;
            return this;
        }

        public UserBuilder WithPhoneNumber(string PhoneNumber)
        {
            this.phoneNumber = PhoneNumber;
            return this;
        }

        public UserBuilder WithEmail(string Email)
        {
            this.email = Email;
            return this;
        }

        public UserBuilder WithPassword(string Password)
        {
            this.password = Password;
            return this;
        }

        public UserBuilder WithGender(string Gender)
        {
            this.gender = Gender;
            return this;
        }

        public UserBuilder WithName(string Name)
        {
            this.name = Name;
            return this;
        }

        public UserBuilder WithSurname(string Surname)
        {
            this.surname = Surname;
            return this;
        }

        public UserBuilder WithPatronymic(string Patronymic)
        {
            this.patronymic = Patronymic;
            return this;
        }

        public User build()
        {
            var review = new User
            {
                Id = Id,
                UserName = Username,
                IsAdmin = isAdmin,
                PhoneNumber = phoneNumber,
                Email = email,
                Password = password,
                Gender = gender,
                Name = name,
                Surname = surname,
                Patronymic = patronymic
            };
            return review;
        }

        public UserDto buildDto()
        {
            var review = new UserDto
            {
                Id = Id,
                Username = Username,
                IsAdmin = isAdmin,
                PhoneNumber = phoneNumber,
                Email = email,
                Password = password,
                Gender = gender,
                Name = name,
                Surname = surname,
                Patronymic = patronymic
            };
            return review;
        }
    }
}
