using UsuarioLib;

Usuario usuario = 
    new Usuario(
        "Daniel", 
        "daniel@email.com",
        new List<string>() {"12345678"});

FormularioDto dto = new FormularioDto("Gabriel", "11111111111111", "Programador Backend") { Idade = 24};
//dto.Nome = "Gabriel"; Imutável
dto.Idade = 100; // Mutável
Console.WriteLine($"Valor do nome: {dto.Nome}");