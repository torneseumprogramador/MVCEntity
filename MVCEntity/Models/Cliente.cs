using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEntity.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }

        public void Salvar()
        {

            var db = new Database1();
            db.Clientes.Add(this);
            db.SaveChanges();
        }

        /// <summary>
        /// Busca com nome obrigatório
        /// </summary>
        /// <param name="nome">Nome por parte da string</param>
        /// <returns></returns>
        internal static List<Cliente> Todos(string nome)
        {
            return new Database1().Clientes.Where(c => c.Nome.Contains(nome)).ToList();
        }

        /// <summary>
        /// Busca de todos os elementos
        /// </summary>
        /// <returns></returns>
        internal static List<Cliente> Todos()
        {
            return Todos("");
        }

        /*internal static List<Cliente> TodosPorSql()
        {
            var db = new Database1();
            string nome = "Danilo";
            return db.Clientes.FromSqlRaw("select * from clientes where nome = {0}", nome).ToList();

            //var db = new Database1();
            //var result = (from c in db.Clientes.FromSqlRaw("select clientes.id, clientes.nome, pedidos.id from clientes where nome = {0}", nome)
            //select new
            //{
            //    c.Id,
            //    c.Nome
            //}).ToList();
            
        }*/
    }
}
