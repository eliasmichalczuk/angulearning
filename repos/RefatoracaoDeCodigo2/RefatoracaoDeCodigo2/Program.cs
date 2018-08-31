using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefatoracaoDeCodigo2
{
    class Program
    {
        static void Main(string[] args)
        {

            //encapsular colecao




        }



    }
    class Aluno
    {
        private readonly List<Curso> cursos;
        internal IReadonlyCollection<Curso> Cursos {
            //                                  contrutor de Cursos que usa propriedade interna cursos
            get => new ReadOnlyCollection<curso>(cursos); } //manda copia da lista de cursos
    }


}
