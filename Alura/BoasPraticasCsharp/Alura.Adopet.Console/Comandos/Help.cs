using Alura.Adopet.Console.Util;
using System.Reflection;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "help", documentacao: "adopet help comando que exibe informações da ajuda. \n" +
        "Execute 'adopet.exe help [comando]' para obter mais informações sobre um comando.")]
    public class Help : IComando
    {
        private Dictionary<string, DocComando> docs;

        public Help()
        {
            docs = DocumentacaoDoSistema.ToDictionary(Assembly.GetExecutingAssembly());
        }

        public Task ExecutarAsync(string[] args)
        {
            ListarComandos(args);
            return Task.CompletedTask;
        }

        private void ListarComandos(string[] argumentos)
        {
            System.Console.WriteLine("Lista de comandos.");

            // se não passou mais nenhum argumento mostra help de todos os comandos
            if (argumentos.Length == 1)
            {
                System.Console.WriteLine("adopet help <parametro> ous simplemente adopet help  " +
                     "comando que exibe informações de ajuda dos comandos.");
                System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
                System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
                System.Console.WriteLine("Comando possíveis: ");
                foreach (var doc in docs.Values)
                {
                    System.Console.WriteLine(doc.Documentacao);
                }
            }
            // exibe o help daquele comando específico
            else if (argumentos.Length == 2)
            {
                string comandoASerExibido = argumentos[1];

                if (docs.ContainsKey(comandoASerExibido))
                {
                    var comando = docs[comandoASerExibido];

                    System.Console.WriteLine(comando.Documentacao);
                }
            }
        }
    }
}
