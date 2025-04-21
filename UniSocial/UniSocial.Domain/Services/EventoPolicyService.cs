using System;
using System.Linq;
using System.Threading.Tasks;
using UniSocial.Domain.Entities;
using UniSocial.Domain.Interfaces;

namespace UniSocial.Domain.Services
{
    public class EventoPolicyService
    {
        private readonly IBloqueioRepository _bloqueioRepository;

        public EventoPolicyService(IBloqueioRepository bloqueioRepository)
        {
            _bloqueioRepository = bloqueioRepository;
        }

        public async Task<bool> PodeParticipar(Usuario usuario, Evento evento)
        {
            // Verifica se o usuário já está participando
            if (evento.Participantes.Any(p => p.Id == usuario.Id))
                return false;

            // Verifica se o evento já atingiu o limite
            if (evento.Participantes.Count >= 50)
                return false;

            // Verifica se algum participante bloqueou o usuário
            foreach (var participante in evento.Participantes)
            {
                var bloqueado = await _bloqueioRepository.ExisteBloqueio(participante.Id, usuario.Id);
                if (bloqueado)
                    return false;
            }

            return true;
        }
    }
}
