using YourChoice.Dominio.Contratos;
using YourChoice.Dominio.Entidades;
using YourChoice.Repositorio.Contexto;

namespace YourChoice.Repositorio.Repositorios
{
    public class PedidoRepositorio : BaseRepositorio<Pedido>, IPedidoRepositorio
    {
        public PedidoRepositorio(YourChoiceContexto yourChoiceContexto) : base(yourChoiceContexto)
        {
        }
    }
}
