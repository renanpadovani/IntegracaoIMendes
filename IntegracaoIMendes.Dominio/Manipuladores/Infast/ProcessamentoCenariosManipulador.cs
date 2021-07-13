using System;
using System.Collections.Generic;
using System.Linq;
using IntegracaoIMendes.Dominio.Entidades.IMendes;
using IntegracaoIMendes.Dominio.Entidades.Infast;
using IntegracaoIMendes.Dominio.Enums;
using IntegracaoIMendes.Dominio.Servicos;
using IntegracaoIMendes.Dominio.Repositorios.Interfaces;

namespace IntegracaoIMendes.Dominio.Manipuladores.Infast
{
    public class ProcessamentoCenariosManipulador
    {
        private IProcessamentoCenariosRepositorio _repositorioProcessamento;
        private ICenariosRepositorio _repositorioCenario;
        private ITributacoesRepositorio _repositorioTributacoes;
        private IProdutosRepositorio _repositorioProdutos;
        private Configuracoes _config;

        public ProcessamentoCenariosManipulador(IProcessamentoCenariosRepositorio repositorioProcessamentoCenario,
                                                ICenariosRepositorio repositorioCenario,
                                                ITributacoesRepositorio repositorioTributacoes,
                                                IProdutosRepositorio repositorioProdutos,
                                                Configuracoes config)
        {
            _repositorioProcessamento = repositorioProcessamentoCenario;
            _repositorioCenario = repositorioCenario;
            _repositorioTributacoes = repositorioTributacoes;
            _repositorioProdutos = repositorioProdutos;
            _config = config;
        }

        public void ProcessarCenarios(IEnumerable<Cenarios> listaCenarios, List<Produtos> listaProdutos)
        {
            foreach (Cenarios cenario in listaCenarios)
            {
                if (cenario.DataHoraUltimoProcessamento.ToString("dd/MM/yyyy") == "01/01/1900" ||
                    DateTime.Compare(System.DateTime.Now, cenario.DataHoraUltimoProcessamento) > cenario.IntervaloDeBuscaEmDias)
                {
                    Int64 numeroRequicoesEstimadas = RetornarNumeroRequisicoesIMendesEstimadasParaProcessamentoCenario(cenario, listaProdutos);
                    Int64 numeroRequisicoesDisponiveis = (_config.QtdRequisicoesDiarias - RetornarNumeroRequisicoesRealizadasIMendes(System.DateTime.Now));

                    if (numeroRequisicoesDisponiveis > numeroRequicoesEstimadas)
                        ProcessarCenario(cenario, listaProdutos);
                    else
                        CriarLogProcessamentoCenario(cenario, listaProdutos, 0, "Número de requisições necessárias (" + numeroRequicoesEstimadas.ToString() + ") superior ao total de requisições disponíveis (" + numeroRequisicoesDisponiveis.ToString() + ").");
                }
            }  
        }

        public Int64 RetornarNumeroRequisicoesIMendesEstimadasParaProcessamentoCenario(Cenarios cenario, List<Produtos> listaProdutos)
        {
            CalculoRequisicoesIMendesServico calculoRequisicoes = new CalculoRequisicoesIMendesServico();

            return calculoRequisicoes.RetornarNumeroRequisicoesIMendesEstimadasParaProcessamentoCenario(_config.QtdProdutosPorRequisicao,
                                                                                                        listaProdutos,
                                                                                                        cenario.Finalidades);
        }

        public Int64 RetornarNumeroRequisicoesRealizadasIMendes(DateTime data)
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
                            contador >= _config.QtdProdutosPorRequisicao)
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

                CriarLogProcessamentoCenario(cenario, listaProdutos, qtdRequisicoes, "");

                AtualizarDataProcessamentoCenario(cenario);
            }
        }

        private void ProcessarTributosCenarioFinalidadeOrigem(Cenarios cenario, EFinalidade finalidade, int origemMercadoria, List<Produtos> listaProdutos)
        {
            TributacaoIMendesManipulador imendesManipulador = new TributacaoIMendesManipulador(
                                                         _config.Login,
                                                         _config.Senha,
                                                         (EAmbiente)_config.Ambiente,
                                                         _config.CnpjCliente,
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
                CriarLogProcessamentoCenario(cenario, 
                                             listaProdutos, 
                                             0, 
                                             "Erro ao Processar Cenário: " + cenario.ID.ToString() + " - Finalidade: " + finalidade.ToString() + " - Origem Produtos: " + origemMercadoria.ToString() + ": " + tribRet.MensagemErro);
            }
        }

        private void AtualizarDataProcessamentoCenario(Cenarios cenario)
        {
            CenariosManipulador cenariosManipulador = new CenariosManipulador(_repositorioCenario, _repositorioProdutos, _config);

            cenariosManipulador.AtualizarDataProcessamentoCenario(cenario.ID);
        }

        private void CriarLogProcessamentoCenario(Cenarios cenario, List<Produtos> listaProdutos, int qtdRequisicoesRealizadas, string mensagem)
        {
            ProcessamentoCenarios logProcessamento = new ProcessamentoCenarios();

            logProcessamento.EmpresaID = 1;
            logProcessamento.FilialID = 1;
            logProcessamento.Data = System.DateTime.Now;
            logProcessamento.CenarioID = cenario.ID;
            logProcessamento.Finalidades = cenario.Finalidades;
            logProcessamento.CaracteristicasTributarias = cenario.CaracteristicasTributarias;
            logProcessamento.UFs = cenario.UFs;
            logProcessamento.QtdProdutos = listaProdutos.Count;
            logProcessamento.QtdOrigensProdutos = listaProdutos.Select(x => x.origemMercadoria).Distinct().Count();
            logProcessamento.QtdRequisicoesRealizadas = qtdRequisicoesRealizadas;
            logProcessamento.Mensagem = mensagem;

            _repositorioProcessamento.IncluirProcessamentoCenario(logProcessamento);
        }
    }
}
