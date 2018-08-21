using System.Collections.Generic;

namespace DesignPatterns2
{
    class NotasMusicais
    {
        private static IDictionary<string, INota> notas
            = new Dictionary<string, INota>()
            {
                {"do", new Do()},
                {"re", new Re() },
                {"mi", new Mi() },
                {"fa", new Fa() }
            };

        public INota Pega(string nome)
        {
            return notas[nome];
        }
    }
}