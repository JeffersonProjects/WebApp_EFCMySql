using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Persistencia.Datos;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Usuarios
{
    public class Consulta
    {
        public class ListarUsuario : IRequest<List<Usuario>> { }

        public class Conductor : IRequestHandler<ListarUsuario, List<Usuario>>
        {
            private readonly MySQLDBContext context;
            public Conductor(MySQLDBContext _context)
            {
                context = _context;
            }
        
            public async Task<List<Usuario>> Handle(ListarUsuario request, CancellationToken cancellationToken)
            {
                var usuarios = await context.Usuario.ToListAsync();
                return usuarios;
            }
        }

    }
}
