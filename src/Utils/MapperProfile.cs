using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SDA_Backend_Project.src.Entity;
using static SDA_Backend_Project.src.DTO.CartDTO;
using static SDA_Backend_Project.src.DTO.CategoryDTO;
using static SDA_Backend_Project.src.DTO.CouponDTO;
using static SDA_Backend_Project.src.DTO.OrderDTO;
using static SDA_Backend_Project.src.DTO.PaymentDTO;
using static SDA_Backend_Project.src.DTO.ProductDTO;
using static SDA_Backend_Project.src.DTO.ReviewDTO;
using static SDA_Backend_Project.src.DTO.SubCategoryDTO;
using static SDA_Backend_Project.src.DTO.UserDTO;

namespace SDA_Backend_Project.src.Utils
{
    public class MapperProfile : Profile
    {
         // user
        public MapperProfile()
        {
            // User mappings
            CreateMap<Entity.User, UserReadDto>();
            CreateMap<UserCreateDto, Entity.User>();
            CreateMap<UserUpdateDto, Entity.User>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            // Product Mapping
            CreateMap<Entity.Product, GetProductDto>();
            CreateMap<CreateProductDto, Entity.Product>();
            CreateMap<UpdateProductInfoDto, Entity.Product>()
                // CreateMap<UpdateProdouctDescDto, Product>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            // Category mappings
            CreateMap<Entity.Category, CategoryReadDto>();
            CreateMap<CategoryCreateDto, Entity.Category>();
            CreateMap<CategoryUpdateDto, Entity.Category>()
                .ForAllMembers(options =>
                    options.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            // Subcategory mappings
            CreateMap<SubCategory, SubCategoryReadDto>();
            CreateMap<SubCategoryCreateDto, SubCategory>();
            CreateMap<SubCategoryUpdateDto, SubCategory>()
                .ForAllMembers(options =>
                    options.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            // Payment mappings
            CreateMap<Payment, PaymentReadDto>();
            CreateMap<PaymentCreateDto, Payment>();
            CreateMap<PaymentUpdateDto, Payment>()
                .ForAllMembers(options =>
                    options.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            // Order mappings
            CreateMap<Order, OrderReadDTO>();
            CreateMap<OrderCreateDTO, Order>();
            CreateMap<OrderReadDTO, Order>();
            CreateMap<OrderUpdateDTO, Order>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            // Cart mappings
            CreateMap<Cart, CartReadDto>();
            CreateMap<CartCreateDto, Cart>();
            CreateMap<CartUpdateDto, Cart>()
                .ForAllMembers(options =>
                    options.Condition((src, dest, srcProperty) => srcProperty != null)
                );
            CreateMap<CartDetailsDto, CartDetails>()
                .ForAllMembers(options =>
                    options.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            //Review mappings
            CreateMap<Review, ReadReviewDto>();
            CreateMap<CreateReviewDto, Review>();
            CreateMap<UpdateReviewDto, Review>()
            .ForAllMembers(options =>
                options.Condition((src, dest, srcProperty) => srcProperty != null)
            );

            //Coupon mappings
            CreateMap<Coupon, CouponReadDto>();
            CreateMap<CouponCreateDto, Coupon>();
            CreateMap<CouponUpdateDto, Coupon>()
            .ForAllMembers(options =>
                options.Condition((src, dest, srcProperty) => srcProperty != null)
            );

        }
    }
}
