CRUD Cafeteria API

API simples desenvolvida em C# com .NET para registrar e gerenciar solicitações de manutenção em uma cafeteria.

Sobre o projeto

A ideia do projeto é organizar pedidos de manutenção de máquinas (como cafeteiras), permitindo cadastrar, visualizar, atualizar e excluir solicitações.

Foi desenvolvido pensando em melhorar o controle desses registros, que normalmente seriam feitos de forma manual.

Tecnologias

* C#
* .NET
* Entity Framework Core
* Banco de dados InMemory
* Swagger

Estrutura

O projeto está dividido em camadas:
Controller → recebe as requisições
Service → aplica as regras de negócio
Repository → faz acesso ao banco
DTOs → controlam entrada e saída de dados
Entity → representa o modelo do banco

Fluxo

1. A requisição chega no controller
2. Os dados são tratados no service
3. O repository salva ou busca no banco
4. A resposta é retornada

Endpoints

GET /api/solicitacoes
GET /api/solicitacoes/{id}
POST /api/solicitacoes
PUT /api/solicitacoes/{id}
DELETE /api/solicitacoes/{id}


OS TESTES UNITARIOS ESTÂO EM:
https://github.com/kaeve1/cafeCrudTests

