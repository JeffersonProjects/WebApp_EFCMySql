using MediatR;
using Persistencia.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Usuarios
{
    public class Editar
    {
        public class EditarUsuario : IRequest
        {
            public int Id { get; set; }
            public string Nombres { get; set; }

        }

        public class Procesador : IRequestHandler<EditarUsuario>
        {
            private readonly MySQLDBContext context;
            public Procesador(MySQLDBContext _context)
            {
                context = _context;
            }

            public async Task<Unit> Handle(EditarUsuario request, CancellationToken cancellationToken)
            {
                var usuario = await context.Usuario.FindAsync(request.Id);

                if (usuario == null)
                {
                    throw new Exception("No se encontro el curso");
                }

                usuario.Nombres = request.Nombres ?? request.Nombres;

                var resultado = await context.SaveChangesAsync();

                if (resultado > 0)
                    return Unit.Value;

                throw new Exception("No se guardaron los cambios en el user");
            }
        }
    }
}
