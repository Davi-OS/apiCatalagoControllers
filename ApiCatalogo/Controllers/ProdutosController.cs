using ApiCatalago.Models;
using ApiCatalogo.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        public async Task<ActionResult<IEnumerable<Produto>>> GetProduto()
        {
            try
            {
                return await _context.Produtos.AsNoTracking().ToListAsync();
               
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema");
            }
        }
        // restrição de rota onde o valor de id tem que ser maior que 0
        [HttpGet("{id:int:min(1)}", Name ="ObterProduto")]
        public async Task<ActionResult<Produto>> Get(int id, [BindRequired] string nome)
        {
            try
            {
                var nomeProduto = nome;
                var produto = await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(produto => produto.ProdutoId == id);
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

                return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);

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
