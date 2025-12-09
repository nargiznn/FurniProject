using System;
using System.Diagnostics.Metrics;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Service.Helpers.DTOs.Account;
using Service.Helpers.DTOs.Categories;

namespace Service.Helpers.Mappings
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
            #region Categories
            CreateMap<Category, CategoryDto>()
                 .ForMember(x => x.Date, opt => opt.MapFrom(src => src.CreatedDate.ToString("dd.MM.yyyy")));

            CreateMap<CategoryCreateDto, Category>();

            CreateMap<CategoryEditDto, Category>()
                .ForAllMembers(opts =>
                {
                    opts.AllowNull();
                    opts.Condition((src, dest, srcMember) =>
                        srcMember != null && !(srcMember is string str && string.IsNullOrWhiteSpace(str))
                    );
                });

            #endregion

            #region Account
            CreateMap<SignUpDto, AppUser>();
            CreateMap<AppUser, UserDto>();
            CreateMap<IdentityRole, RoleDto>();
            #endregion
        }
    }
}

