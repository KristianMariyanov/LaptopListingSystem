namespace LaptopListingSystem.Services.Data.Contracts
{
    using LaptopListingSystem.Data.Models;
    using LaptopListingSystem.Services.Common;

    public interface IUsersDataService : IService
    {
        User GetUserByEmail(string email);

        string GetUserIdByEmail(string email);
    }
}
