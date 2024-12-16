namespace Alura.Adopet.Console
{
    [DocComando(instrucao: "show", documentacao: "adopet show <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
    public class Show
    {
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
