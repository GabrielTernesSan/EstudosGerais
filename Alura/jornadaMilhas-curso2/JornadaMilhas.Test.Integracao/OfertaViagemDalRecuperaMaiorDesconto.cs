using Bogus;
using JornadaMilhas.Dados;
using JornadaMilhasV1.Gerenciador;
using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test.Integracao
{
    [Collection(nameof(ContextoCollection))]
    public class OfertaViagemDalRecuperaMaiorDesconto : IDisposable
    {
        private readonly JornadaMilhasContext Context;

        public OfertaViagemDalRecuperaMaiorDesconto(ContextoFixture fixture)
        {
            Context = fixture.Context;
            Fixture = fixture;
        }

        public ContextoFixture Fixture { get; }

        public void Dispose()
        {
            Fixture.LimpaDadosDoBanco();
        }

        [Fact]
        // destino = são paulo, desconto = 40, preco = 80
        public void RetornaOfertaEspecificaQuandoDestinoSaoPauloEDesconto40()
        {
            //arrange
            var fakerPeriodo = new PeriodoDataBuilder() { DataInicial = new DateTime(2024, 5,20)}.Build();

            var rota = new RotaDataBuilder() { Destino = "São Paulo" }.Build();

            Fixture.CriaDadosFake();

            var ofertaEscolhida = new OfertaViagem(rota, fakerPeriodo, 80)
            {
                Desconto = 40,
                Ativa = true
            };

            var dal = new OfertaViagemDAL(Context);
            dal.Adicionar(ofertaEscolhida);

            Func<OfertaViagem, bool> filtro = o => o.Rota.Destino.Equals("São Paulo");
            var precoEsperado = 40;

            //act
            var oferta = dal.RecuperaMaiorDesconto(filtro);

            //assert
            Assert.NotNull(oferta);
            Assert.Equal(precoEsperado, oferta.Preco, 0.0001);
        }

        [Fact]
        public void RetornaOfertaEspecificaQuandoDestinoSaoPauloEDesconto60()
        {
            //arrange
            var fakerPeriodo = new PeriodoDataBuilder() { DataInicial = new DateTime(2024, 5, 20) }.Build();

            var rota = new RotaDataBuilder() { Destino = "São Paulo" }.Build();

            Fixture.CriaDadosFake();

            var ofertaEscolhida = new OfertaViagem(rota, fakerPeriodo, 80)
            {
                Desconto = 60,
                Ativa = true
            };

            var dal = new OfertaViagemDAL(Context);
            dal.Adicionar(ofertaEscolhida);

            Func<OfertaViagem, bool> filtro = o => o.Rota.Destino.Equals("São Paulo");
            var precoEsperado = 20;

            //act
            var oferta = dal.RecuperaMaiorDesconto(filtro);

            //assert
            Assert.NotNull(oferta);
            Assert.Equal(precoEsperado, oferta.Preco, 0.0001);
        }
    }
}
