using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourChoice.Dominio.Contratos;
using YourChoice.Dominio.Entidades;

namespace YourChoice.Web.Controllers
{
    [Route("api/[controller]")]
    public class IngredienteController : Controller
    {
        private readonly IIngredienteRepositorio _ingredienteRepositorio;
        private IHttpContextAccessor _httpContextAccessor;
        private IHostingEnvironment _hostingEnvironment;


        public IngredienteController(IIngredienteRepositorio ingredienteRepositorio,
                                    IHttpContextAccessor httpContextAccessor, IHostingEnvironment hostingEnvironment)
        {
            _ingredienteRepositorio = ingredienteRepositorio;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_ingredienteRepositorio.ObterTodos());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Ingrediente ingrediente)
        {
            try
            {
                if (ingrediente.Id > 0)
                {
                    _ingredienteRepositorio.Atualizar(ingrediente);
                }
                else
                {
                    _ingredienteRepositorio.Adicionar(ingrediente);
                }

                return Created("api/ingrediente", ingrediente);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost("Deletar")]
        public IActionResult Deletar([FromBody] Ingrediente ingrediente)
        {
            try
            {

                // ingrediente recebido do FromBody, deve ter a propriedade Id > 0
                _ingredienteRepositorio.Remover(ingrediente);
                return Json(_ingredienteRepositorio.ObterTodos());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
