using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourChoice.Dominio.Entidades
{
    public class Produto : Entidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string NomeArquivo { get; set; }
        public virtual ICollection<ProdutoIngrediente> ProdutoIngrediente { get; set; }
        [NotMapped]
        public virtual ICollection<Ingrediente> IngredientesProdutos { get; set; }
        public override void Validate()
        {
            if (string.IsNullOrEmpty(Nome))
                AdicionarCritica("Nome do produto não foi informado");

            if (string.IsNullOrEmpty(Descricao))
                AdicionarCritica("Descrição não foi informado");
        }
    }
}
