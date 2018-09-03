using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Filmes.App.Negocio
{
    //[Table("actor")]
    //convensão do entity
    //quebra regra de nome de tabela
    //padrão string vira nvarchar
    //string aceita null padrão clr
    public class Ator
    {
        //[Column("actor_id")]
        public int Id { get; set; }
        //[Required]
        //[Column("first_name", TypeName ="varchar(45)")]
        public string PrimeiroNome { get; set; }
        //[Required]
        //[Column("last_name", TypeName = "varchar(45)")]
        public string UltimoNome { get; set; }

        public override string ToString()
        {
            return $"Ator ({Id}): {PrimeiroNome} {UltimoNome}";
        }
    }
}
