using Aplicacion.Usuarios;
using Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebApp_ConMySql.Controllers
{
    //
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public readonly IMediator _mediator;
        public UsuarioController(IMediator mediador)
        {
            _mediator = mediador;
        }


        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> ListarUsuario()
        {
            return await _mediator.Send(new Consulta.ListarUsuario());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> UsuarioPorId(int id)
        {
            return await _mediator.Send(new ConsultaId.ConsultaPorId { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CrearUsuario(Nuevo.NuevoUsuario data)
        {
            return await _mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> EditarUsuario(int id, Editar.EditarUsuario data)
        {
            data.Id = id;
            return await _mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> EliminarUsuario(int id)
        {
            return await _mediator.Send(new Eliminar.EliminarUsuario { Id = id });
        }
    }
}
