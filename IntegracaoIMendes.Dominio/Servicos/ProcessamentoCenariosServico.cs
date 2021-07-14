using IntegracaoIMendes.Dominio.Entidades.IMendes;
using IntegracaoIMendes.Dominio.Entidades.Infast;
using IntegracaoIMendes.Dominio.Enums;
using IntegracaoIMendes.Dominio.Manipuladores;
using IntegracaoIMendes.Dominio.Manipuladores.Infast;
using IntegracaoIMendes.Dominio.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntegracaoIMendes.Dominio.Servicos
{
    public class ProcessamentoCenariosServico
    {
        private readonly IProcessamentoCenariosRepositorio _repositorioProcessamento;
        private readonly ICenariosRepositorio _repositorioCenario;
        private readonly ITributacoesRepositorio _repositorioTributacoes;
        private readonly IProdutosRepositorio _repositorioProdutos;
        private readonly IConfiguracoesRepositorio _repositorioConfiguracoes;
        private Configuracoes _configuracao;
        ProcessamentoCenariosManipulador _processamentoCenarioManipulador;

        public ProcessamentoCenariosServico(IProcessamentoCenariosRepositorio repositorioProcessamentoCenario,
                                            ICenariosRepositorio repositorioCenario,
                                            ITributacoesRepositorio repositorioTributacoes,
                                            IProdutosRepositorio repositorioProdutos,
                                            IConfiguracoesRepositorio repositorioConfiguracoes)
        {
            _repositorioProcessamento = repositorioProcessamentoCenario;
            _repositorioCenario = repositorioCenario;
            _repositorioTributacoes = repositorioTributacoes;
            _repositorioProdutos = repositorioProdutos;
            _repositorioConfiguracoes = repositorioConfiguracoes;
            _processamentoCenarioManipulador = new ProcessamentoCenariosManipulador(repositorioProcessamentoCenario);
            _configuracao = CarregarConfiguracao();
        }

        public void ProcessarCenarios()
        {
            IEnumerable<Cenarios> listaCenarios = CarregarCenarios().OrderBy(x => x.DataHoraUltimoProcessamento);

            if (listaCenarios.Count<Cenarios>() == 0)
            {
                //listaMensagens.Add("Nenhum cenário localizado para integração.");
                return;
            }

            List<Produtos> listaProdutos = CarregarProdutosParaIntegracao();

            if (listaProdutos.Count == 0)
            {
                //listaMensagens.Add("Nenhum produto localizado para integração.");
                return;
            }


            foreach (Cenarios cenario in listaCenarios)
            {
                if (cenario.DataHoraUltimoProcessamento.ToString("dd/MM/yyyy") == "01/01/1900" ||
                    DateTime.Compare(System.DateTime.Now, cenario.DataHoraUltimoProcessamento) > cenario.IntervaloDeBuscaEmDias)
                {
                    Int64 numeroRequicoesEstimadas = RetornarNumeroRequisicoesIMendesEstimadasParaProcessamentoCenario(cenario, listaProdutos);
                    Int64 numeroRequisicoesDisponiveis = (_configuracao.QtdRequisicoesDiarias - RetornarNumeroRequisicoesRealizadasIMendes(System.DateTime.Now));

                    if (numeroRequisicoesDisponiveis > numeroRequicoesEstimadas)
                        ProcessarCenario(cenario, listaProdutos);
                    else
                        _processamentoCenarioManipulador.CriarLogProcessamentoCenario(cenario, listaProdutos, 0, "Número de requisições necessárias (" + numeroRequicoesEstimadas.ToString() + ") superior ao total de requisições disponíveis (" + numeroRequisicoesDisponiveis.ToString() + ").");
                }
            }
        }

        private Configuracoes CarregarConfiguracao()
        {
            ConfiguracoesManipulador configuracoesManipulador = new ConfiguracoesManipulador(_repositorioConfiguracoes);

            return configuracoesManipulador.CarregarConfiguracao();
        }

        private IEnumerable<Cenarios> CarregarCenarios()
        {
            CenariosManipulador cenarioManipulador = new CenariosManipulador(_repositorioCenario);

            return cenarioManipulador.CarregarListaCenarios();
        }

        private List<Produtos> CarregarProdutosParaIntegracao(Int64 produtoId = 0, string tipoClassificacaoProdutos = "")
        {
            ProdutosManipulador produtosInfastManipulador = new ProdutosManipulador(_repositorioProdutos);

            return produtosInfastManipulador.PesquisarProdutos(produtoId, tipoClassificacaoProdutos).ToList();
        }

        private Int64 RetornarNumeroRequisicoesIMendesEstimadasParaProcessamentoCenario(Cenarios cenario, List<Produtos> listaProdutos)
        {
            CalculoRequisicoesIMendesServico calculoRequisicoes = new CalculoRequisicoesIMendesServico();

            return calculoRequisicoes.RetornarNumeroRequisicoesIMendesEstimadasParaProcessamentoCenario(_configuracao.QtdProdutosPorRequisicao,
                                                                                                        listaProdutos,
                                                                                                        cenario.Finalidades);
        }

        private Int64 RetornarNumeroRequisicoesRealizadasIMendes(DateTime data)
        {
            return _repositorioProcessamento.RetornarNumeroRequisicoesConsumidas(data);
        }

        private void ProcessarCenario(Cenarios cenario, List<Produtos> listaProdutos)
        {
            int qtdRequisicoes = 0;

            if (listaProdutos.Count > 0)
            {
                foreach (EFinalidade finalidade in cenario.Finalidades)
                {
                    int contador = 0;
                    int origemMercadoria = listaProdutos[0].origemMercadoria;
                    List<Produtos> listaBuscaIMendes = new List<Produtos>();

                    foreach (Produtos produto in listaProdutos)
                    {
                        contador++;

                        Produtos prodBusca = new Produtos();

                        prodBusca.empresaID = produto.empresaID;
                        prodBusca.filialID = produto.filialID;
                        prodBusca.produtoID = produto.produtoID;
                        prodBusca.codigo = produto.codigo;
                        prodBusca.codInterno = produto.codInterno;
                        prodBusca.descricao = produto.descricao;
                        prodBusca.codImendes = produto.codImendes;
                        prodBusca.ncm = produto.ncm;
                        prodBusca.origemMercadoria = produto.origemMercadoria;

                        listaBuscaIMendes.Add(prodBusca);

                        if (origemMercadoria != produto.origemMercadoria ||
                            contador >= _configuracao.QtdProdutosPorRequisicao)
                        {
                            ProcessarTributosCenarioFinalidadeOrigem(cenario, finalidade, origemMercadoria, listaBuscaIMendes);

                            qtdRequisicoes++;
                            contador = 0;
                            listaBuscaIMendes.Clear();
                        }

                        origemMercadoria = produto.origemMercadoria;
                    }

                    if (listaBuscaIMendes.Count > 0)
                    {
                        ProcessarTributosCenarioFinalidadeOrigem(cenario, finalidade, origemMercadoria, listaBuscaIMendes);
                        qtdRequisicoes++;
                    }
                }

                _processamentoCenarioManipulador.CriarLogProcessamentoCenario(cenario, listaProdutos, qtdRequisicoes, "");

                AtualizarDataProcessamentoCenario(cenario);
            }
        }

        private void ProcessarTributosCenarioFinalidadeOrigem(Cenarios cenario, EFinalidade finalidade, int origemMercadoria, List<Produtos> listaProdutos)
        {
            TributacaoIMendesManipulador imendesManipulador = new TributacaoIMendesManipulador(
                                                            _configuracao.Login,
                                                            _configuracao.Senha,
                                                            (EAmbiente)_configuracao.Ambiente,
                                                            _configuracao.CnpjCliente,
                                                            cenario.UfCliente,
                                                            (ECodRegimeTributario)cenario.CodRegimeTributario,
                                                            cenario.RegimeTributario);

            //Pesquisa os tributos no IMendes
            TributosRetorno tribRet = imendesManipulador.PesquisarTributos(finalidade,
                                                    cenario.CaracteristicasTributarias,
                                                    cenario.CFOP,
                                                    cenario.UFs,
                                                    origemMercadoria,
                                                    listaProdutos);

            if (tribRet.ErroRetorno == false)
            {
                //Grava os produtos no Infast
                TributacoesInfastManipulador tributacaoInfastManipulador = new TributacoesInfastManipulador(_repositorioTributacoes);
                tributacaoInfastManipulador.GravarTributos(cenario.ID, tribRet, listaProdutos);
            }
            else
            {
                _processamentoCenarioManipulador.CriarLogProcessamentoCenario(cenario,
                                             listaProdutos,
                                             0,
                                             "Erro ao Processar Cenário: " + cenario.ID.ToString() + " - Finalidade: " + finalidade.ToString() + " - Origem Produtos: " + origemMercadoria.ToString() + ": " + tribRet.MensagemErro);
            }
        }

        private void AtualizarDataProcessamentoCenario(Cenarios cenario)
        {
            CenariosManipulador cenariosManipulador = new CenariosManipulador(_repositorioCenario);

            cenariosManipulador.AtualizarDataProcessamentoCenario(cenario.ID);
        }
    }
}
