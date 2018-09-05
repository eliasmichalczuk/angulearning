using System.Collections.Generic;

namespace Alura.Filmes.App.Negocio
{
    public class Filme
    {
        

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string AnoLancamento { get; set; }
        public int Duracao { get; set; }
        public IList<FilmeAtor> Atores { get; set; }
        public IList<FilmeCategoria> Categorias { get; set; }
        public Idioma IdiomaFalado { get; set; }
        public Idioma IdiomaOriginal { get; set; }//aponta a uma de cada vez, propriedade de 
                                                //navegacao de referencia
              //duas ou mais propriedades de navegação, o ef não faz sozinho
        public Filme()
        {
            Atores = new List<FilmeAtor>();
        }
        public override string ToString()
        {
            return $"Ator ({Id}): {Titulo} {AnoLancamento}";
        }
    }
}
