﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahalufAssignmentCore.DTOs.Orgnizations
{
    public class SearchOrgnizationDTO
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int?    CountryId { get; set; }
    }
}
