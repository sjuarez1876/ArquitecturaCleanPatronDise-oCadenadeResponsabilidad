﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCleanArchitecture.Core.Entities
{
    public class CarCompany
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
