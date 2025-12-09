using System;
using FluentValidation;

namespace Service.Helpers.DTOs.Categories
{
	public class CategoryCreateDto
	{
		public string Name { get; set; }
        public string? Description { get; set; }
    }
	public class CategoryCreateDtoValidator : AbstractValidator<CategoryCreateDto>
	{
		public CategoryCreateDtoValidator()
		{
			RuleFor(x => x.Name).NotNull().WithMessage("Name is required");
            RuleFor(x => x.Description).MaximumLength(250);

        }
    }
}

