# FinancasApp

O **FinancasApp** é uma solução para gerenciamento financeiro, que inclui uma API para controle de categorias e contas (a pagar e a receber) de usuários, além de uma interface frontend desenvolvida em **Blazor**. O projeto segue princípios modernos de arquitetura e desenvolvimento, como DDD (Domain Driven Design), autenticação com JWT, testes automatizados e containerização com Docker para garantir portabilidade e escalabilidade.

## Tecnologias Utilizadas

### ASP.NET API 8
A API foi desenvolvida usando **ASP.NET Core 8**, um framework robusto para a construção de APIs RESTful, que oferece suporte a rotas, injeção de dependências, e excelente performance para aplicações de alta escala.  
[Documentação do ASP.NET Core](https://learn.microsoft.com/aspnet/core)

### Entity Framework
**Entity Framework Core** é utilizado como o ORM para o mapeamento de objetos do .NET para o banco de dados, permitindo que a interação com dados seja realizada de forma simplificada e eficiente. O **FinancasApp** utiliza a abordagem **Code First**, na qual o modelo de domínio é usado para gerar automaticamente o esquema do banco de dados.  
[Documentação do Entity Framework Core](https://learn.microsoft.com/ef/core)

### JWT (JSON Web Token)
A autenticação e controle de acesso no **FinancasApp** são realizados através de **JWT**, que oferece uma forma segura e compacta de transmitir informações entre o cliente e a API, garantindo proteção aos dados e aos recursos do sistema.  
[Documentação do JWT](https://jwt.io/introduction/)

### Blazor
O frontend do **FinancasApp** é desenvolvido com **Blazor**, uma tecnologia de interface de usuário da Microsoft que permite a criação de aplicativos web interativos usando C# em vez de JavaScript. Blazor combina o poder do .NET com a flexibilidade das aplicações web, tornando o desenvolvimento mais eficiente e a experiência do usuário mais rica.  
[Documentação do Blazor](https://learn.microsoft.com/aspnet/core/blazor)

### Docker
**Docker** é utilizado para containerização da aplicação, permitindo que o **FinancasApp** seja facilmente implantado em qualquer ambiente, independente da infraestrutura local. Isso facilita a portabilidade, consistência entre ambientes (desenvolvimento, homologação e produção) e melhora a escalabilidade da aplicação.  
[Documentação do Docker](https://docs.docker.com/get-started/)

### DDD (Domain Driven Design)
O projeto segue o padrão **DDD (Domain Driven Design)**, que se baseia em modelar o domínio do negócio diretamente no código. Isso garante que as regras e processos de negócios sejam claramente refletidos na estrutura da aplicação, facilitando o desenvolvimento e a manutenção.  
[Documentação sobre DDD](https://martinfowler.com/bliki/DomainDrivenDesign.html)

### Testes com xUnit
Os testes de unidade e integração são implementados com **xUnit**, um framework de testes popular e leve para .NET, que facilita a criação e execução de testes automatizados, garantindo a qualidade e a confiabilidade do sistema.  
[Documentação do xUnit](https://xunit.net/)

## Licença

Este projeto está licenciado sob os termos da [MIT License](LICENSE).
