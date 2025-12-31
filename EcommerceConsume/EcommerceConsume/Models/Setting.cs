using System;
using EcommerceConsume.Common;

namespace EcommerceConsume.Models
{
	public class Setting:BaseEntity
	{
        public string Key { get; set; }
        public string Value { get; set; }
    }
}

