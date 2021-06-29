using Microsoft.Extensions.Configuration;
using RepositoyPattern.Infra.Infra;

namespace RepositoyPattern.Infra
{
    public class Configuration : IInfraConfiguration
    {
        private readonly IConfiguration _configuration;

        public Configuration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

         public string ConnectionString =>_configuration.GetConnectionString("stringConnection");
    }
}
