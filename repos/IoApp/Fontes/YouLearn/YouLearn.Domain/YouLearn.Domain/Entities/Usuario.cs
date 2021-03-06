﻿using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using YouLearn.Domain.Extensions;
using YouLearn.Domain.Entities.Base;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Domain.Entities
{
    public class Usuario : EntityBase
    {

        public Usuario(Email email, string senha)
        {
            Email = email;
            Senha = senha;
            AddNotifications(email);
            Senha = Senha.ConvertToMD5();
        }

        public Usuario(Nome nome, Email email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;

            new AddNotifications<Usuario>(this).IfNullOrInvalidLength(x => x.Senha, 3, 32);
            Senha = Senha.ConvertToMD5();
            AddNotifications(nome, email);
        }

        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public string Senha { get; private set; }

    }
}
