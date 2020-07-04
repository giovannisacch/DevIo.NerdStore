using DevIo.NerdStore.Catalogo.Application.Services;
using DevIo.NerdStore.Catalogo.Domain;
using DevIo.NerdStore.Catalogo.Domain.events;
using DevIo.NerdStore.Core.Mediatr;
using DevIo.NerdStore.Data;
using DevIo.NerdStore.Data.Repositories;
using DevIo.NerdStore.Vendas.Application.Commands;
using DevIo.NerdStore.Vendas.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DevIo.NerdStore.WebApp.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Mediator
            services.AddScoped<IMediatrHandler, MediatrHandler>();
            
            // Catalogo
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<CatalogoContext>();

            services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventHandler>();

            // services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();
            
            // services.AddScoped<IPedidoRepository, IPedidoRepository>()
        }
    }
}