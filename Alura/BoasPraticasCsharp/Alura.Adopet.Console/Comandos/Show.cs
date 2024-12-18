using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "show", documentacao: "adopet show <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
    public class Show : IComando
    {
        public Task ExecutarAsync(string[] args)
        {
            this.ExibeCaminhoDoArquivo(caminhoDoArquivoASerExibido: args[1]);
            return Task.CompletedTask;
        }

        public void ExibeCaminhoDoArquivo(string caminhoDoArquivoASerExibido)
        {
            LeitorDeArquivo leitor = new LeitorDeArquivo();
            var listaDePets = leitor.RealizaLeitura(caminhoDoArquivoASerExibido);

            foreach (var pet in listaDePets)
            {
                System.Console.WriteLine(pet);
            }
        }
    }
}
