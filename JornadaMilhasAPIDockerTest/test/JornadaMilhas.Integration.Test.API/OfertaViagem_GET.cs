namespace JornadaMilhas.Integration.Test.API
{
    public class OfertaViagem_GET : IClassFixture<JornadaMilhasWebApplicationFactory>
    {
        private readonly JornadaMilhasWebApplicationFactory app;

        public OfertaViagem_GET(JornadaMilhasWebApplicationFactory app)
        {
            this.app = app;
        }

        [Fact]
        public async Task Recupera_OfertaViagem_PorId()
        {
            // Arrange
            // Act
            // Assert
        }
    }
}
