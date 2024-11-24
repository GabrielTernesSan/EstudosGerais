using UsuarioLib;

Usuario usuario = 
    new Usuario(
        "Daniel", 
        "daniel@email.com",
        new List<string>() {"12345678"});

UsuarioDto dto1 = new UsuarioDto();
dto1.Nome = "Daniel";
dto1.Email = "daniel@email.com";
//dto1.Telefones = new List<string>();
dto1.Telefones = null;

UsuarioDto dto2 = new UsuarioDto();
dto2.Nome = "Daniel";
dto2.Email = "daniel@email.com";
//dto2.Telefones = new List<string>();
dto2.Telefones = null;

// False
// O tipo lista é um tipo de referência, ao instanciarmos uma lista ela aponta para endereços de memória diferentes,
// por conta disso, a comparação da false

// E ao definirmos a lista de telefone como nulo os records "voltam" a serem iguais
Console.WriteLine(dto1==dto2);