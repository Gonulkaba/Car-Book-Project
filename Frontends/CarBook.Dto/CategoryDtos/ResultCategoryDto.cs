﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CategoryDtos
{
	public class ResultCategoryDto
	{
		public int CategoryId { get; set; }
		public string Name { get; set; }
        public int BlogCount { get; set; }
    }
}
