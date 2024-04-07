using APIBakeryCustomer.Services;
using APIBakeryCustomer.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIBakeryCustomer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly CustomerDataService _customerDataService;

        public ClientController(CustomerDataService customerDataService)
        {
            _customerDataService = customerDataService;
        }

        // Endpoint para obter todos os clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            var clients = await _customerDataService.GetClientsAsync();
            return Ok(clients);
        }

        // Endpoint para obter um cliente por ID
        [HttpGet("{id:length(24)}", Name = "GetClient")]
        public async Task<ActionResult<Client>> GetClient(string id)
        {
            var client = await _customerDataService.GetClientAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return client;
        }

        // Endpoint para criar um novo cliente
        [HttpPost]
        public async Task<ActionResult<Client>> CreateClient(Client client)
        {
            await _customerDataService.CreateClientAsync(client);
            return CreatedAtAction(nameof(GetClient), new { id = client.Id }, client);
        }

        // Endpoint para atualizar um cliente existente
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateClient(string id, Client clientIn)
        {
            var client = await _customerDataService.GetClientAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            await _customerDataService.UpdateClientAsync(id, clientIn);
            return NoContent();
        }

        // Endpoint para excluir um cliente existente
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteClient(string id)
        {
            var client = await _customerDataService.GetClientAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            await _customerDataService.DeleteClientAsync(id);
            return NoContent();
        }
    }
}
