using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Infra.Persistencia.EF;

namespace YouLearn.Infra
{
    class RepositoryUsuario : IRepositoryUsuario
    {
        private readonly YouLearnContext _context;

        public RepositoryUsuario(YouLearnContext context)
        {
            _context = context;
        }

        public bool Existe(string email)
        {
            return _context.Usuarios.Any(x => x.Email.Endereco == email);
        }

        public Usuario Obter(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email.Endereco == email && x.Senha == senha);
        }

        public Usuario Obter(Guid id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public void Salvar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }
    }
}
