### Using

A instrução `using` garante o uso correto de uma instância [IDisposable](https://learn.microsoft.com/pt-br/dotnet/api/system.idisposable) (um mecanismo para liberar recursos não gerenciados):

```csharp
var numbers = new List<int>();
using (StreamReader reader = File.OpenText("numbers.txt"))
{
    string line;
    while ((line = reader.ReadLine()) is not null)
    {
        if (int.TryParse(line, out int number))
        {
            numbers.Add(number);
        }
    }
}

```

Quando o controle sai do bloco da instrução `using`, uma instância adquirida [IDisposable](https://learn.microsoft.com/pt-br/dotnet/api/system.idisposable) é descartada. Em particular, a instrução `using` garante que uma instância descartável seja descartada mesmo que ocorra uma exceção dentro do bloco da instrução `using`. No exemplo anterior, um arquivo aberto é fechado depois que todas as linhas são processadas.

Uma variável declarada pela instrução ou declaração `using` é somente leitura. Não é possível reatribuí-la nem passá-la como um parâmetro `ref` ou `out`.

### ADO.NET (ActiveX Data Objects .NET)

É um componente do .NET Framework usado para acessar dados de bancos de dados relacionais e não relacionais de maneira eficiente. Ele fornece uma série de classes que permitem a conexão com diferentes bancos de dados (como SQL Server, Oracle, MySQL), a execução de comandos SQL e o gerenciamento de dados em aplicações .NET.

O ADO.NET separa o acesso a dados da manipulação de dados em componentes discretos que podem ser usados separadamente ou em tandem. O ADO.NET inclui os provedores de dados do .NET Framework para se conectar a um banco de dados, executar comandos e recuperar resultados. Esses resultados são processados diretamente, colocados em um objeto `DataSet` do ADO.NET para serem expostos para o usuário ad hoc, combinados com dados de várias fontes ou passados entre as camadas. O objeto `DataSet` também pode ser usado independentemente de um provedor de dados .NET Framework para gerenciar o local dos dados para o aplicativo ou originado no XML.

A ADO.NET usa uma arquitetura multicamada que possui diferentes componentes .NET para interagir com o banco de dados e processar o resultado da consulta usando objetos Connection, Reader, Command, Adapter e DataSet/DataTable.

### DAO

### DAL

### ORM

### Func

### Migrations

### Lazy loading

### Proxies