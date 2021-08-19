using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChoice.Dominio.Entidades
{
    public class ProdutoIngrediente
    {
        public int ProdutoId { get; set; }
        public int IngredienteId { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual Ingrediente Ingrediente { get; set; }
    }
}
