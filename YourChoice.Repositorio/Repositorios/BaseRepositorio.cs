using YourChoice.Dominio.Contratos;
using YourChoice.Repositorio.Contexto;
using System.Collections.Generic;
using System.Linq;

namespace YourChoice.Repositorio.Repositorios
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
    {
        protected readonly YourChoiceContexto YourChoiceContexto;
        public BaseRepositorio(YourChoiceContexto yourChoiceContexto)
        {
            YourChoiceContexto = yourChoiceContexto;
        }

        public void Adicionar(TEntity entity)
        {
            YourChoiceContexto.Set<TEntity>().Add(entity);
            YourChoiceContexto.SaveChanges();
        }

        public void Atualizar(TEntity entity)
        {
            YourChoiceContexto.Set<TEntity>().Update(entity);
            YourChoiceContexto.SaveChanges();
        }

        public TEntity ObterPorId(int id)
        {
            return YourChoiceContexto.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return YourChoiceContexto.Set<TEntity>().ToList();
        }

        public void Remover(TEntity entity)
        {
            YourChoiceContexto.Remove(entity);
            YourChoiceContexto.SaveChanges();
        }

        public void Dispose()
        {
            YourChoiceContexto.Dispose();
        }
    }
}
