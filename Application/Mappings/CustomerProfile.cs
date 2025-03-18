using AutoMapper;
using Commerce;
using Commerce.Infrastructure.DAO;

namespace Application.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile() {
            CreateMap<CustomerModel, Customer>();
            CreateMap<Customer, CustomerModel>();
        }
    }
}
