using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEntity.Models
{
    public class Database1 : DbContext
    {
        /*public Database1(string strCnn)
        {
            _strCnn = strCnn;
        }
        */
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        //private string _strCnn;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));

            string strCnn = jAppSettings["ConnectionStrings"]["ConexaoPadrao"].ToString();
            //optionsBuilder.UseSqlServer(_strCnn);
            optionsBuilder.UseSqlServer(strCnn);
        }
    }
}
