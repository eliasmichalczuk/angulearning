using System;
using YouLearn.Domain.Entities.Base;

namespace YouLearn.Domain.Entities
{
    public class Video : EntityBase
    {
        public Canal Canal { get; set; }
        public Playlist Playlist { get; set; }
        public string  Descricao { get; set; }
        public string  Titulo { get; set; }
        public string  Tags { get; set; }
        public int  OrdemNaPlaylist { get; set; }
        public int IdVideoYoutube { get; set; }
        public Usuario UsuarioQueSugeriu { get; set; }
        public EnumStatus Status { get; set; }

    }
}
