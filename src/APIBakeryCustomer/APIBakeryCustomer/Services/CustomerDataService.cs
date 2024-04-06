using APIBakeryCustomer.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace APIBakeryCustomer.Services
{
    public class CustomerDataService
    {
        private readonly IMongoCollection<Client> _clientCollection;

        public CustomerDataService(IOptions<CustomerDataSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _clientCollection = mongDatabase.GetCollection<Client>(settings.Value.CustomerBakeryCollectionName);
        }

        // Traz todos os clientes
        public async Task<List<Client>> GetClientsAsync() =>
            await _clientCollection.Find(_ => true).ToListAsync();

        // Traz um cliente pelo ID
        public async Task<Client?> GetClientAsync(string id) =>
            await _clientCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        // Cria um novo cliente
        public async Task CreateClientAsync(Client client) =>
            await _clientCollection.InsertOneAsync(client);

        // Atualiza um cliente existente pelo ID
        public async Task UpdateClientAsync(string id, Client clientIn) =>
            await _clientCollection.ReplaceOneAsync(x => x.Id == id, clientIn);

        // Deleta um cliente existente pelo ID
        public async Task DeleteClientAsync(string id) =>
            await _clientCollection.DeleteOneAsync(x => x.Id == id);
    }
}
