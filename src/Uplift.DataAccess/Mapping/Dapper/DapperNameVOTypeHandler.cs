using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Uplift.Models.ValueObjects;

namespace Uplift.DataAccess.Mapping
{
    public class DapperNameVOTypeHandler : SqlMapper.TypeHandler<Name>
    {
        public override void SetValue(IDbDataParameter parameter, Name value)
        {
            parameter.Value = value.ToString();
        }

        public override Name Parse(object value)
        {
            return new Name(name: (string)value);
        }
    }
}
