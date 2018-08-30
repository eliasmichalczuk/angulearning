using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resources;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Domain.Services
{
    public class ServiceUsuario : Notifiable, IServiceUsuario
    {
        //Dependencias do serviço usuario
        private readonly IRepositoryUsuario _repositoryUsuario;
        //consturtor
        public ServiceUsuario(IRepositoryUsuario repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public AdicionarUsuarioResponse AdicionarUsuario(AdicionarUsuarioRequest request)
        {
            if (request == null)
            {
                // throw new System.Exception("AdicionarUsuarioRequest obrigatori");
                AddNotification("AdicionarUsuarioRequest", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarUsuarioRequest"));
                return null;
            }
            //Cria VOs
            Nome nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            //AddNotifications(nome); Já está vaidando no usuari
            Email email = new Email(request.Email);
            //cria entidade
            Usuario usuario = new Usuario(nome, email, request.Senha);
            //usuario.Nome.PrimeiroNome = "joao"; DONE: nao deve deixar alterar nome aqui
            AddNotifications( usuario);
            if (usuario.Nome.PrimeiroNome.Length < 3 || usuario.Nome.PrimeiroNome.Length < 50)
            {
               throw new System.Exception("primeiro nome deve conter entre 3 e 50");
            }


            // TODO: validar todo o resto
            // AdicionarUsuarioResponse response = new RepositoryUsuario().Salvar(usuario);
            //return response;

            if (IsInvalid())
            {
                return null;
            }
            _repositoryUsuario.Salvar(usuario);
            return new AdicionarUsuarioResponse(usuario.Id);
        }

        public AutenticarUsuarioResponse AutenticarUsuario(AutenticarUsuarioRequest request)
        {
            if (request == null)
            {
                AddNotification("AutenticarUsuarioRequest", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AutenticarUsuarioRequest"));
                return null;
            }

            var email = new Email(request.Email);
            var usuario = new Usuario(email, request.Senha);

            AddNotifications(usuario);
            if (IsInvalid()) return null;

            usuario = _repositoryUsuario.Obter(usuario.Email.Endereco, usuario.Senha);

            if (request == null)
            {
                AddNotification("Usuario", MSG.DADOS_NAO_ENCONTRADOS);
                return null;
            }
            var response = new AutenticarUsuarioResponse()
            {
                Id = usuario.Id,
                PrimeiroNome = usuario.Nome.PrimeiroNome
            };
            return response;
        }
    }
}
