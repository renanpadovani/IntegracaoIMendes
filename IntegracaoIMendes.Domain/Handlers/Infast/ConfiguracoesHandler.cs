using IntegracaoIMendes.Domain.Entities.Infast;
using IntegracaoIMendes.Domain.Enums;
using IntegracaoIMendes.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoIMendes.Domain.Handlers.Infast
{
    public class ConfiguracoesHandler
    {
        private readonly ConfiguracoesRepositorio _repositorio;

        public ConfiguracoesHandler(ConfiguracoesRepositorio repositorio)
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
                                                int qtdProdutosPorRequisicao,
                                                int qtdUFsporRequisicao,
                                                int qtdCaracteristicasTributariasPorRequisicao)
        {
            Configuracoes config = new Configuracoes();

            config.Login = loginIMendes;
            config.Senha = senhaIMendes;
            config.Ambiente = ambiente;
            config.CnpjCliente = cnpjCliente;
            config.QtdProdutosPorRequisicao = qtdProdutosPorRequisicao;
            config.QtdUFsporRequisicao = qtdUFsporRequisicao;
            config.QtdCaracteristicasTributariasPorRequisicao = qtdCaracteristicasTributariasPorRequisicao;

            config.ID = _repositorio.IncluirConfiguracao(config);

            return config;
        }
    }
}
