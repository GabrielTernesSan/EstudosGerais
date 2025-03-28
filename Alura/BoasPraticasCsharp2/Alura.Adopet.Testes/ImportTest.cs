using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Servicos;

namespace Alura.Adopet.Testes
{
    public class ImportTest
    {
        [Fact]
        public async Task QuandoAPIEstaNoArDeveRetornarListaDePet()
        {
            //Arrange
            var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
            var import = new Import(httpClientPet);
            string[] args = new string[] { "import", "lista.csv" };
            //Act
            await import.ExecutarAsync(args);
            //Assert
            var listaPet = await httpClientPet.ListPetsAsync();
            Assert.NotNull(listaPet);
        }
    }
}
