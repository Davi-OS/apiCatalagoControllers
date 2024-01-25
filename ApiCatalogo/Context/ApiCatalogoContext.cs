using ApiCatalago.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Context
{
    public class ApiCatalogoContext : DbContext
    {
        public ApiCatalogoContext(DbContextOptions<ApiCatalogoContext> options) : base(options)
        {

        }

        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Produto>? Produtos { get; set; }
    }
}
