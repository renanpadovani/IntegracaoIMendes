using IntegracaoIMendes.Dominio.Entidades.Infast;
using IntegracaoIMendes.Dominio.Enums;
using System;
using System.Collections.Generic;
using IntegracaoIMendes.Dominio.Servicos;
using System.Linq;
using IntegracaoIMendes.Dominio.Repositorios.Interfaces;

namespace IntegracaoIMendes.Dominio.Manipuladores.Infast
{
    public class CenariosManipulador
    {
        private readonly ICenariosRepositorio _cenarioRepositorio;
        private readonly IProdutosRepositorio _produtoRepositorio;
        private readonly Configuracoes _configuracao;

        public CenariosManipulador(ICenariosRepositorio cenarioRepositorio,
                                   IProdutosRepositorio produtoRepositorio,
                                   Configuracoes configuracao)
        {
            _cenarioRepositorio = cenarioRepositorio;
            _produtoRepositorio = produtoRepositorio;
            _configuracao = configuracao;
        }

        public IEnumerable<Cenarios> CarregarListaCenarios()
        {
            return _cenarioRepositorio.PesquisarCenarios();
        }

        public Cenarios CarregarCenario(Int64 Id)
        {
            return _cenarioRepositorio.CarregarCenario(Id);
        }

        public Cenarios IncluirCenario(
                                    string ufCliente,
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

            novoCenario.Validar();

            ValidarLimiteRequisicoes(finalidades, CarregarProdutos());
                
            novoCenario.ID = _cenarioRepositorio.IncluirCenario(novoCenario);

            return novoCenario;
        }

        private void ValidarLimiteRequisicoes(List<EFinalidade> finalidades, IEnumerable<Produtos> listaProdutos)
        {
            CalculoRequisicoesIMendesServico calculoRequisicoes = new CalculoRequisicoesIMendesServico();

            Int64 numeroRequisicoesNecessarias = calculoRequisicoes.RetornarNumeroRequisicoesIMendesEstimadasParaProcessamentoCenario(
                                                                                                    _configuracao.QtdProdutosPorRequisicao,
                                                                                                    listaProdutos.ToList(),
                                                                                                    finalidades);

            if (numeroRequisicoesNecessarias > _configuracao.QtdRequisicoesDiarias)
            {
                throw new Exception("A inclusão do cenário não pode ser realizada: Número de requisições para esse cenário (" + 
                                        numeroRequisicoesNecessarias.ToString() + ") é superior ao número de requisições diárias disponíveis (" + 
                                        _configuracao.QtdRequisicoesDiarias.ToString() + ").");
            }
        }

        private List<Produtos> CarregarProdutos()
        {
            ProdutosManipulador produtosManipulador = new ProdutosManipulador(_produtoRepositorio);

            return produtosManipulador.PesquisarProdutos().ToList();
        }

        public void InativarCenario(Int64 Id)
        {
            Cenarios cenario = _cenarioRepositorio.CarregarCenario(Id);

            cenario.InativarCenario();

            _cenarioRepositorio.AlterarCenario(cenario);
        }

        public void AtualizarDataProcessamentoCenario(Int64 Id)
        {
            Cenarios cenario = _cenarioRepositorio.CarregarCenario(Id);

            cenario.AtualizarDataProcessamento();

            _cenarioRepositorio.AlterarCenario(cenario);
        }
    }
}
