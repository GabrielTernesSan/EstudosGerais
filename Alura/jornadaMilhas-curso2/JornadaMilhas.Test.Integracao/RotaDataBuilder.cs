using Bogus;
using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test.Integracao
{
    public class RotaDataBuilder : Faker<Rota>
    {
        public String? Origem { get; set; }
        public String? Destino { get; set; }

        public RotaDataBuilder()
        {
            CustomInstantiator(f =>
            {
                String origem = Origem ?? f.Address.City();
                String destino = Destino ?? f.Address.City();
                return new Rota(origem, destino);
            });
        }

        public Rota Build() => Generate();
    }
}
