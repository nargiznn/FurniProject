using System;
using FluentValidation;

namespace Service.Helpers.DTOs.Brand
{
	public class BrandEditDto
	{
        public string? Name { get; set; }
    }
    public class BrandEditDtoValidator : AbstractValidator<BrandEditDto>
    {
        public BrandEditDtoValidator()
        {
            RuleFor(x => x.Name)
                        .MinimumLength(2).WithMessage("Name must be at least 2 characters")
                        .MaximumLength(50).WithMessage("Name must not exceed 50 characters")
                        .When(x => !string.IsNullOrWhiteSpace(x.Name));
        }
    }
}

