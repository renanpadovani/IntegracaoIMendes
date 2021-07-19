using Microsoft.Extensions.DependencyInjection;
using IntegracaoIMendes.Dominio.ContextoDados;
using IntegracaoIMendes.Dominio.Repositorios;
using IntegracaoIMendes.Dominio.Servicos;
using IntegracaoIMendes.Dominio.Repositorios.Interfaces;
using IntegracaoIMendes.Dominio.Manipuladores.Infast;
using IntegracaoIMendes.Dominio.Manipuladores;

namespace IntegracaoIMendes.Apresentacao
{
    public static class Fabrica
    {
        public static ServiceProvider container = RegistrarServices();

        public static ServiceProvider RegistrarServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<InfastContextoDados, InfastContextoDados>();
            services.AddTransient<ICenariosRepositorio, CenariosRepositorio>();
            services.AddTransient<IProdutosRepositorio, ProdutosRepositorio>();
            services.AddTransient<IConfiguracoesRepositorio, ConfiguracoesRepositorio>();
            services.AddTransient<IProcessamentoCenariosRepositorio, ProcessamentoCenariosRepositorio>();
            services.AddTransient<ITributacoesRepositorio, TributacoesRepositorio>();
            services.AddTransient<ConfiguracoesManipulador, ConfiguracoesManipulador>();
            services.AddTransient<ProdutosManipulador, ProdutosManipulador>();
            services.AddTransient<CenariosManipulador, CenariosManipulador>();
            services.AddTransient<CenariosServico, CenariosServico>();
            services.AddTransient<ProcessamentoCenariosServico, ProcessamentoCenariosServico>();

            return services.BuildServiceProvider();
        }
    }
}
