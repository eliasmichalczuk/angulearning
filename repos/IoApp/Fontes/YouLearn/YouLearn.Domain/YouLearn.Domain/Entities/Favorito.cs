﻿using YouLearn.Domain.Entities.Base;

namespace YouLearn.Domain.Entities
{
    class Favorito : EntityBase
    {
        public Video Video { get; set; }
        public Usuario Usuario { get; set; }
    }
}