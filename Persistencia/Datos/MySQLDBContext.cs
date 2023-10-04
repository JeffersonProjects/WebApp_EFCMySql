using Microsoft.EntityFrameworkCore;
using Dominio.Entidades;

namespace Persistencia.Datos
{
    public class MySQLDBContext : DbContext
    {
        //AYUDA PARA COEXION MYSQL https://www.daveops.co.in/post/code-first-entity-framework-core-mysql
        //public MySQLDBContext(DbContextOptions options) : base(options)
        //{
        //}
        public MySQLDBContext(DbContextOptions<MySQLDBContext> options) : base(options) {         
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Trabajo> Trabajo { get; set; }


    }
}
