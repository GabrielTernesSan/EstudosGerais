using System.Diagnostics;
using UsuarioLib;

Usuario usuario = 
    new Usuario(
        "Daniel", 
        "daniel@email.com",
        new List<string>() {"12345678"});

//UsuarioDto dto1 = new UsuarioDto();
//dto1.Nome = "Daniel";
//dto1.Email = "daniel@email.com";
//dto1.Telefones = new List<string>();

//UsuarioDto dto2 = new UsuarioDto();
//dto2.Nome = "Daniel";
//dto2.Email = "daniel@email.com";
//dto2.Telefones = new List<string>();

Stopwatch sw = new Stopwatch();

sw.Start();

for (int i = 0; i < 1000000000; i++)
{
    Coordenada coordenada = new Coordenada(123.456, -123.456);
    var latitude = coordenada.Latitude;
    var longitude = coordenada.Longitude;
}

sw.Stop();

Console.WriteLine(sw.Elapsed.TotalMilliseconds);

sw.Restart();

for (int i = 0; i < 1000000000; i++)
{
    FormularioDto dto = new FormularioDto("Daniel", "11111111111", "Programador", 24);
    var idade = dto.Idade;
    var nome = dto.Nome;
}

sw.Stop();

Console.WriteLine(sw.Elapsed.TotalMilliseconds);