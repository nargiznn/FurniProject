using System;
using System.ComponentModel.DataAnnotations;

namespace EcommerceConsume.Areas.Admin.ViewModels
{
	public class CategoryCreateVM
	{
        [Required]
        public string Name { get; set; }
    }
}

