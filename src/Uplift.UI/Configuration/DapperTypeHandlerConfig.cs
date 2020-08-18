using Dapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uplift.DataAccess.Mapping;

namespace Uplift.UI.Configuration
{
    public static class DapperTypeHandlerConfig
    {
        public static void AddTypeHandlers(this IServiceCollection services)
        {
            SqlMapper.AddTypeHandler(new DapperNameVOTypeHandler()); // Name Value Object
        }
    }
}
