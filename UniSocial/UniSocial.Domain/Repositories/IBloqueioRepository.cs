namespace UniSocial.Domain.Repositories
{
    public interface IBloqueioRepository
    {
        Task<bool> ExisteBloqueio(Guid usuarioId, Guid bloqueadoId);
    }
}
