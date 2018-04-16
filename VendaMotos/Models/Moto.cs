using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Moto
    {
        [Key]
        public int MotoID { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cilindrada { get; set; }
        public string Ano { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public double Valor { get; set; }
        public string Status { get; set; }
    }
}
