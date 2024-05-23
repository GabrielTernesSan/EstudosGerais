# Serverless computing

Na computação sem servidor é utilizado serviços que abstraem todo o gerenciamento do ambiente, como escalabilidade, flexibilidade, gerenciamento de recursos de ghardware e ferramentas de programação. Sendo assim, o servidor deixa de ser uma responsabilidade do desenvolvedor e passa a ser do provedor de serviço cloud, a aplicação continua tendo um servidor para rodar mas a responsabilidade de gerenciamento não é mais do desenvolvedor.

## **Funções**

Funções Serverless são componentes de alta granularidade que permitem a execução de código com um propósito bem definido. Diferente das aplicações serveless full o servidor não permance "em pé" 24hrs ele trabalha com o conceito de Faas (Function as a Service) que basicamente são funções que respondem a certos gatilhos que permite que os clientes executem códigos em resposta a eles. Podem ser executados com diferentes tipos de gatilhos, como chamadas HTTP, mensagens em fila, upload de arquivos, Timers, entre outros.

Ao utilizar gatilhos HTTP podem representar endpoints de uma API, sendo comumente utilizados em conjunto com serviços de API Gateway, como o Azure API Management.

Os principais serviços de computação como **Amazon Web Services**, **Google Cloud Platform** e **Microsoft Azure** dão suporte ao uso de funções.

### **Azure Functions**

A *Azure Functions* é um dos vários serviços da nuvem da Azure, que disponibiliza computação sem servidores para aplicações backend. Possui integração com os demais serviços disponíveis, como armazenamento de blobs, bancos de dados, mensageria etc. A execução de uma função, como mencionado anteriormente, se dá através de **gatilhos**, que são eventos que disparam a execução de uma função. Os tipos de gatilhos mais utilizados para Azure Functions são:

- Temporizador: executa uma função em um horário ou em um intervalo de tempo definido;
- HTTP: executa uma função no momento em que uma requisição HTTP é feita para um endereço;
- Blob: executa uma função quando é criado um novo arquivo ou um arquivo é atualizado no armazenamento de blobs da Azure;
- Fila: executa uma função quando uma mensagem é adicionada em uma fila do armazenamento do Microsoft Azure.

Para desenvolver as funções, podem ser utilizadas como linguagens de programação **C#**, **Java**, **Python**, **Javascript/Typescript com Node.js** e **PowerShell**, e ainda utilizar **manipuladores personalizados** para executar outras linguagens, como **Go**, **Ruby** etc. Apenas as configurações específicas para executar funções são suficientes para começarmos a programar utilizando qualquer biblioteca/framework que já conhecemos.

**Inicialização de novas instâncias**

Com a abordagem FaaS, nem sempre uma função possui uma instância em execução, por isso toda vez que ocorre uma nova publicação ou quando o Cloud Provider cria uma nova instância automaticamente, o processo de inicialização é executado, isso significa que ocorrera uma latência na primeira requisição que esta nova instância atender.

Essa latência pode variar de acordo com vários aspectos, podemos considerar o tamanho do artefato entregue, sua utilização de rede e até mesmo a linguagem de desenvolvimento escolhida, pois linguagens não compiladas como Node.Js e Python, inicializam mais rápido que linguagens compiladas como Java e C#.

Existem 2 diferentes tipos de inicialização que impactam diretamente no tempo de inicialização, segue abaixo cada uma:

1. Inicialização quente: ocorre quando o Cloud Provider entende que uma instancia recém utilizada pode ser reaproveitada a partir de um contêiner criado em um evento anterior.
2. Inicialização fria: ocorre quando o Cloud Provider precisa instanciar a função do zero, criando um novo contêiner para a mesma.

## **Pontos de atenção**

**Não é uma tecnologia para todos.** As *functions* rodam em uma nuvem publica. Calma, os seus dados estão seguros lá. O detalhe de rodar em uma nuvem publica, é que — sem perceber — você pode dividir o mesmo servidor com outras empresas. Então caso seu sistema seja uma aplicação critica, que necessita de alta disponibilidade e performance, pode ser que não seja a melhor opção.

**Controle da infraestrutura.** A necessidade de controlar a infraestrutura pode ser um outro fator decisivo. Nas soluções que o mercado oferece existem poucas configurações que é possível fazer, dentre as possibilidades estão: a linguagem utilizada, memória RAM, permissões e time out.

**Dependência de fornecedor.** Este é um dos primeiros problemas que pensamos ao adotar uma tecnologia assim. A maneira que o código é escrito, mudar de fornecedor para fornecedor. Para superar isto, existem alguns *framework* — o mais famoso é o *[Serverless Framework](https://serverless.com/).* Mas mesmo assim, evitar ficar fortemente acoplado a um fornecedor é difícil, pois em conjunto com as *functions* normalmente utilizamos outros serviços, como por exemplo de armazenamento de arquivos(p.e S3), proxy de API(p.e Aws API Gateway) entre outros.

**Funções inativas**. Também chamado de “Cold Start”, é quando uma função fica um determinado tempo sem ser requisitada e entra em processo de inatividade. Quando ela está inativa e é requisitada pela primeira vez, o tempo de resposta será um pouco mais demorado. Existem alguns *workaround* — vulgo gambiarra — que podemos fazer para evitar que ela fique inativa, como por exemplo criar eventos agendados para chamar a função de tempo em tempo.

**Processamentos longos.** Outra característica importante das *functions* é que elas possuem um limite de *timeout* — nas maioria dos fornecedores é de no máximo 5 minutos. Esta característica existe para garantir que as *functions* sejam rápidas e escaláveis. Afinal, seria difícil garantir isto com vários processos travando os servidores e não dando espaço para novas rodarem.

**Governança**. FaaS nos leva ha um contexto de nanoservices, e isso eleva a complexidade na governança dos serviços, pois estamos saindo de um cenário onde um micro serviço era o responsável por trabalhar determinado domínio, para varias pequenas funções que agora possuem esta responsabilidade. Um bom exemplo é um CRUD de determinado domínio, ao invés de termos apenas um serviço para administrar, teríamos 4 funções/nanoservices tornando toda a arquitetura da empresa ainda mais distribuída e complexa.

**Características definitivas**. O uso de alguns serviços gerenciados as vezes até mesmo podem definir o comportamento final de nosso produto, por exemplo já tive a necessidade de tentar customizar o payload de requisições HTTP invalidas (HTTP code diferente de 2XX) utilizando API Gateway e o Lambda da AWS, o máximo que consegui foi alterar o código HTTP da requisição cadastrando uma série de expressões regulares no API Gateway, porém não foi possível customizar o corpo da requisição, por uma restrição do Cloud Provider.

## **Por que é legal utilizar?**

**Não há mais servidores.** Como já falamos anteriormente, com *Serverless* não existe a preocupação de manter uma infraestrutura, visto que o fornecedor fará isto por nós. Se a sua aplicação não possui requisitos que necessitem gerenciar os recursos do servidor, então *Serverless* pode ser uma ótima opção.

**Muitas utilidades.** As *functions* são [stateless](https://pt.wikipedia.org/wiki/Protocolo_sem_estado), esta característica possibilita resolver problemas que são solucionados através da escalabilidade e processamento paralelo. Usando a arquitetura *Serverless* é possível criar quase qualquer tipo de aplicação *back-end*. Utilizando o conjunto correto de ferramentas, tarefas que normalmente levam semanas para serem concluídas, agora podem ser feitas em dias ou até horas. Esta abordagem pode funcionar excepcionalmente bem para as *startups* que querem inovar e lançar rapidamente.

**Baixo cu$to**. Na arquitetura tradicional baseada em servidor requer servidores que não funcionam necessariamente a plena capacidade. Escalar, mesmo com sistemas automatizados, envolve um novo servidor, que muitas vezes é desperdiçado até que haja um aumento temporário no tráfego. Os sistemas *Serverless* são muito mais granulares em relação à escala e são rentáveis, especialmente quando o trafego é irregular ou inesperado. As soluções *Serverless* são cobradas por uso, isso significa que você só vai pagar para aquilo que realmente está utilizando.

**Menos código.** No inicio do post falamos sobre as aplicações tradicionais e as várias camadas delas. As soluções *Serverless* possuem menos complexidade neste sentido, pois há menos necessidade de ter um sistema *back-end* de várias camadas, especialmente se você permitir que o *front-end* faça mais trabalho e converse diretamente com os serviços(e o banco de dados).

**Escalável e flexível.** Como desenvolvedores, não precisamos rescrever todo o nosso *back-end* com a arquitetura *Serverless.* Uma alternativa razoável é resolver problemas específicos, especialmente aqueles que precisam de paralelização. Visto que os servidores são completamente gerenciados por terceiros, a escalabilidade vem integrada. Isso significa que não é necessário configurações adicionais para aproveitar a escalabilidade que a arquitetura proporciona.

### **Referências**

https://medium.com/trainingcenter/serverless-mais-foco-nas-suas-aplica%C3%A7%C3%B5es-8606e7896c57

https://renatogroffe.medium.com/desenvolvimento-serverless-com-net-core-implementando-sua-primeira-azure-function-5a3898c4cf51

https://www.luisdev.com.br/2022/03/17/serverless-com-c-e-azure-functions-introducao/

https://wssilva-willian.medium.com/serverless-e3a325013a39

## **Firecracker AWS**

https://dev.to/oliverjumpertz/how-aws-lambda-works-under-the-hood-2iae

https://shahbhargav.medium.com/firecracker-secure-and-fast-microvms-628e6043b572