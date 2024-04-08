namespace BCSystem.Web.Models
{
    public class Endereco
    {
        public string CEP { get; set; }

        public string Logradouro { get; set; }

        public int Numero { get; set; } 

        public string Complemento { get; set;}

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public UF UF { get; set; }
        
    }
}
