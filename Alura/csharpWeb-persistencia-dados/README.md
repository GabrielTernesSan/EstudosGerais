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

### DAL (Data Access Layer)

DAL (ou "Infra") é uma camada completa da arquitetura da aplicação que abstrai e gerencia o acesso aos dados de forma centralizada. Ela pode incluir várias classes e componentes que trabalham juntos para realizar operações de banco de dados.

### DAO (Data Access Object)

DAO (Ou "Repository") é um padrão de design específico para representar uma entidade específica e suas operações de banco de dados. Cada DAO é responsável por gerenciar a persistência e recuperação de dados de uma única entidade. Tem como objetivo encapsular todas as operações de banco de dados relacionadas a uma única entidade em uma classe.

### ORM

ORM é a sigla em inglês para Object-Relational Mapping, que significa Mapeamento Objeto-Relacional, trata-se de uma técnica utilizada em desenvolvimento de software cujo objetivo é atuar como um intermediário entre o banco de dados relacional e a aplicação, facilitando a manipulação de dados sem a necessidade de escrever consultas SQL complexas. O funcionamento do ORM se baseia na criação de uma camada de abstração que mapeia as classes de objetos da aplicação para as tabelas do banco de dados. Cada classe representa uma tabela, e cada instância da classe representa uma linha na tabela.

### Migrations

Migrations são um mecanismo usado para gerenciar alterações na estrutura de um banco de dados (como criação, modificação ou remoção de tabelas e colunas) de forma controlada e programática. Elas registram essas mudanças em arquivos de script, permitindo que o banco de dados evolua em sincronia com o código da aplicação.

### Lazy loading

Lazy load é um padrão de design utilizado para adiar a inicialização de um objeto ou a recuperação de dados até que eles sejam realmente necessários. Isso pode melhorar o desempenho e a eficiência de recursos, especialmente em aplicações que trabalham com grandes volumes de dados ou estruturas complexas. O lazy loading usa proxies para interceptar acessos a propriedades e buscar dados relacionados de maneira atrasada.

### Proxies

Proxies são objetos intermediários que atuam como substitutos de outros objetos. Eles "se colocam no meio" entre o código que consome um objeto e o próprio objeto real, permitindo adicionar lógica adicional antes ou depois que o objeto original seja acessado.

Os proxies são frequentemente usados para implementar comportamentos como:

_Atrasar a inicialização de objetos:_ Como no caso de lazy loading.
_Controle de acesso:_ Para adicionar validações antes de permitir acesso ao objeto real.
_Monitoramento ou logging:_ Para rastrear operações executadas no objeto.
_Distribuição:_ Para trabalhar com objetos remotos.
