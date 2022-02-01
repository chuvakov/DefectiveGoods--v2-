using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefectiveGoods.Core.Users
{
    public interface IUserManager
    {
        bool IsExist(string login, string password);
    }
}
