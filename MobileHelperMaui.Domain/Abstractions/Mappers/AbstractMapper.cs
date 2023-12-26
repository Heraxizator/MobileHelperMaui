using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelperMaui.Domain.Abstractions.Mappers
{
    public static class AbstractMapper<T, Q>
    {
        // From the T type to the Q type Configuration
        private static readonly MapperConfiguration configA = new(cfg => cfg.CreateMap<T, Q>());

        // From the T type to the Q type Mapper
        public static readonly Mapper MapperA = new(configA);

        // From the Q type to the T type Configuration
        private static readonly MapperConfiguration configB = new(cfg => cfg.CreateMap<Q, T>());

        // From the Q type to the T type Mapper
        public static readonly Mapper MapperB = new(configB);
    }
}
