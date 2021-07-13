using IntegracaoIMendes.Dominio.ContextoDados;
using IntegracaoIMendes.Dominio.Entidades.Infast;
using IntegracaoIMendes.Dominio.Enums;
using IntegracaoIMendes.Dominio.Repositorios;

namespace IntegracaoIMendes.Dominio.Manipuladores.Infast
{
    public class ConfiguracoesManipulador
    {
        private ConfiguracoesRepositorio _repositorio;

        public ConfiguracoesManipulador(ConfiguracoesRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Configuracoes CarregarConfiguracao()
        {
            return _repositorio.CarregarConfiguracao();
        }

        public Configuracoes IncluirConfiguracao(string loginIMendes, 
                                                string senhaIMendes,
                                                EAmbiente ambiente,
                                                string cnpjCliente,
                                                int qtdRequisicoesDiariasIMendes,
                                                int qtdProdutosPorRequisicao,
                                                int qtdUFsporRequisicao,
                                                int qtdCaracteristicasTributariasPorRequisicao)
        {
            Configuracoes config = new Configuracoes();

            config.Login = loginIMendes;
            config.Senha = senhaIMendes;
            config.Ambiente = ambiente;
            config.CnpjCliente = cnpjCliente;
            config.QtdRequisicoesDiarias = qtdRequisicoesDiariasIMendes;
            config.QtdProdutosPorRequisicao = qtdProdutosPorRequisicao;
            config.QtdUFsporRequisicao = qtdUFsporRequisicao;
            config.QtdCaracteristicasTributariasPorRequisicao = qtdCaracteristicasTributariasPorRequisicao;

            config.ID = _repositorio.IncluirConfiguracao(config);

            return config;
        }
    }
}
