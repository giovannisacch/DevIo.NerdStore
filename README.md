# DevIo.NerdStore
Repositório utilizado para aplicação dos conceitos e acompanhamento do curso Modelagem de Domínios Ricos da plataforma desenvolvedor.io
Principais conceitos estudados durante a implementação desse projeto
- DDD
- CQRS
- Event Sourcing

COMANDOS UTILIZADOS(Projeto foi feito fora do ambiente windows sem utilizar o visual studio)
.NET CLI 

Gerar migration
 dotnet ef migrations add initial --context CatalogoContext -s DevIo.NerdStore.WebApp.Mvc -p DevIo.NerdStore.Catalogo.Data
 
 
Rodar migrations
 dotnet ef database update --context CatalogoContext -s DevIo.NerdStore.WebApp.Mvc -p DevIo.NerdStore.Catalogo.Data
