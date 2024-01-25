
using ApiCatalago.Models;
using ApiCatalogo.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace ApiCatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ApiCatalogoContext _context;
        public CategoriaController(ApiCatalogoContext context)
        {
            _context = context;
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            try
            {

                return _context.Categorias.Include(p => p.Produtos).AsNoTracking().Take(10).ToList();

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> GetCategorias()
        {
            try
            {
                var categorias = _context.Categorias.AsNoTracking().ToList();
                if (categorias.Any())
                {
                    return categorias;
                }
                return NotFound("Categoria não encontrada");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema");
            }
        }

        [HttpGet("{id:int}, Name = Obter Categoria")]
        public ActionResult<Categoria> Get(int id)
        {
            try
            {
                var categoria = _context.Categorias.FirstOrDefault(categoria => categoria.CategoriaId == id);
                if (categoria == null)
                {
                    return NotFound("Categoria não encontrada");
                }
                return categoria;

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema");
            }
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            try
            {

                if (categoria == null)
                {
                    return BadRequest("Categoria Nula");
                }

                _context.Categorias.Add(categoria);
                _context.SaveChanges();
                return new CreatedAtRouteResult("Obter Categoria",
                    new { id = categoria.CategoriaId }, categoria);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema");
            }
        }

        [HttpPut("{id:int}")]

        public ActionResult Put(int id, Categoria categoria)
        {
            try
            {
                if (id != categoria.CategoriaId)
                {
                    return BadRequest("Id divergente do Objeto");
                }

                _context.Entry(categoria).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok();

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema");
            }

        }

        [HttpDelete("{id:int}")]

        public ActionResult Delete(int id)
        {

            try
            {
                var categoria = _context.Categorias.FirstOrDefault(categoria => categoria.CategoriaId == id);
                if (categoria is null)
                {
                    return NotFound("Categoria não encontrada");
                }
                _context.Categorias.Remove(categoria);
                _context.SaveChanges();

                return Ok(categoria);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema");
            }
        }
    }
}
