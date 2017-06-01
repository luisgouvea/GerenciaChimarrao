using System.Data.Entity;

namespace GerenciaChimarrao.Models
{
    public class MapeamentoEntidadesContext : DbContext
    {
        public MapeamentoEntidadesContext() : base("InicializadorBD") { }
        public DbSet<Gaucho> Gauchos { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<StatusGaucho> StatusGauchos { get; set; }
    }
}