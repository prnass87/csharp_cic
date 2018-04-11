namespace Modelos
{
    public abstract class Pessoa
    {
        public int PessoaID { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        // O entity identifica a o endereço pelo EnderecoID
        public int EnderecoID { get; set; }
        public Endereco _Endereco { get; set; }

        /*
         Cliente._Endereco.Rua = Lazyloading

        Facilita o carregamento na situação acima.
         */
    }
}
