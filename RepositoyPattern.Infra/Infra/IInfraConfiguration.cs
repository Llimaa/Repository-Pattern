using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoyPattern.Infra.Infra
{
    public interface IInfraConfiguration
    {
        string ConnectionString { get; }
        
    }
}
