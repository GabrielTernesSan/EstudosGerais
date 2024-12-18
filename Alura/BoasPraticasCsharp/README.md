# Atributos
Os _Atributos_ são mecanismos para a _adição/associação de metadados_ a classes, métodos, propriedades, eventos, campos, interfaces, enumerações e estruturas. Esses metadados são usados para fornecer informações adicionais ao compilador e ao tempo de execução sobre o código. Após você incluir um atributo em um programa ele poderá ser consultado via _Reflection_.

Assim, um atributo é um objeto que representa os dados que você deseja associar com um elemento no seu programa. _O elemento ao qual você anexa um atributo é conhecido como o target (alvo) desse atributo._

## Usando Atributos

No C#, os atributos são classes que herdam da classe base _Attribute_. Qualquer classe que herda de _Attribute_ pode ser usada como uma espécie de "marcação" em outras partes do código. Por exemplo, há um atributo chamado _ObsoleteAttribute_. Esse atributo sinaliza que o código está obsoleto e não deve mais ser usado. Coloque este atributo em uma classe, por exemplo, usando colchetes.

```csharp
  [Obsolete]
  public class MyClass
  {
  }
```
Ao marcar uma classe obsoleta, é uma boa ideia fornecer algumas informações como o motivo de estar obsoleto e/ou o que usar no lugar. Você inclui um parâmetro de cadeia de caracteres para o atributo Obsolete para fornecer essa explicação.

```csharp
  [Obsolete("ThisClass is obsolete. Use ThisClass2 instead.")]
  public class ThisClass
  {
  }
```

## Como restringir o uso do atributo
Os atributos podem ser usados nos "destinos" a seguir. Os exemplos acima mostram os atributos em classes, mas eles também podem ser usados em:

- Assembly
- Classe
- Construtor
- Delegar
- Enumeração
- Evento
- Campo
- GenericParameter
- Interface
- Método
- Módulo
- Parâmetro
- Propriedade
- ReturnValue
- Estrutura

Quando você cria uma classe de atributo, por padrão, o C# permite que você use esse atributo em qualquer um dos destinos possíveis do atributo. Se quiser restringir seu atributo a determinados destinos, você poderá fazer isso usando o AttributeUsageAttribute em sua classe de atributo.

## Programação Assincrona

No desenvolvimento de sistemas modernos, sobretudo naqueles que trabalham a entrada e saída de dados (E/S) (como aqueles que acessam uma API online, ou leem e escrevem em algum diretório remoto), demandam de operações que podem exigir um tempo maior até sua conclusão. Com a programação, podemos continuar a execução do programa na thread principal, enquanto uma tarefa mais demorada, como as citadas acima, serão executadas em uma thread à parte.

A linguagem C# nos traz um modelo de programação que nos ajuda a abstrair toda a complexidade da programação assíncrona, que em até pouco tempo assustava muitos desenvolvedores.

No modelo de programação assíncrona, quando iniciamos uma tarefa que pode levar muito tempo de execução, assinalamos que essa determinada função é assíncrona e que será executada em uma thread à parte. Quando a mesma for completada ela irá sinalizar para a thread principal se foi concluída com sucesso ou falha.

De modo geral, no .NET, a maneira mais usual de implementarmos assincronismo no código é por meio da utilização do tipo `Task`, que representa uma operação assíncrona, e sua versão tipada `Task<T>`, que nos ajuda a modelar operações que deverão ser assíncronas, em conjunto com as palavras reservadas `async` e `await`.

O `async` indica ao .NET que o método é assíncrono e deverá ser executado em um outra thread. Isso possibilita que este método possa aguardar a conclusão da sua execução, enquanto outros tarefas ou trechos de códigos sejam executados; já o `await` é definido dentro do método, ou na invocação de um método assíncrono indicando que deve-se aguardar a conclusão da tarefa.


Uma operação de leitura ou escrita em arquivos podem levar tempo devido a diversos fatores, e para que nossa aplicação não permaneça bloqueada aguardando esse processamento podemos recorrer ao assincronismo. Observe o método LeitorDeArquivo:

```csharp
public string LeitorDeArquivo(string path){
  var conteudo = File.ReadAllText(path);
  return conteudo;
}
```

Para reescrevê-lo de modo assíncrono, vamos fazer algumas alterações:

```csharp
public async Task<string> LeitorDeArquivoAsync(string path){
  var conteudo = await File.ReadAllTextAsync(path);
  return conteudo;
}
```

Na implementação do método LeitorDeArquivoAsync, temos assinalado que é um método assíncrono pela utilização da palavra async e o tipo retornado Task<string>. No corpo do método invocamos uma operação de leitura assíncrona, por isso temos a seguinte linha, utilizando a palavra reservada await: var conteudo = await File.ReadAllTextAsync(path);

É importante ressaltar que na escrita do método LeitorDeArquivoAsync foi adicionado o sufixo Async. Isso é uma boa prática, pois é uma convenção muito utilizada; quem for fazer uso deste método já sabe que se trata de uma função assíncrona.