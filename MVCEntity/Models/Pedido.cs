using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEntity.Models
{
    [Table("Pedidos")]
    public class Pedido
    {
        public int Id { get; set; }
        public double ValotTotal { get; set; }
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
