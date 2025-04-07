namespace UniSocial.Domain.Entities;

public class Postagem
{
    public int Id { get; set; }
    public int AutorId { get; set; }
    public Usuario? Autor { get; set; }

    public string Conteudo { get; set; } = string.Empty;
    public DateTime DataHora { get; set; }

    public List<Curtida> Curtidas { get; set; } = new();
    public List<Comentario> Comentarios { get; set; } = new();
}

public class Curtida
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int PostagemId { get; set; }
}

public class Comentario
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public string Texto { get; set; } = string.Empty;
    public DateTime DataHora { get; set; }
    public int PostagemId { get; set; }
}
