namespace LaptopListingSystem.Services.Data
{
    using System.Linq;

    using LaptopListingSystem.Data.Models;
    using LaptopListingSystem.Data.Repositories.Contracts;
    using LaptopListingSystem.Services.Data.Contracts;
    public class UsersDataService : IUsersDataService
    {
        private readonly IDeletableEntityRepository<User> users;

        public UsersDataService(IDeletableEntityRepository<User> users)
        {
            this.users = users;
        }

        public User GetUserByEmail(string email) => 
            this.users.All().FirstOrDefault(u => u.Email == email);

        public string GetUserIdByEmail(string email) =>
            this.users.All().Where(u => u.Email == email).Select(u => u.Id).FirstOrDefault();
    }
}
