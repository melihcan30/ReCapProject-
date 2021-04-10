﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int Id { get; set; }
        public int ColorId { get; set; }
        public int BrandId { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public string Name { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public int ModelYear { get; set; }
        public string ModelName { get; set; }
        public int FindeksScore { get; set; }

        //CarImages

        public int ImageId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
