using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Datos;
using Dominio.Entidades;

namespace Aplicacion.Usuarios
{
    public class Nuevo
    {
        public class NuevoUsuario : IRequest
        {
            public int Id { get; set; }

            public string Nombres { get; set; }
        }

        public class Conductor : IRequestHandler<NuevoUsuario>
        {
            private readonly MySQLDBContext context;

            public Conductor(MySQLDBContext _context)
            {
                context = _context;
            }

            public async Task<Unit> Handle(NuevoUsuario request, CancellationToken cancellationToken)
            {
                var usuario = new Usuario
                {
                    UsuarioId = request.Id,
                    Nombres = request.Nombres
                };

                context.Usuario.Add(usuario);
                var valor = await context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se puedo inserta el usuario");
            }
        }
    }
}
