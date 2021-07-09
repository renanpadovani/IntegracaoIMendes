﻿using System;
using System.Collections.Generic;
using System.Linq;
using IntegracaoIMendes.Domain.Entities.IMendes;
using IntegracaoIMendes.Domain.Entities.Infast;
using IntegracaoIMendes.Domain.Enums;
using IntegracaoIMendes.Domain.Repositories;

namespace IntegracaoIMendes.Domain.Handlers.Infast
{
    public class ProcessamentoTributosHandler
    {
        private DataContext.InfastDataContext _context;
        private Configuracoes _config;

        public ProcessamentoTributosHandler(DataContext.InfastDataContext context,
                                            Configuracoes config)
        {
            _context = context;
            _config = config;
        }

        public void ProcessarTributos(IEnumerable<Cenarios> listaCenariosIMendes, List<Produtos> produtosInfast)
        {
            foreach (Cenarios cenario in listaCenariosIMendes)
            {
                if (cenario.DataHoraUltimoProcessamento.ToString("dd/MM/yyyy") == "01/01/1900" ||
                    DateTime.Compare(System.DateTime.Now, cenario.DataHoraUltimoProcessamento) > cenario.IntervaloDeBuscaEmDias)
                {
                    ProcessarTributosCenario(cenario, produtosInfast);
                }
            }
        }

        public void ProcessarTributosCenario(Cenarios cenario, List<Produtos> listaProdutos)
        {
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

                            contador = 0;
                            listaBuscaIMendes.Clear();
                        }

                        origemMercadoria = produto.origemMercadoria;
                    }

                    if (listaBuscaIMendes.Count > 0)
                        ProcessarTributosCenarioFinalidadeOrigem(cenario, finalidade, origemMercadoria, listaBuscaIMendes);
                }

                AtualizarDataProcessamentoCenario(cenario);
            }
        }

      
        private void ProcessarTributosCenarioFinalidadeOrigem(Cenarios cenario, EFinalidade finalidade, int origemMercadoria, List<Produtos> listaProdutos)
        {
            TributacaoIMendesHandler imendesHandler = new TributacaoIMendesHandler(
                                                         _config.Login,
                                                         _config.Senha,
                                                         (EAmbiente)_config.Ambiente,
                                                         _config.CnpjCliente,
                                                         cenario.UfCliente,
                                                         (ECodRegimeTributario)cenario.CodRegimeTributario,
                                                         cenario.RegimeTributario);

            //Pesquisa os tributos no IMendes
            TributosRetorno tribRet = imendesHandler.PesquisarTributos(finalidade,
                                                    cenario.CaracteristicasTributarias,
                                                    cenario.CFOP,
                                                    cenario.UFs,
                                                    origemMercadoria,
                                                    listaProdutos);

            //Grava os produtos no Infast
            TributacoesRepositorio tributacaoRepositorio = new TributacoesRepositorio(_context);
            TributacoesInfastHandler tributacaoInfastHandler = new TributacoesInfastHandler(tributacaoRepositorio);
            tributacaoInfastHandler.GravarTributos(cenario.ID, tribRet, listaProdutos);
        }

        private void AtualizarDataProcessamentoCenario(Cenarios cenario)
        {
            CenariosRepositorio cenariosRepositorio = new CenariosRepositorio(_context);

            CenariosHandler cenariosHandler = new CenariosHandler(cenariosRepositorio);

            cenariosHandler.AtualizarDataProcessamentoCenario(cenario.ID);
        }
    }
}
