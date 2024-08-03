# Projeto ASP.NET API com .NET 8, DDD, Entity Framework e XUnit

Este é um projeto de exemplo que demonstra a construção de uma API usando ASP.NET Core com .NET 8, seguindo os princípios de Domain-Driven Design (DDD), usando Entity Framework para acesso ao banco de dados e XUnit para testes de integração.

## Estrutura do Projeto

O projeto está estruturado da seguinte maneira:

- **Domain**: Contém as entidades, agregados, repositórios, interfaces e serviços do domínio.
- **Application**: Contém a lógica de aplicação e as interfaces para comunicação com o domínio.
- **Infrastructure**: Contém a implementação de repositórios, o contexto do Entity Framework e outras infraestruturas como serviços externos.
- **API**: Contém os controladores e configurações do ASP.NET Core.
- **Tests**: Contém os testes de integração usando XUnit.

## Tecnologias Utilizadas

- .NET 8
- ASP.NET Core
- Entity Framework Core
- XUnit
- Swagger

## Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)