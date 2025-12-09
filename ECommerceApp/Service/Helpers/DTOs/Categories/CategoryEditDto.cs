using System;
using FluentValidation;

namespace Service.Helpers.DTOs.Categories
{
	public class CategoryEditDto
	{
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
    public class CategoryEditDtoValidator : AbstractValidator<CategoryEditDto>
    {
        public CategoryEditDtoValidator()
        {
            RuleFor(x => x.Name)
                .MinimumLength(2).WithMessage("Name must be at least 2 characters")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters")
                .When(x => !string.IsNullOrWhiteSpace(x.Name));

            RuleFor(x => x.Description)
                .MaximumLength(250).WithMessage("Description must not exceed 250 characters")
                .When(x => !string.IsNullOrWhiteSpace(x.Description));
        }
    }

}

