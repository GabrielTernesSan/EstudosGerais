using JornadaMilhas.Dados;
using JornadaMilhasV1.Modelos;
using Xunit.Abstractions;

namespace JornadaMilhas.Test.Integracao
{
    [Collection(nameof(ContextoCollection))]
    public class OfertaViagemDalRecuperarTodas
    {
        private readonly JornadaMilhasContext context;

        public OfertaViagemDalRecuperarTodas(ITestOutputHelper output, ContextoFixture fixture)
        {
            context = fixture.Context;

            output.WriteLine(context.GetHashCode().ToString());
        }

        [Fact]
        public void RetornaListaQuandoHaOfertas()
        {
            // Arrange
            Rota rota = new Rota("São Paulo", "Fortaleza");
            Periodo periodo = new Periodo(new DateTime(2024, 8, 20), new DateTime(2024, 8, 30));
            double preco = 350;
            var oferta = new OfertaViagem(rota, periodo, preco);
            var dal = new OfertaViagemDAL(context);
            dal.Adicionar(oferta);

            // Act
            var ofertas = dal.RecuperarTodas();

            // Assert
            Assert.NotEmpty(ofertas);
        }
    }
}
