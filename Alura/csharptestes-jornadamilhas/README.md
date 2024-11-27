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
