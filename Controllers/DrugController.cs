using System.Threading.Tasks;
using DrugApp.Data;
using DrugApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrugApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugController : ControllerBase
    {
        private readonly DataContext _context;

        public DrugController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetItems()
        {
            var items = await _context.Items.ToListAsync();
            return Ok(items);
        }

        [HttpPost] // [HttpPost] , é fornecido ao roteamento para que ele possa escolher com base no método http da solicitação.
        public async Task<IActionResult> CreateItem(ItemData data)
        {
            if (ModelState.IsValid)
            {
                //[AddAsync] Começa a controlar a entidade especificada e quaisquer outras entidades acessíveis que ainda não estão sendo rastreadas
                await _context.Items.AddAsync(data);
                //[SaveChangesAsync] Salva todas as alterações feitas neste contexto no banco de dados
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetItem", new { data.Id }, data);
            }
            //[JsonResult] formata o objeto fornecido como JSON
            return new JsonResult("Algo deu errado!") { StatusCode = 500 };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, ItemData item)
        {
            if (id == item.Id)
                return BadRequest();

            var existItem = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
                return NotFound();

            existItem.Title = item.Title;
            existItem.Description = item.Description;
            existItem.Manufacturer = item.Manufacturer;
            existItem.Ownership = item.Ownership;
            existItem.Price = item.Price;
            existItem.Quantity = item.Quantity;

            //Implementar as mudanças no dataBase
            await _context.SaveChangesAsync();
            //Cria um NoContentResult objeto que produz uma Status204NoContent resposta vazia.
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var existItem = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);

            if(existItem == null)
                return NotFound();

            _context.Items.Remove(existItem);
            await _context.SaveChangesAsync();

            return Ok(existItem);
        }
    }
}