using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DefectiveGoods.Mvc.Models.Account
{
    public class RegisterViewModel
    {
        public int BranchId { get; set; }        

        [Required(ErrorMessage ="Поле является обязательным")]
        [MaxLength(32)]
        public string Login { get; set; }

        [Required(ErrorMessage ="Поле является обязательным")]
        [MaxLength(128)]
        public string Password { get; set; }

        [Required(ErrorMessage ="Поле является обязательным")]
        [MaxLength(128)]
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        public string PasswordRepeat { get; set; }
    }
}
