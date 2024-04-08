using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Produto
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Nome { get; set; }
    public int CodigoProduto { get; set; }
    public decimal Preco { get; set; }
    public decimal PrecoVenda { get; set; }
    public string Categoria { get; set; }
    public string Marca { get; set; }

}
