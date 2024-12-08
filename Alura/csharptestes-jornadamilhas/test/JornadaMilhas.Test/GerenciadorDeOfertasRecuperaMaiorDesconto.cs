using JornadaMilhasV1.Gerencidor;
using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class GerenciadorDeOfertasRecuperaMaiorDesconto
    {
        [Fact]
        public void RetornaOfertaNulaQuandoListaEstaVazia()
        {
            // Arrange
            var lista = new List<OfertaViagem>();
            var gerenciador = new GerenciadorDeOfertas(lista);
            Func<OfertaViagem, bool> filtro = o => o.Rota.Destino.Equals("São Paulo");

            // Act
            var oferta = gerenciador.RecuperaMaiorDesconto(filtro);

            // Assert
            Assert.Null(oferta);
        }

        [Fact]
        public void RetornaOfertaEspecificaQuandoDestinoSaoPauloEDescontoQuarenta()
        {
            // Arrange
            var lista = new List<OfertaViagem>();
            var gerenciador = new GerenciadorDeOfertas(lista);
            Func<OfertaViagem, bool> filtro = o => o.Rota.Destino.Equals("São Paulo");
            var precoEsperado = 40;

            // Act
            var oferta = gerenciador.RecuperaMaiorDesconto(filtro);

            // Assert
            Assert.NotNull(oferta);
            Assert.Equal(precoEsperado, oferta.Preco);
        }
    }
}
