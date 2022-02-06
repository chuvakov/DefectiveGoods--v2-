using DefectiveGoods.Core.Infrastructure.Repositories;

namespace DefectiveGoods.Core.Users
{
    public interface IUserRepository : IRepository<User, long>
    {
        bool IsExist(string login, string password);
    }
}
