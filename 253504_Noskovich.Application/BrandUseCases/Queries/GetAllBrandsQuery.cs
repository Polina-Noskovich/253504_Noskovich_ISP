﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Noskovich.Application.BrandUseCases.Queries
{
    public record GetAllBrandsQuery : IRequest<List<Brand>>
    {
    }
}
