using BCSystem.Web.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

public class FornecedorRepositorio
{
    private readonly IMongoCollection<Fornecedor> _fornecedores;
    private readonly IMongoCollection<Endereco> _enderecos;
    private readonly IMongoCollection<UF> _UFs;

    public FornecedorRepositorio(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _fornecedores = database.GetCollection<Fornecedor>("Fornecedores");
        _enderecos = database.GetCollection<Endereco>("Enderecos");
        _UFs = database.GetCollection<UF>("UFs");
    }

    public async Task<List<Fornecedor>> GetAllFornecedors()
    {
        return await _fornecedores.Find(_ => true).ToListAsync();
    }

    public async Task<Fornecedor> GetFornecedor(Guid id)
    {
        return await _fornecedores.Find(fornecedor => fornecedor.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateFornecedor(Fornecedor fornecedor)
    {
        if (fornecedor.Endereco != null)
        {
            await _enderecos.InsertOneAsync(fornecedor.Endereco);

            if (fornecedor.Endereco.UF != null)
            {
                await _UFs.InsertOneAsync(fornecedor.Endereco.UF);
            }
        }       

        await _fornecedores.InsertOneAsync(fornecedor);
    }


    public async Task UpdateFornecedor(Guid id, Fornecedor Fornecedor)
    {
        await _fornecedores.ReplaceOneAsync(p => p.Id == id, Fornecedor);
    }

    public async Task DeleteFornecedor(Guid id)
    {
        await _fornecedores.DeleteOneAsync(fornecedor => fornecedor.Id == id);
    }
}
