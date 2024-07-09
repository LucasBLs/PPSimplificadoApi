# PPSimplificadoApi

![C#](https://img.shields.io/badge/C%23-12.0-purple?style=for-the-badge&logo=c-sharp)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-8.6-blueviolet?style=for-the-badge&logo=dotnet)
![Entity Framework Core](https://img.shields.io/badge/EF%20Core-8.6-success?style=for-the-badge&logo=nuget)
![Swagger](https://img.shields.io/badge/Swagger-OpenAPI-brightgreen?style=for-the-badge&logo=swagger)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-red?style=for-the-badge&logo=microsoftsqlserver)
![MIT License](https://img.shields.io/badge/License-MIT-blue?style=for-the-badge&logo=mit)

## Descrição

PPSimplificadoApi é uma API desenvolvida em ASP.NET Core para a prática, se baseando no [Desafio Backend do PicPay](https://github.com/PicPay/picpay-desafio-backend), utilizando SQL Server como banco de dados. Este projeto foi desenvolvido para fins de prática e para ser um exemplo público no GitHub.

## Requisitos

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [Swagger](https://swagger.io/)

## Instalação

1. Clone o repositório:

    ```sh
    git clone https://github.com/LucasBLs/PPSimplificadoApi.git
    cd PPSimplificadoApi
    ```

2. Configure a string de conexão com o SQL Server no arquivo `appsettings.json`:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_user;Password=your_password;"
      }
    }
    ```

3. Execute as migrações do Entity Framework para criar o banco de dados:

    ```sh
    dotnet ef database update
    ```

4. Execute o projeto:

    ```sh
    dotnet run
    ```

## Uso

Após iniciar a aplicação, você pode acessar a documentação Swagger para explorar os endpoints disponíveis:

http://localhost:5000/swagger


## Endpoints

### Transaction

- **POST /api/Transaction/transfer**: Transfere um valor entre usuários

### User

- **POST /api/User**: Cria um novo usuário
- **PUT /api/User**: Atualiza um usuário existente
- **DELETE /api/User/{id}**: Exclui um usuário pelo ID
- **GET /api/User/{id}**: Obtém os detalhes de um usuário específico pelo ID
- **GET /api/User/get-all**: Lista todos os usuários
- **GET /api/User/email/{email}**: Obtém um usuário pelo email
- **GET /api/User/document/{document}**: Obtém um usuário pelo documento
- **GET /api/User/type/{type}**: Obtém usuários por tipo

## Schemas

- **CreateUserRequest**: Estrutura para criar um usuário
- **EUser**: Enumeração de tipos de usuário
- **TransferRequest**: Estrutura para realizar uma transferência
- **UpdateUserRequest**: Estrutura para atualizar um usuário

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.
