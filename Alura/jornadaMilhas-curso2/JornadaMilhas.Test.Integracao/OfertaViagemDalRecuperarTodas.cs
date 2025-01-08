using JornadaMilhas.Dados;
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
            var dal = new OfertaViagemDAL(context);

            // Act
            var ofertas = dal.RecuperarTodas();

            // Assert
            Assert.NotEmpty(ofertas);
        }
    }
}
