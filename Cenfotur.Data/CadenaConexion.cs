using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Data
{
    public class CadenaConexion
    {
        public string Cadena { get; set; }
        public CadenaConexion()
        {
            IConfigurationBuilder Builder = new ConfigurationBuilder();
            Builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = Builder.Build();
            Cadena = root.GetConnectionString("DefaultConnection");

        }
    }
}
