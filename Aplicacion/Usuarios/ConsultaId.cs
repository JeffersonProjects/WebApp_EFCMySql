using Dominio.Entidades;
using MediatR;
using Persistencia.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Usuarios
{
    public class ConsultaId
    {
        public class ConsultaPorId: IRequest<Usuario>
        {
            public int Id { get; set; }
        }

        public class Conductor : IRequestHandler<ConsultaPorId, Usuario>
        {
            private readonly MySQLDBContext context;
            public Conductor(MySQLDBContext _context)
            {
                context = _context;
            }

            public async Task<Usuario> Handle(ConsultaPorId request, CancellationToken cancellationToken)
            {
                var usuario = await context.Usuario.FindAsync(request.Id);
                return usuario;
            }
        }

    }
}
