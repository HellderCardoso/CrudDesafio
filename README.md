# Desafio Stefanini

Este projeto é um simulador de pedidos e produtos desenvolvido como parte do Desafio Stefanini. Consiste em uma API para gerenciar pedidos e produtos e uma aplicação front-end em Angular para interagir com essa API.

## Back End

O Back End é construído usando .NET Core e é composto pelos seguintes projetos:

- **Stefanini.Api.Api**: Contém os controllers e configurações externas da aplicação.
- **Stefanini.Api.Application**: Contém a camada de serviço e suas interfaces.
- **Stefanini.Api.Domain**: Contém as regras de negócio e as entidades do domínio da aplicação, bem como as interfaces de repositório.
- **Stefanini.Api.Data**: Contém a implementação do repositório usando Entity Framework e migrations.

## Front End

O Front End é desenvolvido usando Angular e está localizado no diretório `FrontEnd/StefaniniFront`. Ele serve como a interface do usuário para interagir com a API.

## Ferramentas Necessárias

Para executar o projeto, você precisará das seguintes ferramentas:

- Visual Studio 2022 ou Visual Studio Code
- Docker e Docker Compose
- Node.js e npm (para o front-end)
- Angular CLI (para o front-end)

## Configuração e Execução

### Back End

1. Clone o repositório:
    ```bash
    git clone https://github.com/HellderCardoso/DesafioStefanini
    ```

2. Navegue até o diretório do projeto e inicie o Docker Compose:
    ```bash
    cd DesafioStefanini
    docker compose up -d
    ```

### Front End

1. Navegue até o diretório `FrontEnd/StefaniniFront`:
    ```bash
    cd FrontEnd/
    ```

2. Instale as dependências do projeto:
    ```bash
    npm install
    ```

3. Instale o Angular CLI globalmente (se ainda não estiver instalado):
    ```bash
    npm install -g @angular/cli
    ```

4. Inicie o servidor de desenvolvimento:
    ```bash
    ng serve --open
    ```

   O aplicativo estará acessível na porta `4200`.

## Design Patterns e Metodologias

- **Design Patterns**: Repository, Dependency Injection
- **Metodologias e Design**: Clean Architecture, DDD

## Bibliotecas e Ferramentas

### Back End

- `Microsoft.EntityFrameworkCore`
- `Microsoft.EntityFrameworkCore.Design`
- `Microsoft.EntityFrameworkCore.SqlServer`
- `Microsoft.EntityFrameworkCore.Tools`
- `Microsoft.VisualStudio.Azure.Containers.Tools.Targets`
- `Swashbuckle.AspNetCore`

### Front End

- `@angular/cli`
- `@angular/core`
- `@angular/common`
- `@angular/forms`
- `@angular/router`

## Imagem Docker para SQL Server

A imagem Docker utilizada para o banco de dados SQL Server é:

mcr.microsoft.com/mssql/server:latest
