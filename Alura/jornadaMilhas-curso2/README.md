# Setup e Teardown
Em testes de integração, os conceitos de setup e teardown referem-se às etapas de preparação e limpeza do ambiente de teste antes e depois da
 execução de cada teste. Essas etapas são usadas para garantir que os testes sejam executados em condições consistentes e previsíveis, 
 independentemente do estado inicial do ambiente de teste.

_Setup:_ O setup é a etapa em que você prepara o ambiente de teste antes da execução de cada teste. Isso pode incluir a criação de objetos 
necessários, a configuração de variáveis de ambiente, a inicialização de bancos de dados de teste, entre outras tarefas. O objetivo do setup é 
garantir que o ambiente de teste esteja pronto e configurado corretamente para a execução do teste.

_Teardown:_ O teardown é a etapa em que você limpa e restaura o ambiente de teste para o seu estado original após a execução de cada teste. Isso
 pode incluir a exclusão de objetos criados durante o setup, a limpeza de bancos de dados de teste, a restauração de variáveis de ambiente, entre 
 outras tarefas. O objetivo do teardown é garantir que o ambiente de teste retorne ao seu estado original após a execução do teste, evitando 
 assim a interferência entre os testes.
