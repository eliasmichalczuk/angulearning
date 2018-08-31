using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Infra.Persistencia.EF;

namespace YouLearn.Infra
{
    class RepositoryCanal : IRepositoryCanal
    {
        private readonly YouLearnContext _context;
        public Canal Adicionar(Canal canal)
        {
            _context.Canais.Add(canal);
            return canal;
        }

        public void Excluir(Canal canal)
        {
            _context.Canais.Remove(canal);
        }

        public IEnumerable<Canal> Lista(Guid idUsuario)
        {
            return _context.Canais.Where(x => x.Usuario.Id == idUsuario).AsNoTracking().ToList();
        }                                //apaga o rastreamento para na poder editar, maior velocidade de consulta

        public Canal Obter(Guid id)
        {
            return _context.Canais.FirstOrDefault(x => x.Id == id);
        }
    }
}
