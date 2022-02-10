using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DefectiveGoods.Mvc.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Данное поле является обязательным")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Данное поле является обязательным")]
        public string Password { get; set; }
    }
}
