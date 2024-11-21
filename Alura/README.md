## Gerenciamento de memória e otimização de performance

### Stack e Heap

Stack: É onde são armazenados os tipos primitivos, como `int`, `bool`, `double`, entre outros. Quando declaramos variáveis desses tipos, seus valores são armazenados na stack, que funciona como uma pilha de dados. Já quando criamos um objeto, como `Usuario`, o que é armazenado na stack é a referência (ou ponteiro) que aponta para o objeto que está na heap.

Heap: É utilizada para armazenar objetos mais complexos. Quando criamos uma instância de um objeto, como Usuario usuario = new Usuario(), os dados desse objeto são armazenados na heap. Cada instância de objeto tem seu próprio espaço na heap.

LOH (Large Object Heap): É uma área específica da heap destinada a objetos muito grandes, com 85 KB ou mais.

### Linq

Geralmente quando utilizamos LINQ para realizar operações em coleções, como `Select()`, geralmente é criada uma nova sequência que ocupa um novo espaço na memória `heap`. Isso acontece porque as operações LINQ, em sua maioria, não alteram a coleção original, mas sim produzem uma nova coleção baseada na original.

No entanto, existem algumas operações que podem modificar a coleção original, dependendo do tipo de coleção que você está utilizando.

Aqui estão algumas operações que podem alterar a lista original:

_Add_: Se você estiver usando uma lista do tipo `List<T>`, você pode usar o método Add() para adicionar elementos à lista.

_Remove_: O método `Remove()` também altera a lista original, removendo um elemento específico.

_Clear_: O método `Clear()` remove todos os elementos da lista.

_Sort_: O método `Sort()` altera a ordem dos elementos na lista original.

_Insert_: O método `Insert()` permite que você insira um elemento em uma posição específica da lista.

Essas operações não são diretamente parte do LINQ, mas são métodos disponíveis nas coleções que podem ser utilizados em conjunto com LINQ.

Se você estiver utilizando métodos LINQ, como `Select()`, `Where()`, `OrderBy()`, entre outros, eles não alteram a coleção original, mas sim retornam uma nova sequência.

### List vs LinkedList

_Lists_: Utilizam um array (vetor) por debaixo dos panos. Para inserir um novo elemento, é necessário ter um espaço contínuo na memória. Se não houver espaço suficiente, a lista precisa ser realocada, o que pode ser custoso em termos de desempenho. Além disso, inserir um elemento em uma posição específica envolve mover todos os elementos subsequentes, o que também pode ser trabalhoso.

_LinkedLists_: Cada elemento (nó) pode estar em locais distintos da memória, pois cada um possui um ponteiro que indica o próximo elemento. Isso facilita a inserção de novos elementos no meio da lista, pois apenas as referências dos nós precisam ser alteradas. No entanto, para inserir um elemento no final da lista, é necessário percorrer toda a lista, o que pode ser mais lento.

_Bidirecionalidade_: As LinkedLists podem ser bidirecionais, onde cada nó aponta tanto para o próximo quanto para o anterior, permitindo navegação em ambas as direções.

### Structs

`Structs` são tipos de dados que permitem agrupar diferentes tipos de informações em uma única entidade. No .NET, as structs são consideradas tipos de valor, o que significa que elas são armazenadas na `stack`, ao contrário das classes, que são tipos de referência e são armazenadas na `heap`.

Algumas características importantes das structs incluem:

_Simplicidade:_ As `structs` são geralmente mais simples e leves do que as `classes`, sendo ideais para representar dados que não precisam de uma lógica complexa.

_Alocação de Memória:_ Como são armazenadas na `stack`, as `structs` podem oferecer melhor performance em termos de alocação e acesso à memória, especialmente em operações que envolvem a criação de muitas instâncias.

_Sem Herança:_ As `structs` não suportam herança como as `classes`, mas podem implementar interfaces.

_Imutabilidade:_ É comum que as `structs` sejam definidas como imutáveis, ou seja, seus valores não mudam após a criação. Isso ajuda a evitar efeitos colaterais indesejados.

_Menor Conjunto de Métodos:_ As `structs` têm um conjunto mais limitado de métodos em comparação com as `classes`, pois herdam de `System.ValueType`, que possui menos métodos do que `System.Object`.

_Boxing e Unboxing:_ Quando uma `struct` é tratada como um objeto (por exemplo, ao ser atribuída a uma variável do tipo de uma interface), ocorre o processo de boxing, que envolve a criação de uma caixa na `heap`. Isso pode impactar negativamente a performance, especialmente se feito repetidamente em loops.

_Construtores:_ Não é possível criar um construtor vazio para uma `struct`. Isso pode ser uma limitação em cenários onde um construtor padrão é necessário para inicializar objetos.

_Tamanho e Cópia:_ Como `structs` são tipos de valor, quando você passa uma `struct` para um método ou a atribui a outra variável, uma cópia completa da `struct` é feita. Isso pode ser ineficiente se a `struct` for grande, resultando em maior uso de memória e tempo de processamento.