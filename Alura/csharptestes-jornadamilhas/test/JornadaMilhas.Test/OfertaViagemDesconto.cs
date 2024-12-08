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

        [Theory]
        [InlineData(120, 30)]
        [InlineData(100, 30)]
        public void RetornaDescontoMaximoQuandoValorDescontoMaiorOuIgualPreco(double desconto, double precoComDesconto)
        {
            // Arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 05, 5), new DateTime(2024, 05, 10));
            double precoOriginal = 100.0;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);

            // Act
            oferta.Desconto = desconto;

            // Assert
            Assert.Equal(precoComDesconto, oferta.Preco);
        }

        [Theory]
        [InlineData(-120)]
        [InlineData(0)]
        public void RetornaPrecoOriginalQuandoDescontoMenorIgualAZero(double desconto)
        {
            // Arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 05, 5), new DateTime(2024, 05, 10));
            double precoOriginal = 100.0;
            double precoComDesconto = precoOriginal;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);

            // Act
            oferta.Desconto = desconto;

            // Assert
            Assert.Equal(precoComDesconto, oferta.Preco);
        }

        [Fact]
        public void RetornaTresErrosDeValidacaoQuandoRotaPeriodoEPrecoSaoInvalidos()
        {
            var quantidadeEsperada = 3;
            Rota rota = null;
            Periodo periodo = new Periodo(new DateTime(2024, 05, 15), new DateTime(2024, 05, 10));
            double preco = -120.0;
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Equal(quantidadeEsperada, oferta.Erros.Count());
        }
    }
}
