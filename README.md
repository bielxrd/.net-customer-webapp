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
curl --location 'localhost:5242/api/customer' \
--header 'Content-Type: application/json' \
--data-raw '{
  "name": "teste",
  "phone": "(11) 00000-0000",
  "addresses": [
    {
      "street": "Rua Engenheiro",
      "state": "SP",
      "city": "Sao Paulo"
    }
  ],
  "emails": [
    {
      "email_address": "teste@hotmail.com"
    }
  ]
}
'

```

# 2. GET /api/customers
Obtém a lista de clientes.

## Query Parameters:

### pageNumber (opcional): Número da página para paginação.
### pageSize (opcional): Tamanho da página para paginação.

```
curl --location 'localhost:5242/api/customer?pageNumber=1&pageSize=5'
```
Response:

#### 200 OK: Retorna uma lista de clientes com detalhes.

# 3. GET /api/customers/{id}
Obtém os detalhes de um cliente específico pelo ID.

### Path Parameter:

#### id: ID do cliente.


```
curl --location 'localhost:5242/api/customer/011ffbb7-6470-4685-bc60-a8137799ff02'
```

obs: substituia o id pelo seu id do seu cliente cadastrado.

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

