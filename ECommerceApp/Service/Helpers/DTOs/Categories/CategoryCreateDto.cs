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
            RuleFor(x => x.Name)
                   .NotNull().WithMessage("Name is required")
                   .NotEmpty().WithMessage("Name cannot be empty")
                   .MinimumLength(2).WithMessage("Name must be at least 2 characters")
                   .MaximumLength(50).WithMessage("Name must not exceed 50 characters");

            RuleFor(x => x.Description).MaximumLength(250);

        }
    }
}

