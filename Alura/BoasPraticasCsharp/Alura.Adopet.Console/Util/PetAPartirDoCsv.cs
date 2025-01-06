using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Util
{
    public static class PetAPartirDoCsv
    {
        public static Pet ConverteDoTexto(this string linha)
        {
            string[] propriedades = linha.Split(';');

            return new Pet(
                Guid.Parse(propriedades[0]),
                propriedades[1],
                TipoPet.Cachorro
            );
        }
    }
}
