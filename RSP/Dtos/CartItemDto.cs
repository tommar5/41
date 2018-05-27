﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RSP.Models;

namespace RSP.Dtos
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Number { get; set; }


    }
}
