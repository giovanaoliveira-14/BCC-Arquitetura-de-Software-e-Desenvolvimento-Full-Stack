namespace UniSocial.Domain.Entities;

public class Evento
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Local { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public DateTime DataHora { get; set; }
    public bool ExigeInscricao { get; set; }

    public List<Usuario> Inscritos { get; set; } = new();
}
