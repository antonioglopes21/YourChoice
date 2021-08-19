using Microsoft.AspNetCore.Mvc;
using YourChoice.Dominio.Contratos;
using YourChoice.Dominio.Entidades;
using System;

namespace YourChoice.Web.Controllers
{
    [Route("api/[Controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_usuarioRepositorio.ObterTodos());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody]Usuario usuario)
        {
            try
            {
                if (usuario.Id > 0)
                {
                    _usuarioRepositorio.Atualizar(usuario);
                }
                else
                {
                    _usuarioRepositorio.Adicionar(usuario);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("Deletar")]
        public IActionResult Deletar([FromBody] Usuario usuario)
        {
            try
            {

                // produto recebido do FromBody, deve ter a propriedade Id > 0
                _usuarioRepositorio.Remover(usuario);
                return Json(_usuarioRepositorio.ObterTodos());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("VerficarUsuario")]
        public ActionResult VerficarUsuario([FromBody]Usuario usuario)
        {
            try
            {
                var usuarioRetorno = _usuarioRepositorio.Obter(usuario.Email,usuario.Senha);
                if (usuarioRetorno != null)
                    return Ok(usuarioRetorno);

                return BadRequest("Usuário ou senha inválido");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
