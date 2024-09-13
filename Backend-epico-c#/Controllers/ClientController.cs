using Backend_epico_c_.DTOS;
using Backend_epico_c_.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_epico_c_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private ApiContext _context;

        public ClientController(ApiContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IEnumerable<CLientDTO>> Get()
        {
            return await _context.Clients
                        .Where(client => client.Active)
                            .Select(client => new CLientDTO
                            {
                                Id = client.Id,
                                Name = client.Name,
                                LastName = client.LastName,
                                Email = client.Email,
                                Phone = client.Phone,
                                Address = client.Address
                            })
                                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CLientDTO>> GetById(int id)
        {
            var client = await _context.Clients.Where(c=>c.Id==id && c.Active).FirstOrDefaultAsync();


            if (client == null)
            {
                return NotFound();
            }

            var clientDTO = new CLientDTO
            {
                Id = client.Id,
                Name = client.Name,
                LastName = client.LastName,
                Email = client.Email,
                Phone = client.Phone,
                Address = client.Address
            };

            return clientDTO;

        }

        [HttpPost]
        public async Task<ActionResult<InsertClientDTO>> Post(InsertClientDTO clientDTO)
        {
            var client = new Client
            {
                Name = clientDTO.Name,
                LastName = clientDTO.LastName,
                Email = clientDTO.Email,
                Phone = clientDTO.Phone,
                Address = clientDTO.Address,
                Active=true
            };

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = client.Id }, clientDTO);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<InsertClientDTO>> Put(int id, InsertClientDTO clientDTO)
        {
            var clientSearch = await _context.Clients.FindAsync(id);


            if (clientSearch == null)
            {
                return NotFound();
            }


            var client = new Client
            {
                Id = id,
                Name = clientDTO.Name,
                LastName = clientDTO.LastName,
                Email = clientDTO.Email,
                Phone = clientDTO.Phone,
                Address = clientDTO.Address,
                Active = true
            };
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPut("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

          //delete logico por el campo  Active
          client.Active = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
