# Projeto Customers API

Este projeto é uma API para gerenciamento de clientes, com validação de entrada e estruturação de dados.

## Pré-requisitos

- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) ou superior
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Configuração do Projeto

### Clonando o Repositório

1. **Clone o repositório** usando o Git. Abra o terminal (ou prompt de comando) e execute:

   ```bash
   git clone https://github.com/seu-usuario/seu-repositorio.git
   ```

   
Selecione o arquivo customers-api.sln


Rotas da API
A API possui as seguintes rotas principais:

# 1. POST /api/customers
Cria um novo cliente.

```
{
  "name": "Nome do Cliente",
  "phone": "(11) 98535-6473",
  "addresses": [
    {
      "street": "Rua Exemplo",
      "city": "Cidade Exemplo",
      "state": "SP",
      "postalCode": "00000-000"
    }
  ],
  "emails": [
    {
      "emailAddress": "email@exemplo.com"
    }
  ]
}

```

# 2. GET /api/customers
Obtém a lista de clientes.

## Query Parameters:

### pageNumber (opcional): Número da página para paginação.
### pageSize (opcional): Tamanho da página para paginação.
Response:

#### 200 OK: Retorna uma lista de clientes com detalhes.

# 3. GET /api/customers/{id}
Obtém os detalhes de um cliente específico pelo ID.

### Path Parameter:

#### id: ID do cliente.
Response:

#### 200 OK: Retorna os detalhes do cliente.
#### 404 Not Found: Retorna erro se o cliente com o ID especificado não for encontrado.

## Clean Architecture

O projeto segue a **Clean Architecture**, que ajuda a manter a separação clara entre diferentes camadas do sistema. Isso inclui:

- **Camada de Domínio**: Contém a lógica de negócios e entidades.
- **Camada de Aplicação**: Contém os casos de uso e lógica de aplicação.
- **Camada de Infraestrutura**: Contém a implementação dos detalhes de acesso a dados e.
- **Camada de Apresentação**: Contém as controllers.

## SOLID

O projeto aplica os seguintes princípios SOLID:

- **SRP (Single Responsibility Principle)**: Cada classe tem uma única responsabilidade e é responsável por uma única parte da funcionalidade do sistema.
- **DIP (Dependency Inversion Principle)**: As dependências são invertidas para depender das classes de abstrações (interfaces).

