using UsuarioLib;

Usuario usuario = 
    new Usuario(
        "Daniel", 
        "daniel@email.com",
        new List<string>() {"12345678"});


//12345678
//usuario.ExibeTelefones();

//efetuar a padronização
//usuario.PadronizaTelefones();

//912345678
//usuario.ExibeTelefones();

FormularioDto dto = new FormularioDto();
dto.Nome = "Gabriel";
dto.Idade = 24;
dto.Cargo = "Programador Backend";
dto.Cpf = "11111111111111";

FormularioDto dto2 = new FormularioDto();
dto2.Nome = "Gabriel";
dto2.Idade = 24;
dto2.Cargo = "Programador Backend";
dto2.Cpf = "11111111111111";

//False(quando classe) pois eles tem ponteiros apontando para endereços diferente na memória Heap
//True(quando record)  porque os records são projetados para comparar seus valores em vez de suas referências de memória.
Console.WriteLine(dto == dto2);