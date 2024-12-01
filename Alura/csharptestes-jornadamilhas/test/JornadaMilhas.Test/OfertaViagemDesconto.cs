using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class OfertaViagemDesconto
    {
        [Fact]
        public void RetornaPrecoAtualizadoQuandoAplicadoDesconto()
        {
            // Arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 05, 5), new DateTime(2024, 05, 10));
            double precoOriginal = 100.0;
            double desconto = 20.0;
            double precoComDesconto = precoOriginal - desconto;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);

            // Act
            oferta.Desconto = desconto;

            // Assert
            Assert.Equal(precoComDesconto, oferta.Preco);
        }
    }
}
