# Documentação de desenvolvimento do projeto DDDCommerceBCCC

## Preparando o ambiente de desenvolvimento 

Esse projeto foi desenvolvido usando o editor de código Visual Studio Code, e para facilitar alguns dos processos para a organização da estrutura de pastas, criar as soluções e conectar cada projeto, utilizei alguns comandos no terminal.

**Organização das pastas:**
<br>
📂 **DDDCommerceBCC** (Solução)
<br>
----📁 **DDDCommerceBCC.Application** (Regras de aplicação - Use Cases)
<br>
----📁 **DDDCommerceBCC.Domain** (Regras de negócio - Entidades e Repositórios)
<br>
----📁 **DDDCommerceBCC.Infrastructure** (Acesso a banco de dados - Implementação do Repository Pattern)
<br>
----📁 **DDDCommerceBCC.API** (Projeto da API - Controllers e Configurações)

No terminal do VScode, digite esses comandos:

**Criar a solução e cada projeto**
```
mkdir DDDCommerceBCC
cd DDDCommerceBCC
dotnet new sln
dotnet new webapi -o DDDCommerceBCC.API
dotnet new classlib -o DDDCommerceBCC.Application
dotnet new classlib -o DDDCommerceBCC.Domain
dotnet new classlib -o DDDCommerceBCC.Infrastructure
```

**Criar a solução para cada projeto**

```
dotnet sln add DDDCommerceBCC.API
dotnet sln add DDDCommerceBCC.Application
dotnet sln add DDDCommerceBCC.Domain
dotnet sln add DDDCommerceBCC.Infrastructure
```

**Conectar os projetos entre si**

```
dotnet add DDDCommerceBCC.API reference DDDCommerceBCC.Application
dotnet add DDDCommerceBCC.Application reference DDDCommerceBCC.Domain
dotnet add DDDCommerceBCC.Infrastructure reference DDDCommerceBCC.Domain
dotnet add DDDCommerceBCC.Application reference DDDCommerceBCC.Infrastructure
dotnet add DDDCommerceBCC.API reference DDDCommerceBCC.Infrastructure
```

## Desenvolvimento do Projeto

