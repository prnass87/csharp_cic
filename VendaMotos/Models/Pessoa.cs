using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Pessoa
    {
        [Key]
        public int PessoaID { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        //Informações: ENDERECO
        public int EnderecoID { get; set; }
        public virtual Endereco _Endereco { get; set; }

    }
}
