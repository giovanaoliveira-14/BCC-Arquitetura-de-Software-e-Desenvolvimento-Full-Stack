namespace UniSocial.Domain.Entities
{
    public class Bloqueio
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int BloqueadoId { get; set; }
        public DateTime DataBloqueio { get; set; }
    }
}
