﻿using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;
using Moq;

namespace Alura.Adopet.Testes
{
    public class ImportIntegrationTest
    {
        [Fact]
        public async Task QuandoAPIEstaNoArDeveRetornarListaDePet()
        {
            //Arrange
            var leitorDeArquivo = new Mock<LeitorDeArquivo>(MockBehavior.Default, It.IsAny<string>());
            var listaDePet = new List<Pet>();

            var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"),
                 "Lima", TipoPet.Cachorro); //"456b24f4-19e2-4423-845d-4a80e8854a41; Lima Limão;1"; listaDePet.Add(pet);

            leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Returns(listaDePet);

            var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));

            var import = new Import(httpClientPet, leitorDeArquivo.Object);

            string[] args = new string[] { "import", "lista.csv" };

            //Act
            await import.ExecutarAsync(args);

            //Assert
            var listaPet = await httpClientPet.ListPetsAsync();
            Assert.NotNull(listaPet);
        }
    }
}
