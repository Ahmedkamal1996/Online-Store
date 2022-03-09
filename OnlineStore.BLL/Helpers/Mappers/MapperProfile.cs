using AutoMapper;
using OnlineStore.BLL.ViewModels.Category;
using OnlineStore.BLL.ViewModels.FeedBack;
using OnlineStore.BLL.ViewModels.Order;
using OnlineStore.BLL.ViewModels.OrderItem;
using OnlineStore.BLL.ViewModels.Product;
using OnlineStore.BLL.ViewModels.ProductImage;
using OnlineStore.DAL.Models.Categories;
using OnlineStore.DAL.Models.FeedBacks;
using OnlineStore.DAL.Models.OrderItems;
using OnlineStore.DAL.Models.Orders;
using OnlineStore.DAL.Models.Products;


namespace OnlineStore.BLL.Helpers.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName));

            //CreateMap<CreateCategoryViewModel, Category>(MemberList.None)
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CategoryName))
            //    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.CategoryDescription))
            //    .ReverseMap();

            CreateMap<CreateCategoryViewModel, Category>(MemberList.None);
            CreateMap<UpdateCategoryViewModel, Category>(MemberList.None).ReverseMap();
            CreateMap<GetCategoryViewModel, UpdateCategoryViewModel>(MemberList.None);
            CreateMap<GetCategoryViewModel, CreateCategoryViewModel>(MemberList.None).ReverseMap();
            CreateMap<Category, GetCategoryViewModel>(MemberList.None)
                .ForMember(dest => dest.IsMainCategory, opt => opt.MapFrom(src => !src.CategoryId.HasValue))
                .ReverseMap();
             

            CreateMap<CreateOrderViewModel, Order>(MemberList.None);
            CreateMap<UpdateOrderViewModel, Order>(MemberList.None).ReverseMap();
            CreateMap<GetOrderViewModel, UpdateOrderViewModel>(MemberList.None);
            CreateMap<Order, GetOrderViewModel>(MemberList.None);
             

            CreateMap<CreateOrderItemViewModel, OrderItem>(MemberList.None);
            CreateMap<UpdateOrderItemViewModel, OrderItem>(MemberList.None).ReverseMap();
            CreateMap<GetOrderItemViewModel, UpdateOrderViewModel>(MemberList.None);
            CreateMap<OrderItem, GetOrderViewModel>(MemberList.None);


            CreateMap<CreateProductViewModel, Product>(MemberList.None);
            CreateMap<UpdateProductViewModel, Product>(MemberList.None).ReverseMap();
            CreateMap<GetProductViewModel, UpdateProductViewModel>(MemberList.None);
            CreateMap<Product, GetProductViewModel>(MemberList.None);


            CreateMap<CreateFeedBackViewModel, FeedBack>(MemberList.None);
            CreateMap<UpdateFeedBackViewModel, FeedBack>(MemberList.None).ReverseMap();
            CreateMap<GetFeedBackViewModel, UpdateFeedBackViewModel>(MemberList.None);
            CreateMap<FeedBack, GetFeedBackViewModel>(MemberList.None);

            CreateMap<CreateProductImageViewModel, ProductImage>(MemberList.None);
            CreateMap<UpdateProductImageViewModel, ProductImage>(MemberList.None).ReverseMap();
            CreateMap<GetProductImageViewModel, UpdateProductImageViewModel>(MemberList.None);
            CreateMap<ProductImage, GetProductImageViewModel>(MemberList.None);

        }
    }
}