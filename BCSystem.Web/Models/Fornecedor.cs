using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BCSystem.Web.Models
{
    public class Fornecedor
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        public string CEP { get; set; }

        public string Logradouro { get; set; }

        public string CPForCNPJ { get; set; }

        public string Nome {  get; set; }

        public string Telefone { get; set; }    

        public string Email { get; set; }       

        public Endereco Endereco { get; set; }
    }
}
