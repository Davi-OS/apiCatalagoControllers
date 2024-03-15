using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace ApiCatalago.Models;
[Table("Categorias")]
public class Categoria
{
    //Classes que  possuem somente propiedades são chamadas de anemicas
    // Identificador da entidade para o EF. Sera a Chave Primaria
    [Key]
    public int CategoriaId { get; set; }
    //
    [Required]
    [StringLength(80, ErrorMessage = "O nome da categoria deve ter no maximo {1} e no minimo {2}",
        MinimumLength = 5)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(300, MinimumLength = 10)]
    public string? ImagemUrl { get; set; }


    //propiedade de navegação responsavel por unir as tabelas Categoria e Produtos no EF
    [JsonIgnore]
    public ICollection<Produto>? Produtos { get; set; }

    public Categoria()
    {
        // inicializando a propiedade Produtos ( semelhante ao que fazemos com List e Queues)
        Produtos = new Collection<Produto>();
    }

}