using DefectiveGoods.Core.Users;
using System.Linq;

namespace DefectiveGoods.EntityFrameworkCore.Repositories.Users
{
    public class UserRepository : EfRepositoryBase<DefectiveGoodsContext, User, long>, IUserRepository
    {
        public UserRepository(DefectiveGoodsContext context)
            : base(context)
        {
        }        

        public bool IsExist(string login, string password)
        {
            User user = Context.Users.FirstOrDefault(u => login == u.Login && password == u.Password);
            return user != null;
        }

        public bool IsExist(string login)
        {
            User user = Context.Users.FirstOrDefault(u => login == u.Login);
            return user != null;
        }
    }
}
