using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FactorioServerManager.DataStore
{
    public class UriTypeHandler : SqlMapper.TypeHandler<Uri>
    {
        public override Uri Parse(object value)
        {
            return new Uri((string)value);
        }

        public override void SetValue(IDbDataParameter parameter, Uri value)
        {
            parameter.Value = value.ToString();
        }
    }
}
