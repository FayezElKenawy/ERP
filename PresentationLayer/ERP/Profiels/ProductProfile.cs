using AutoMapper;
using Domain.Models;
using Domain.ViewModels;

namespace ERP.Profiels
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductReadViewModel>();
            CreateMap<ProductCreateVieewModel, Product>();
            CreateMap<ProductUpdateViewModel, Product>();
            CreateMap<ProductReadViewModel, ProductUpdateViewModel>();
            CreateMap<SalesInvoice, InvoiceListViewModel>();
            
        }
    }
}
