using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using YourChoice.Dominio.Contratos;
using YourChoice.Dominio.Entidades;
using YourChoice.Repositorio.Contexto;

namespace YourChoice.Repositorio.Repositorios
{
    public class ProdutoRepositorio : BaseRepositorio<Produto>, IProdutoRepositorio
    {
        protected readonly YourChoiceContexto YourChoiceContexto;
        public ProdutoRepositorio(YourChoiceContexto yourChoiceContexto) : base(yourChoiceContexto)
        {
            YourChoiceContexto = yourChoiceContexto;
        }

        public void AdicionarProduto(Produto produto)
        {
            YourChoiceContexto.Produtos.Add(produto);
            YourChoiceContexto.SaveChanges();
            AdicionaProdutoIngrediente(produto);
        }

        private void AdicionaProdutoIngrediente(Produto produto)
        {
            #region Percorrendo os Ingrediente

            if (produto.IngredientesProdutos != null)
            {
                foreach (var ingrediente in produto.IngredientesProdutos)
                {
                    #region ProdutoIngrediente

                    ProdutoIngrediente produtoIngrediente = new ProdutoIngrediente();
                    produtoIngrediente.ProdutoId = produto.Id;
                    produtoIngrediente.IngredienteId = ingrediente.Id;

                    YourChoiceContexto.ProdutoIngredientes.Add(produtoIngrediente);
                    YourChoiceContexto.SaveChanges();
                    #endregion
                }
            }

            #endregion
        }

        public void AtualizaProduto(Produto produto)
        {
            YourChoiceContexto.Produtos.Update(produto);

            if (produto.IngredientesProdutos != null)
            {
                var produtoIngrediente = YourChoiceContexto.ProdutoIngredientes.AsNoTracking().Where(w => w.ProdutoId == produto.Id).ToList();
                YourChoiceContexto.ProdutoIngredientes.RemoveRange(produtoIngrediente);
            }

            YourChoiceContexto.SaveChanges();
            AdicionaProdutoIngrediente(produto);
        }
    }
}
