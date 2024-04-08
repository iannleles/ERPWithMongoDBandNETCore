using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ProdutoRepositorio
{
    private readonly IMongoCollection<Produto> _produtos;

    public ProdutoRepositorio(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _produtos = database.GetCollection<Produto>("produtos");
    }

    public async Task<List<Produto>> GetAllProdutos()
    {
        return await _produtos.Find(_ => true).ToListAsync();
    }

    public async Task<Produto> GetProduto(string id)
    {
        return await _produtos.Find(produto => produto.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateProduto(Produto produto)
    {
        await _produtos.InsertOneAsync(produto);
    }

    public async Task UpdateProduto(string id, Produto produto)
    {
        await _produtos.ReplaceOneAsync(p => p.Id == id, produto);
    }

    public async Task DeleteProduto(string id)
    {
        await _produtos.DeleteOneAsync(produto => produto.Id == id);
    }
}
