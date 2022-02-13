using AutoMapper;
using DefectiveGoods.Core.Users;
using DefectiveGoods.Mvc.Models.Account;

namespace DefectiveGoods.Mvc.Mapping
{
    public class ViewModelToEntityProfile : Profile
    {
        public ViewModelToEntityProfile()
        {
            CreateMap<RegisterViewModel, User>();              
        }
    }
}
