## Tipos de testes: quais os principais e por que utilizá-los?

### Testes unitários

Esses testes são feitos em um nível muito baixo (próximo ao código fonte) do projeto, por isso, geralmente quem os realiza são os programadores envolvidos no projeto.

Geralmente são realizados de forma isolada do restante do sistema, visto que tem por objetivo assegurar a qualidade das unidades de forma individual e não o sistema como um todo. Podemos entender como “unidade” as menores partes do nosso sistema, ou seja, métodos e funções das classes ou pacotes utilizados no projeto.

Esses testes têm como objetivo verificar as menores unidades isoladamente, garantindo que a lógica de cada uma delas está correta e que funciona conforme o esperado

### Testes de integração

Geralmente eles são mais complexos para serem desenvolvidos e mais lentos ao ser executados, pois ao contrário dos testes unitários, nosso objetivo não será testar a lógica nas menores unidades do sistema, mas sim as funcionalidades inteiras, o conjunto funcionando em simultâneo e entregando o resultado esperado.

Por isso, o ideal é realizar testes de integração após a realização dos testes unitários, garantindo que as unidades estão corretas individualmente e também que funcionam em conjunto.

### Testes de ponta a ponta (E2E)

Geralmente simulam a atividade que o usuário final teria, mas feita em um ambiente preparado para ser muito semelhante ao do ambiente de produção. Normalmente ele é o último teste antes de o projeto entrar em produção.

O ambiente no qual os testes são feitos precisa de situações que simulem o uso do produto desenvolvido no mundo real, como interagir com um banco de dados com informações reais, usar comunicações de rede, interagir com outros aplicativos, sistemas ou hardware, se necessário.

### Assert

Na estrutura de construção dos testes com o XUnit, utilizamos o Assert para verificar se as condições esperadas são verdadeiras durante a execução de um teste. O objetivo do Assert é garantir que o comportamento do código testado esteja de acordo com o que é esperado, trazendo retorno imediato.

O Assert possui vários métodos que nos auxiliam a fazer essas verificações e que utilizamos de acordo com a nossa necessidade de verificação. Confira alguns dos mais utilizados:

- Assert.Equal: Verifica se dois valores são iguais.
- Assert.NotEqual: Verifica se dois valores não são iguais.
- Assert.True: Verifica se uma expressão é verdadeira.
- Assert.False: Verifica se uma expressão é falsa.
- Assert.Null: Verifica se um valor é nulo.
- Assert.NotNull: Verifica se um valor não é nulo.
- Assert.Contains: Verifica se uma coleção contém um determinado elemento.
- Assert.Throws: Verifica se um método lança uma exceção específica.
- Assert.Empty: Verifica se uma coleção está vazia.
- Assert.StartsWith: Verifica se uma string começa com determinado prefixo.
- Assert.EndsWith: Verifica se uma string termina com determinado sufixo.

### O Padrão Triple A (Arrange, Act, Assert)

O modelo Triple A é um padrão que diz que todo o teste de unidade deve possuir três etapas: Arrange (Preparar o teste), Act (Rodar o teste) e Assert (Verificar as asserções).

#### 1ª Arrange

Nesta etapa nós configuramos tudo o que é necessário para que o nosso teste possa rodar, inicializamos variáveis, criamos alguns test doubles como Mocks ou Spies dentre outras coisas.

#### 2ª Act

Esta etapa é onde rodamos de fato o nosso teste. Chamamos alguma função ou método que queremos por a prova.

#### 3ª Assert

Esta etapa é onde faremos nosso assert. É onde verificamos se a operação realizada na etapa anterior (Act) surtiu o resultado esperado. Assim sabemos se o teste passa ou falha.

### Padrão Give, Then, When

O padrão Give-When-Then ajuda a estruturar os testes de maneira bem clara e compreensível seguindo uma abordagem descritiva que informa o comportamento esperado de um sistema em termos de entrada (give), ação (when) e saída (then). Nessas etapas temos:

_Give_: fase onde é configurado o cenário para o teste;
_When_: fase onde é executada a ação que se deseja testar;
_Then_: fase onde é verificado o resultado da ação anterior.

Os dois padrões são bem parecidos, porém possuem algumas diferenças básicas: por exemplo, o padrão AAA é mais focado na estruturação do teste em termos de organização do código e na execução do teste em si, destacando a preparação do ambiente de teste, a execução da ação e a verificação do resultado. Já o padrão Give-When-Then é mais orientado ao comportamento e coloca mais ênfase na descrição do comportamento do sistema em termos de entradas e saídas.

### O que é um caso de teste?

A especificação detalhada que descreve as condições, entradas, procedimentos e resultados esperados para verificar se um determinado componente do sistema está funcionando corretamente é chamada de caso de teste.

O caso de teste é uma parte fundamental do processo de teste de software e é elaborado durante a fase de planejamento dos testes, seus principais elementos são:

- _Identificação do caso de teste_ - cada caso de teste deve ter um identificador único, que pode ser um nome descritivo, por exemplo;
- _Descrição_ - uma descrição concisa do que o caso de teste está testando;
- _Pré-condições_ - as condições ou estados que devem ser verdadeiros antes que o caso de teste possa ser executado com sucesso;
- _Entradas_ - os dados de entrada necessários para executar o caso de teste;
- _Passos de execução_ - uma lista detalhada das etapas que devem ser seguidas para executar o caso de teste;
- _Resultados esperados_ - os resultados específicos que são esperados após a execução bem-sucedida do caso de teste;
- _Critérios de aceitação_ - critérios claros que determinam se o caso de teste foi aprovado ou reprovado.

## XUnit - Conceitos básicos

No xUnit precisamos decorar os métodos de teste com o atributo [Fact], que é usado pelo xUnit para marcar os métodos de testes. Além dos métodos de testes, também podemos ter vários métodos auxiliares na classe de teste.

Com o XUnit para tornar um método comum em método de testes basta adicionar [Fact] ou [Theory] acima de sua assinatura, os atributos diferem apenas no seguinte, para testes sem parâmetros deve-se usar [Fact], para testes como parâmetros utiliza-se o [Theory].

O atributo [Theory] indica um teste parametrizado que é verdadeiro para um subconjunto de dados. Esses dados podem ser fornecidos de várias maneiras, mas o mais comum é com um atributo [InlineData]. Assim este atributo permite executar um método de teste várias vezes passando diferentes valores a cada vez como parâmetros.

Podemos ainda desativar um teste por qualquer motivo. Para isso basta definir a propriedade Skip no atributo Fact com o motivo que você desativou o teste (o motivo não é exibido).

```csharp
    [Fact(Skip = "Teste ainda não disponível")]
    public void Teste()
    { }
```

Á medida que o número de seus testes aumenta, você pode organizá-los em grupos para que poder executar os testes juntos. O atributo [Trait] permite organizar os testes em grupos, criando nomes de categoria e atribuindo valores a eles.

```csharp
    [Fact(DisplayName = "Teste Numero 2")]
    [Trait("Calculo", "Somar")]
    public void Somar_DoisNumeros_RetornaNumero()
    { }
```

### Outras Annotations do XUnit

#### [ClassData]

Permite carregar dados para testes a partir de uma classe.

```csharp
public class MathTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { 1, 1, 2 };
        yield return new object[] { 2, 2, 4 };
        yield return new object[] { 5, 3, 8 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class MathTests
{
    [Theory]
    [ClassData(typeof(MathTestData))]
    public void Add_ShouldReturnCorrectSum(int a, int b, int expected)
    {
        // Act
        int result = a + b;

        // Assert
        Assert.Equal(expected, result);
    }
}
```

#### [Collection]

Define uma coleção de testes que compartilham o mesmo contexto ou configuração, ideal para evitar recriação de dependências.

```csharp
[CollectionDefinition("Shared Context")]
public class SharedContextCollection : ICollectionFixture<DatabaseFixture>
{
}

[Collection("Shared Context")]
public class DatabaseTests
{
    private readonly DatabaseFixture _fixture;

    public DatabaseTests(DatabaseFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TestDatabaseConnection()
    {
        Assert.NotNull(_fixture.Connection);
    }
}

public class DatabaseFixture : IDisposable
{
    public string Connection { get; private set; }

    public DatabaseFixture()
    {
        Connection = "Database Connected";
    }

    public void Dispose()
    {
        Connection = null;
    }
}
```

#### [Trait]

Adiciona categorias ou metadados a testes, úteis para filtros.

```csharp
public class MathTests
{
    [Fact]
    [Trait("Category", "Math")]
    public void Add_ShouldReturnCorrectSum()
    {
        // Act
        int result = 1 + 1;

        // Assert
        Assert.Equal(2, result);
    }
}
```

#### [Skip]

Pode ser usado junto com [Fact] ou [Theory] para pular testes.

```csharp
public class MathTests
{
    [Fact(Skip = "Teste não implementado ainda.")]
    public void Subtract_ShouldReturnCorrectDifference()
    {
        // Test logic
    }
}
```

## TDD (Test-Driven Development)

TDD, ou "Test-Driven Development" (em português, Desenvolvimento Orientado a Testes), é uma abordagem de desenvolvimento de software que enfatiza a criação de testes automatizados antes da implementação do código de produção. O processo TDD segue um ciclo iterativo e incremental, composto por três etapas principais: Red, Green, e Refactor.

_Red (Vermelho):_ Nesta fase, você escreve um teste automatizado que captura uma pequena parte do comportamento desejado do sistema. No entanto, o código de produção ainda não foi implementado, então o teste deve falhar (ficar "vermelho").

_Green (Verde):_ Agora, o objetivo é fazer com que o teste escrito na fase anterior passe. Você implementa apenas o código necessário para que o teste automatizado tenha êxito. O foco é escrever o código mínimo necessário para atender aos requisitos do teste.

_Refactor (Refatorar):_ Com o teste passando, você pode refatorar o código para melhorar sua qualidade, eficiência e legibilidade. O objetivo é garantir que o código continue atendendo aos requisitos, mas agora de uma maneira mais clara e eficiente.

O ciclo Red-Green-Refactor é repetido várias vezes ao longo do desenvolvimento do software. Cada iteração adiciona pequenos incrementos de funcionalidade ao sistema (conhecidos como baby steps) e garante que as alterações não quebrem o que já foi implementado. Isso ajuda a manter o código sempre em um estado funcional e facilita a detecção rápida de erros.

## Testes de mutação

Testes de mutação são uma técnica avançada de teste de software que visa avaliar a eficácia dos testes de unidade identificando lacunas na cobertura do código. Os testes de mutação são particularmente úteis para garantir que os testes não apenas verifiquem a implementação atual do código, mas também sejam robustos o suficiente para detectar mudanças semânticas significativas que possam introduzir bugs.

Os testes de mutação seguem o seguinte fluxo ao serem aplicados:

_Introdução de mutações:_ Um processo automatizado é usado para introduzir pequenas alterações no código-fonte, conhecidas como mutações.

_Execução dos testes:_ Depois que as mutações são introduzidas no código-fonte, os testes de unidade existentes são executados novamente. Se um teste de unidade falhar após a introdução de uma mutação, isso indica que o teste conseguiu detectar a mudança no comportamento do código.

_Análise dos resultados:_ Os resultados dos testes de mutação são analisados para determinar a eficácia dos testes existentes. Se um grande número de mutações não são detectadas pelos testes, isso sugere que há lacunas na cobertura de teste e que os testes podem não ser robustos o suficiente para detectar todas as variações no comportamento do código.

_Refinamento dos testes:_ Com base nos resultados da análise, as pessoas desenvolvedoras podem refinar os testes de unidade existentes ou adicionar novos testes para melhorar a cobertura e garantir que o código seja mais robusto contra alterações.
