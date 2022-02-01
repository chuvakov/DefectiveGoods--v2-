using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefectiveGoods.Core.Users
{
    public class UserManager : IUserManager
    {
        private readonly DefectiveGoodsContext _context;

        public UserManager(DefectiveGoodsContext context)
        {
            _context = context;
        }

        public bool IsExist(string login, string password)
        {
            User user = _context.Users.FirstOrDefault(u => login == u.Login && password == u.Password);
            return user != null;
        }
    }
}
