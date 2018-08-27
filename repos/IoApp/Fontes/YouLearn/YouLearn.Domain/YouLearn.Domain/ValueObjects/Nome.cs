﻿using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace YouLearn.Domain.ValueObjects
{
    public class Nome : Notifiable
    {
        
        public Nome(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;

            new AddNotifications<Nome>(this)
                .IfNullOrInvalidLength(x => x.PrimeiroNome, 1, 50)
                .IfNullOrInvalidLength(x => x.UltimoNome, 1, 50);
        }

        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }

    }
}
