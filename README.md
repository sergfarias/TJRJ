# Introdução
Exemplo de uso e estruturação de projetos utilizando a tecnologia .NET na BRF.
O objetivo dos modelos é fornecer um guia no que se refere ao mínimo de qualidade,
organização e padronização de código.
Qualquer melhoria que vá além, mantendo padrões e simplicidade é bem vinda.
A versão mínima exigida do framework é a .net core 6, porém é altamente recomentado a adoção da versão 7.

# Projetos do tipo WebApis, WebAppsMVC, CQRS
As pastas estão organizadas de acordo o tipo de solução a ser adotada, sendo:
- SingleMvcApi: exemplo de criação de uma webapi simples, sem o uso de autenticação, porem adotando o uso do Azure Keyvault
                para obtenção das connections strings e dados sensíveis. É vetado a exposição destas informações dentro de
                arquivos appsettings.json ou semelhantes, mesmo para ambientes de dev e qas. 

# Projetos do tipo funções - Azure Functions
Functions tem o objetivo de resolver problemas específicos, ou seja, a menor unidade possível.
  Caso o problema a ser resolvido contenha mais de uma situação, deve ser desenvolvido mais de 
  uma function.

  Exemplo: Imagine uma situação onde é necessário consumir um webservice com dois serviços, um 
           serviço de leitura Denominado serviço A e outro serviço B.
           Neste caso devemos ter uma function que consome e processa o serviço A e outra function
           que processa o serviço B.

As pastas estão organizadas com os seguintes exemplos:

  - TimerTriggerExample : Função que dispara de tempos em tempos com base no agendamento de uma cronexpression,
                          mostrando como deve ser feita a injeção de dependência e organização do serviço.
  - brf-fnc-http-sbus   : Função que recebe um payload via método post e em seguida publica numa fila do Azure Service Bus.,
  - brf-fnc-http-trigger: Função que recebe um payload via método post e faz a chamada para uma classe de serviço.                         


# Projetos do tipo frontend - Angular, React
...


# Getting Started
TODO: Guide users through getting your code up and running on their own system. In this section you can talk about:
1.	Installation process
2.	Software dependencies
3.	Latest releases
4.	API references

# Build and Test
TODO: Describe and show how to build your code and run the tests. 

# Links relacionados/material de apoio
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Visual Studio] (https://visualstudio.microsoft.com/pt-br/vs/)
- [Azure Functions](https://learn.microsoft.com/pt-br/azure/azure-functions/)
- [Azure Functions Bindings](https://learn.microsoft.com/pt-br/azure/azure-functions/functions-triggers-bindings?tabs=csharp)


