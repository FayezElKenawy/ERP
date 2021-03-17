using AutoMapper;
using Domain.Models;
using Domain.ViewModels;

namespace ERP.Profiels
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerReadViewModel>();
            
        }
    }
}
