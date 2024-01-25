using ApiCatalago.Models;
using ApiCatalogo.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ApiCatalogoContext _context;
        public ProdutosController(ApiCatalogoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> GetProduto()
        {
            try
            {
                var produtos = _context.Produtos.AsNoTracking().ToList();
                if (produtos.Count == 0)
                {
                    return NotFound("Produtos não encontrados");
                }
                return produtos;

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema");
            }
        }

        [HttpGet("{id:int}, Name = Obter Produto")]
        public ActionResult<Produto> Get(int id)
        {
            try
            {
                var produto = _context.Produtos.Where(produto => produto.ProdutoId == id).FirstOrDefault();
                if (produto == null)
                {
                    return NotFound("Produtos não encontrados");
                }
                return produto;

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema");
            }

        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            try
            {
                if (produto == null)
                {
                    return BadRequest();
                }
                _context.Produtos.Add(produto);
                _context.SaveChanges();

                return new CreatedAtRouteResult("Obter Produto", new
                { id = produto.ProdutoId }, produto);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema");
            }
        }

        [HttpPut("{id:int}")]

        public ActionResult Put(int id, Produto produto)
        {
            try
            {
                if (id != produto.ProdutoId)
                {
                    return BadRequest();
                }

                _context.Entry(produto).State = EntityState.Modified;
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
                var produto = _context.Produtos.FirstOrDefault(produto => produto.ProdutoId == id);
                if (produto == null)
                {
                    return NotFound("Produto não encontrado");
                }
                _context.Produtos.Remove(produto);
                _context.SaveChanges();
                return Ok(produto);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema");
            }
        }
    }
}
