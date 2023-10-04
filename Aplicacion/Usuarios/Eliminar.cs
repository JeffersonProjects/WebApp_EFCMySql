using MediatR;
using Persistencia.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Usuarios
{
    public class Eliminar
    {
        public class EliminarUsuario : IRequest
        {
            public int Id { get; set; }
        }

        public class Procesador : IRequestHandler<EliminarUsuario>
        {
            private readonly MySQLDBContext context;
            public Procesador(MySQLDBContext _context)
            {
                context = _context;
            }

            public async Task<Unit> Handle(EliminarUsuario request, CancellationToken cancellationToken)
            {
                var usuario = await context.Usuario.FindAsync(request.Id);

                if (usuario == null)
                {
                    throw new Exception("No se puede eliminar el usuario");
                }              

                context.Remove(usuario);

                var resultado = await context.SaveChangesAsync();

                if (resultado > 0)
                    return Unit.Value;

                throw new Exception("No se pudieron guardar los cambios");
            }
        }
    }
}
