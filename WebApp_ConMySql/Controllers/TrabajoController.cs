using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Persistencia.Datos;
using Dominio.Entidades;

namespace WebApp_ConMySql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajoController : ControllerBase
    {
        private readonly MySQLDBContext _dbContext;

        public TrabajoController(MySQLDBContext context)
        {
            this._dbContext = context;
        }

        [HttpGet]
        public IList<Trabajo> ListarTrabajo()
        {
            return (this._dbContext.Trabajo.Include(x => x.Usuario).ToList());
        }
    }
}
