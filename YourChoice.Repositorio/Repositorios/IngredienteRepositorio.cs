using YourChoice.Dominio.Contratos;
using YourChoice.Dominio.Entidades;
using YourChoice.Repositorio.Contexto;

namespace YourChoice.Repositorio.Repositorios
{
    public class IngredienteRepositorio : BaseRepositorio<Ingrediente>, IIngredienteRepositorio
    {
        public IngredienteRepositorio(YourChoiceContexto yourChoiceContexto) : base(yourChoiceContexto)
        {
        }
    }
}
