using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using YouLearn.Domain.Arguments.Base;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resources;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Domain.Services
{
    public class ServiceCanal : Notifiable, IServiceCanal
    {
        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IRepositoryCanal _repositoryCanal;

        public ServiceCanal(IRepositoryUsuario repositoryUsuario, IRepositoryCanal repositoryCanal)
        {
            _repositoryUsuario = repositoryUsuario;
            _repositoryCanal = repositoryCanal;
        }

        public CanalResponse AdicionarCanal(AdicionarCanalRequest request, Guid idUsuario)
        {
            Usuario usuario = _repositoryUsuario.Obter(idUsuario);
            Canal canal = new Canal(request.Nome, request.UrlLogo, usuario);
            AddNotifications(canal);
            if (this.IsInvalid()) return null;

            canal = _repositoryCanal.Adicionar(canal);
            return (CanalResponse)canal;
        }

        public Response ExcluirCanal(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CanalResponse> Listar(Guid idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}