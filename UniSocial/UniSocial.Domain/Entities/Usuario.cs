namespace UniSocial.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Curso { get; set; } = string.Empty;

    public List<Usuario> Seguidores { get; set; } = new();
    public List<Postagem> Postagens { get; set; } = new();
}
