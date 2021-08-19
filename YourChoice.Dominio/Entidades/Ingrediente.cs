using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChoice.Dominio.Entidades
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Classificacao { get; set; }
        public virtual ICollection<ProdutoIngrediente> ProdutoIngrediente { get; set; }
    }
}
