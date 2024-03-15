namespace ApiCatalago.Models;

using ApiCatalogo.Validations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

[Table("Produtos")]
public class Produto : IValidatableObject
{
    //Classes que  possuem somente propiedades são chamadas de anemicas

    //Chave Primaria para o EF
    [Key]
    public int ProdutoId { get; set; }
    //
    [Required(ErrorMessage = "O nome do produto é obrigatorio.")]
    [StringLength(80, ErrorMessage = "O nome dever ter no maximo {1} e no minimo {2} caracteres",
        MinimumLength = 5)]
    [PrimeiraLetraMaiuscula]
    public string? Nome { get; set; }

    [Required]
    [StringLength(300)]
    public string? Descricao { get; set; }

    [Required]
    [Range(1, 10000, ErrorMessage = "O preço deve estar entre {1} e {2}")]
    [Column(TypeName = "Decimal (10,2)")]

    public decimal Preco { get; set; }

    [Required]
    [StringLength(300, MinimumLength = 10)]
    public string? ImagemUrl { get; set; }

    public float Estoque { get; set; }

    public DateTime DataCadastro { get; set; }


    // cada produto possui uma categoria e uma categoria ID
    public int CategoriaId { get; set; }

    [JsonIgnore]
    public Categoria? Categoria { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!string.IsNullOrEmpty(this.Nome))
        {
            var primeiraLetra = this.Nome[0].ToString();
            if (primeiraLetra != primeiraLetra.ToUpper())
            {
                yield return new
                    ValidationResult("A primeira letra deve ser maiuscula", new[] { nameof(this.Nome) });

            }
        }

        if (this.Estoque <= 0)
        {
            yield return new
                ValidationResult("Estoque deve ser maior que 0", new[] { nameof(this.Estoque) });
        }
    }
}