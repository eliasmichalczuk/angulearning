using System;
using System.Collections.Generic;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryCanal
    {
        Canal Obter(Guid id);
        IEnumerable<Canal> Lista(Guid idUsuario);
        Canal Adicionar(Canal canal);
        void Excluir(Canal canal);
    }
}
