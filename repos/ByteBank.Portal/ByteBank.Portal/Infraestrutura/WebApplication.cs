using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura
{
    class WebApplication
    {
        private readonly string[] _prefixos;
        public WebApplication(string[] prefixos)
        {
            if (prefixos == null)
                throw new ArgumentException(nameof(prefixos));
            _prefixos = prefixos;
        }
        public void Iniciar()
        {

            while (true)
                ManipularReq();
        }
        private void ManipularReq()
        {
            var httpListener = new HttpListener();

            foreach (var prefixo in _prefixos)
            {
                httpListener.Prefixes.Add(prefixo);
            }
            httpListener.Start();

            var contexto = httpListener.GetContext();
            var requisicao = contexto.Request;
            var resposta = contexto.Response;

            var respostaConteudo = "Hello World";
            //transformar em stream
            var path = requisicao.Url.AbsolutePath;

            if (path == "/Assets/css/styles.css")
            {
                var assembly = Assembly.GetExecutingAssembly();
                var nomeResource = Utilidade.ConverterPathParaNomeAssembly(path);
                var resourceStream = assembly.GetManifestResourceStream(nomeResource);
                if(resourceStream == null)
                {
                    resposta.StatusCode = 404;
                    resposta.OutputStream.Close();
                }
                else
                {
                    var bytesResource = new byte[resourceStream.Length];

                    resourceStream.Read(bytesResource, 0, (int)resourceStream.Length);

                    resposta.ContentType = Utilidade.ObterTipoDeConteudo(path);
                    //codigo do status da requisição
                    resposta.StatusCode = 200;
                    //indica o tamanho da respota ao navegador
                    resposta.ContentLength64 = resourceStream.Length;

                    resposta.OutputStream.Write(bytesResource,
                        0, bytesResource.Length);

                    resposta.OutputStream.Close();
                }

                httpListener.Stop();

            }
            //var responseConteudoBytes = Encoding.UTF8.GetBytes(respostaConteudo);
            else if (path == "/Assets/js/main.js")
            {
                var assembly = Assembly.GetExecutingAssembly();
                var nomeResource = "ByteBank.Portal.Assets.js.main.js";
                var resourceStream = assembly.GetManifestResourceStream(nomeResource);
                var bytesResource = new byte[resourceStream.Length];

                resourceStream.Read(bytesResource, 0, (int)resourceStream.Length);

                resposta.ContentType = "application/js; charset=utf-8";
                //codigo do status da requisição
                resposta.StatusCode = 200;
                //indica o tamanho da respota ao navegador
                resposta.ContentLength64 = resourceStream.Length;

                resposta.OutputStream.Write(bytesResource,
                    0, bytesResource.Length);

                resposta.OutputStream.Close();
            }
            httpListener.Stop();

        }
    }
}
