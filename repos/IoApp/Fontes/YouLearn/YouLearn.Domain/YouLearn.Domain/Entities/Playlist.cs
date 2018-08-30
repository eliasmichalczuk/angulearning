using System;
using YouLearn.Domain.Entities.Base;

namespace YouLearn.Domain.Entities
{
    class Playlist : EntityBase
    {
        public Usuario Usuario { get; set; }
        public EnumStatus Status { get; set; }
    }
}
