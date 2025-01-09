using Bogus;
using DotNet.Testcontainers.Builders;
using JornadaMilhas.Dados;
using JornadaMilhasV1.Modelos;
using Microsoft.EntityFrameworkCore;
using Testcontainers.MsSql;

namespace JornadaMilhas.Test.Integracao
{
    public class ContextoFixture : IAsyncLifetime
    {
        
        public JornadaMilhasContext? Context { get; private set; }

        private readonly MsSqlContainer _msSqlContainer = new MsSqlBuilder()
            .WithImage("mcr.microsoft.com/mssql/server:2019-latest")
            .WithPortBinding(1433, true)
            .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(1433))
            .Build();

        public async Task InitializeAsync()
        {
            await _msSqlContainer.StartAsync();

            var options = new DbContextOptionsBuilder<JornadaMilhasContext>()
                .UseSqlServer(_msSqlContainer.GetConnectionString())
                .Options;

            Context = new JornadaMilhasContext(options);
            Context.Database.Migrate();
        }

        public void CriaDadosFake()
        {
            var fakerOferta = new Faker<OfertaViagem>()
                    .CustomInstantiator(f => new OfertaViagem(
                            new RotaDataBuilder().Build(),
                            new PeriodoDataBuilder().Build(),
                            100 * f.Random.Int(1, 100))
                    )
                    .RuleFor(o => o.Desconto, f => 40)
                    .RuleFor(o => o.Ativa, f => true);

            var lista = fakerOferta.Generate(200);

            Context.OfertasViagem.AddRange(lista);
            Context.SaveChanges();
        }

        public async Task LimpaDadosDoBanco()
        {
            //Context.OfertasViagem.RemoveRange(Context.OfertasViagem);
            //Context.Rotas.RemoveRange(Context.Rotas);
            //await Context.SaveChangesAsync();

            Context.Database.ExecuteSqlRaw("DELETE FROM OfertasViagem");
            Context.Database.ExecuteSqlRaw("DELETE FROM Rotas");
        } 

        public async Task DisposeAsync()
        {
            await _msSqlContainer.StopAsync();
        }
    }
}
