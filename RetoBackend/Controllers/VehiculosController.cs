using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RetoBackend.Data;
using RetoBackend.Modelos;


namespace RetoBackend.Controllers
{
    //[Route("api/[controller]")]
    [Route("api")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly RetoBackendContext _context;

        public VehiculosController(RetoBackendContext context)
        {
            _context = context;
        }

        // GET: api/Vehiculos
        [HttpGet("vehiculos")]
        public async Task<ActionResult<IEnumerable<Vehiculo>>> GetVehiculo()
        {
          if (_context.Vehiculo == null)
          {
              return NotFound();
          }
            return await _context.Vehiculo.ToListAsync();
        }

        // GET: api/Pedidos
        [HttpGet("pedidos")]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedido()
        {
            if (_context.Pedido == null)
            {
                return NotFound();
            }
            return await _context.Pedido.ToListAsync();
        }

        // GET: api/Vehiculos/5/ubicacion
        [HttpGet("vehiculos/{id}/ubicacion")]
        public async Task<ActionResult<string>> GetUbicacionVehiculo(int id)
        {
          if (_context.Vehiculo == null)
          {
              return NotFound();
          }
            var vehiculo = await _context.Vehiculo.FindAsync(id);

            if (vehiculo == null)
            {
                return NotFound();
            }

            return vehiculo.Ubicacion;
        }

        // GET: api/Vehiculos/5
        [HttpGet("vehiculos/{id}")]
        public async Task<ActionResult<Vehiculo>> GetVehiculo(int id)
        {
            if (_context.Vehiculo == null)
            {
                return NotFound();
            }
            var vehiculo = await _context.Vehiculo.FindAsync(id);

            if (vehiculo == null)
            {
                return NotFound();
            }

            return vehiculo;
        }

        // GET: api/Pedidos/5
        [HttpGet("pedidos/{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            if (_context.Pedido == null)
            {
                return NotFound();
            }
            var pedido = await _context.Pedido.FindAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }

        // PUT: api/Vehiculos/5/ubicacion
        [HttpPut("vehiculos/{id}/ubicacion")]
        public async Task<String> PutUbicacionVehiculo(int id, Vehiculo vehiculo)
        {
            if (id != vehiculo.Id)
            {
                return "Bad Request";
            }

            _context.Entry(vehiculo).State = EntityState.Modified;

            if(!vehiculo.Historial.Contains(vehiculo.Ubicacion))
            {
                vehiculo.Historial += " ; " + vehiculo.Ubicacion;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculoExists(id))
                {
                    return "Object doesn't exist";
                }
                else
                {
                    throw;
                }
            }

            return "Ubicacion: " + vehiculo.Ubicacion + "\nHistorial " + vehiculo.Historial;
        }

        // PUT: api/Vehiculos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("vehiculos/{id}")]
        public async Task<IActionResult> PutVehiculo(int id, Vehiculo vehiculo)
        {
            if (id != vehiculo.Id)
            {
                return BadRequest();
            }

            _context.Entry(vehiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            return NoContent();
        }

        // PUT: api/Pedidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("pedidos/{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return BadRequest();
            }

            _context.Entry(pedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vehiculos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("vehiculos")]
        public async Task<ActionResult<Vehiculo>> PostVehiculo(Vehiculo vehiculo)
        {
          if (_context.Vehiculo == null)
          {
              return Problem("Entity set 'RetoBackendContext.Vehiculo'  is null.");
          }
            _context.Vehiculo.Add(vehiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehiculo", new { id = vehiculo.Id }, vehiculo);
        }

        // POST: api/Pedidos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("pedidos")]
        public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido)
        {
            if (_context.Pedido == null)
            {
                return Problem("Entity set 'RetoBackendContext.Vehiculo'  is null.");
            }
            _context.Pedido.Add(pedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedido", new { id = pedido.Id }, pedido);
        }

        // POST: api/Vehiculos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("vehiculos/{id}")]
        public async Task<ActionResult<Vehiculo>> PostPedidoVehiculo(int id, Pedido pedido)
        {
            if (_context.Vehiculo == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculo.FindAsync(id);

            if (vehiculo == null)
            {
                return NotFound();
            }

            if (_context.Pedido == null)
            {
                return Problem("Entity set 'RetoBackendContext.Vehiculo'  is null.");
            }

            _context.Pedido.Add(pedido);
            await _context.SaveChangesAsync();
            vehiculo.ID_Pedido = pedido.Id;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVehiculo", new { id = vehiculo.Id }, vehiculo);
        }

        // DELETE: api/Vehiculos/5/borrarPedido
        [HttpDelete("vehiculos/{id}/borrarPedido")]
        public async Task<IActionResult> DeletePedidoVehiculo(int id)
        {
            if (_context.Vehiculo == null)
            {
                return NotFound();
            }
            var vehiculo = await _context.Vehiculo.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            vehiculo.ID_Pedido = null;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Vehiculos/5
        [HttpDelete("vehiculos/{id}")]
        public async Task<IActionResult> DeleteVehiculo(int id)
        {
            if (_context.Vehiculo == null)
            {
                return NotFound();
            }
            var vehiculo = await _context.Vehiculo.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            _context.Vehiculo.Remove(vehiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Pedidos/5
        [HttpDelete("pedidos/{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            if (_context.Pedido == null)
            {
                return NotFound();
            }
            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehiculoExists(int id)
        {
            return (_context.Vehiculo?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private bool PedidoExists(int id)
        {
            return (_context.Pedido?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
