using YourChoice.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace YourChoice.Dominio.Contratos
{
    public interface IProdutoRepositorio : IBaseRepositorio<Produto>
    {
        void AdicionarProduto(Produto produto);
        void AtualizaProduto(Produto produto);
    }
}
