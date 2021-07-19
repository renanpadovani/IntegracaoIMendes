using IntegracaoIMendes.Dominio.Entidades.Infast;
using IntegracaoIMendes.Dominio.Enums;
using IntegracaoIMendes.Dominio.Manipuladores;
using IntegracaoIMendes.Dominio.Manipuladores.Infast;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntegracaoIMendes.Dominio.Servicos
{
    public class CenariosServico
    {
        private readonly ProdutosManipulador _produtosManipulador;
        private readonly ConfiguracoesManipulador _configuracaoManipulador;
        private CenariosManipulador _cenarioManipulador;

        public CenariosServico(ProdutosManipulador produtosManipulador,
                               ConfiguracoesManipulador configuracaoManipulador,
                               CenariosManipulador cenarioManipulador)
        {
            _produtosManipulador = produtosManipulador;
            _configuracaoManipulador = configuracaoManipulador;
            _cenarioManipulador = cenarioManipulador;
        }

        public IEnumerable<Cenarios> CarregarListaCenarios()
        {
            return _cenarioManipulador.CarregarListaCenarios();
        }

        public Cenarios CarregarCenario(Int64 Id)
        {
            return _cenarioManipulador.CarregarCenario(Id);
        }

        public void IncluirCenario(string ufCliente,
                                   string cfop,
                                   ECodRegimeTributario codRegimeTributario,
                                   string regimeTributario,
                                   List<EFinalidade> finalidades,
                                   List<ECaracteristicaTributaria> caracteristicasTributarias,
                                   List<string> ufs,
                                   string tipoProduto,
                                   Int16 IntervaloDeBuscaEmDias)
        {
            Cenarios novoCenario = new Cenarios();

            novoCenario.UfCliente = ufCliente;
            novoCenario.CFOP = cfop;
            novoCenario.CodRegimeTributario = codRegimeTributario;
            novoCenario.RegimeTributario = regimeTributario;
            novoCenario.Finalidades = finalidades;
            novoCenario.CaracteristicasTributarias = caracteristicasTributarias;
            novoCenario.UFs = ufs;
            novoCenario.TipoProduto = tipoProduto;
            novoCenario.IntervaloDeBuscaEmDias = IntervaloDeBuscaEmDias;

            ValidarLimiteRequisicoes(finalidades, CarregarProdutos());

            _cenarioManipulador.IncluirCenario(novoCenario);
        }

        private void ValidarLimiteRequisicoes(List<EFinalidade> finalidades, IEnumerable<Produtos> listaProdutos)
        {
            CalculoRequisicoesIMendesServico calculoRequisicoes = new CalculoRequisicoesIMendesServico();

            Configuracoes configuracao = CarregarConfiguracao();

            Int64 numeroRequisicoesNecessarias = calculoRequisicoes.RetornarNumeroRequisicoesIMendesEstimadasParaProcessamentoCenario(
                                                                                                    configuracao.QtdProdutosPorRequisicao,
                                                                                                    listaProdutos.ToList(),
                                                                                                    finalidades);

            if (numeroRequisicoesNecessarias > configuracao.QtdRequisicoesDiarias)
            {
                throw new Exception("A inclusão do cenário não pode ser realizada: Número de requisições para esse cenário (" +
                                        numeroRequisicoesNecessarias.ToString() + ") é superior ao número de requisições diárias disponíveis (" +
                                        configuracao.QtdRequisicoesDiarias.ToString() + ").");
            }
        }

        private Configuracoes CarregarConfiguracao()
        {
            return _configuracaoManipulador.CarregarConfiguracao();
        }

        private List<Produtos> CarregarProdutos()
        {
            return _produtosManipulador.PesquisarProdutos().ToList();
        }

        public void InativarCenario(Int64 Id)
        {
            _cenarioManipulador.InativarCenario(Id);
        }

        public void AtualizarDataProcessamentoCenario(Int64 Id)
        {
            _cenarioManipulador.AtualizarDataProcessamentoCenario(Id);
        }
    }
}
