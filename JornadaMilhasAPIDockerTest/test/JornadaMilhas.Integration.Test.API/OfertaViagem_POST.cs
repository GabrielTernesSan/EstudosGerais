using JornadaMilhas.Dominio.Entidades;
using JornadaMilhas.Dominio.ValueObjects;
using System.Net.Http.Json;

namespace JornadaMilhas.Integration.Test.API
{
    public class OfertaViagem_POST
    {
        [Fact]
        public async Task Cadastra_OfertaViagem()
        {
            // Arrange
            var app = new JornadaMilhasWebApplicationFactory();

            using var client = app.CreateClient();
            
            var ofertaViagem = new
            {
                Preco = 100,
                Rota = new Rota("Origem", "Destino"),
                Periodo = new Periodo(DateTime.Parse("2024-03-03"), DateTime.Parse("2024-03-06"))
            };
            // Act
            var response = await client.PostAsJsonAsync("/ofertas-viagem", ofertaViagem);
            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}
