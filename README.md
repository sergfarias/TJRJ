# Developer Evaluation Project

## Considerações:

1 – Feito com NetCore8, Visual Studio 22.

2 - Usei uma arquitetura DDD para tentar deixar o mais limpo possível, com separação dos projetos.

3 – O designer parttern eu optei pelo CQRS. Eu gosto muito pois faz uma separação entre buscas e ações (Update, Insert, Delete) no banco de dados, 
e com isso fornece uma melhor organização e facilita em futuras manutenções. Também facilita a comunicação com mais de um banco de dados. 
Ponto negativo talvez seja a maior quantidade de arquivos... Infelizmente não ficou 100% por falta de tempo. 

4 - Para banco dados usei o SQL Express com Migrations: 
NO PACKAGE MANAGER CONSOLE RODAR O MIGRATIONS
PROJ:Adapters\Drivers\WebApi\Works.DeveloperEvaluation.WebApi
add-migration Inicio -Context Context -verbose
update-database Inicio 
 

5 - FALTOU FAZER:
5.1 - Cobertura testes
* Não tive tempo, caso desejem me deem mais um dias que faço. 

5.2 - modelo inicial não prevê, mas é necessário incluir uma forma de informar o valor (em R$) do livro dependendo da forma de compra do mesmo 
(exemplos: balcão, self-service, internet, evento, etc). Deve ser feito tanto o modelo quanto a implementação necessária para que esteja disponível 
para o usuário final.
* Não tive tempo, caso desejem me deem mais um dias que faço. 	
