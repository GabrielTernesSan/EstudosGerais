﻿using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;
using Moq;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes
{
    public class ImportTest
    {
        [Fact]
        public async Task QuandoListaVaziaNaoDeveChamarCreatePetAsync()
        {
            //Arrange
            var leitorDeArquivo = new Mock<LeitorDeArquivo>(MockBehavior.Default, It.IsAny<string>());
            
            var listaDePet = new List<Pet>();

            leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Returns(listaDePet);

            var httpClientPet = new Mock<HttpClientPet>(MockBehavior.Default, It.IsAny<HttpClient>());

            var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);

            string[] args = new string[] { "import", "lista.csv" };
            
            // Act
            await import.ExecutarAsync(args);
            
            // Assert
            httpClientPet.Verify(_ => _.CreatePetAsync(It.IsAny<Pet>()), Times.Never);
        }
    }
}
