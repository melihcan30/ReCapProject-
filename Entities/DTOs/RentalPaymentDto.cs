﻿using Core.Entities.Concrete.Fake;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalPaymentDto
    {
        public Rental Rental { get; set; }
        public FakeCreditCardModel FakeCreditCardModel { get; set; }
    }
}
