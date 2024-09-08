# Projeto Customers API

API para gerenciamento de clientes.

## Pré-requisitos

- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) ou superior
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)



## MER (Modelo Entidade Relacionamento)

![Customers-MER](https://github.com/user-attachments/assets/81ec82a4-d11c-4960-9f69-3286780fb0b2)

## Configuração do Projeto

### Clonando o Repositório

1. **Clone o repositório** 
   ```bash
   git clone https://github.com/seu-usuario/seu-repositorio.git
   ```

   
Selecione o arquivo customers-api.sln


### Rodar comando docker para criação do banco de dados



1. **Acessar a pasta da Web Application**

```
   cd .\CustomersWebApp\
```

2. **Rodar comando docker**
```
docker-compose up-d
```

# Rodar o projeto em http preferencialmente

obs: a API cria para você o database automaticamente.

## Rotas da API
A API possui as seguintes rotas principais:

### 1. POST /api/customers
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

O primeiro email da lista de emails, e o primeiro endereço da lista de endereços, serão respectivamente o email principal e endereço principal atrelado ao cliente.

# 2. GET /api/customers (paginação)
Obtém a lista de clientes.

## Query Parameters:

### pageNumber (opcional): Número da página para paginação.
### pageSize (opcional): Tamanho da página para paginação.

Caso não seja informado os paramêtros pageNumber e pageSize, o valor padrão será, respectivamente, 1 e 5.

```
curl --location 'localhost:5242/api/customer?pageNumber=1&pageSize=5'
```
Response:

#### 200 OK: Retorna uma lista de clientes com paginação.

# 3. GET /api/customers/{id}
Obtém os detalhes de um cliente específico pelo ID.

### Path Parameter:

#### id: ID do cliente.

```
curl --location 'localhost:5242/api/customer/011ffbb7-6470-4685-bc60-a8137799ff02'
```

obs: substituia o id pelo id do seu cliente.

Response:

#### 200 OK: Retorna os detalhes do cliente.
#### 404 Not Found: Retorna erro se o cliente com o ID especificado não for encontrado.

## Pattern utilizado

### Clean Architecture

O projeto segue a **Clean Architecture** com o propósito de manter uma separação clara de responsabilidade do sistema nas seguintes camadas:

- **Camada de Domínio**: Lógica de negócios e entidades.
- **Camada de Aplicação**: Casos de uso e lógica de aplicação.
- **Camada de Infraestrutura**: Acesso ao banco de dados.
- **Camada de Apresentação**: Contém as controllers.

### SOLID

O projeto aplica os seguintes princípios SOLID:

- **SRP (Single Responsibility Principle)**: Cada classe tem uma única responsabilidade e é responsável por uma única parte da funcionalidade do sistema.
- **DIP (Dependency Inversion Principle)**: As dependências são invertidas para depender das classes de abstrações (interfaces).

