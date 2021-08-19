using YourChoice.Dominio.Contratos;
using YourChoice.Dominio.Entidades;
using YourChoice.Repositorio.Contexto;

namespace YourChoice.Repositorio.Repositorios
{
    public class ProdutoIngredienteRepositorio : BaseRepositorio<ProdutoIngrediente>, IProdutoIngredienteRepositorio
    {
        public ProdutoIngredienteRepositorio(YourChoiceContexto yourChoiceContexto) : base(yourChoiceContexto)
        {
        }
    }
}
