using LibraryApp.Tests.TestsHelpers.Builders;

namespace LibraryApp.Tests.TestsHelpers.ObjectMothers
{
    public class UserOM
    {
        public UserBuilder CreateUser()
        {
            return new UserBuilder()
                .WithId("1")
                .WithUsername("username")
                .WithIsAdmin(false)
                .WithPhoneNumber("88005553535")
                .WithEmail("email@email.com")
                .WithPassword("password")
                .WithGender("male")
                .WithName("name")
                .WithSurname("surname")
                .WithPatronymic("patronymic");
        }

        public List<UserBuilder> CreateRange()
        {
            return new List<UserBuilder>
            {
                new UserBuilder()
                .WithId("1")
                .WithUsername("username")
                .WithIsAdmin(false)
                .WithPhoneNumber("88005553535")
                .WithEmail("email@email.com")
                .WithPassword("password")
                .WithGender("male")
                .WithName("name")
                .WithSurname("surname")
                .WithPatronymic("patronymic"),
            new UserBuilder()
                .WithId("2")
                .WithUsername("username2")
                .WithIsAdmin(false)
                .WithPhoneNumber("88005554545")
                .WithEmail("email2@email.com")
                .WithPassword("password2")
                .WithGender("male")
                .WithName("name2")
                .WithSurname("surname2")
                .WithPatronymic("patronymic2")
            };
        }
    }
}
