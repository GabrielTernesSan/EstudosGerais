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
