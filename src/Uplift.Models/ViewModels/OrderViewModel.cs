﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Uplift.Models.ViewModels
{
    public class OrderViewModel
    {
        public OrderHeader OrderHeader { get; set; }
        public OrderDetails OrderDetails { get; set; }
    }
}
