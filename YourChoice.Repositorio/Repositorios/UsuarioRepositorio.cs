using System.Linq;
using YourChoice.Dominio.Contratos;
using YourChoice.Dominio.Entidades;
using YourChoice.Repositorio.Contexto;

namespace YourChoice.Repositorio.Repositorios
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(YourChoiceContexto yourChoiceContexto) : base(yourChoiceContexto)
        {
            
        }

        public Usuario Obter(string email, string senha)
        {
            return YourChoiceContexto.Usuarios.FirstOrDefault(u=>u.Email == email && u.Senha == senha);
        }

        public Usuario Obter(string email)
        {
            return YourChoiceContexto.Usuarios.FirstOrDefault(u => u.Email == email);
        }
    }
}
