using System;
using FluentValidation;

namespace Service.Helpers.DTOs.Brand
{
	public class BrandCreateDto
	{
        public string Name { get; set; }
    }
    public class BrandCreateDtoValidator : AbstractValidator<BrandCreateDto>
    {
        public BrandCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required")
                   .NotEmpty().WithMessage("Name cannot be empty")
                   .MinimumLength(2).WithMessage("Name must be at least 2 characters")
                   .MaximumLength(50).WithMessage("Name must not exceed 50 characters");
        }
    }
}

