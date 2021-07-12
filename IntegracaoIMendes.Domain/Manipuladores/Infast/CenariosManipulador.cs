using IntegracaoIMendes.Dominio.Entidades.Infast;
using IntegracaoIMendes.Dominio.Enums;
using IntegracaoIMendes.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using IntegracaoIMendes.Dominio.Servicos;
using IntegracaoIMendes.Dominio.ContextoDados;
using System.Linq;

namespace IntegracaoIMendes.Dominio.Manipuladores.Infast
{
    public class CenariosManipulador
    {
        private readonly InfastContextoDados _contexto;
        private CenariosRepositorio _cenarioRepositorio;

        public CenariosManipulador(InfastContextoDados contexto)
        {
            _contexto = contexto;
            _cenarioRepositorio = new CenariosRepositorio(_contexto);
        }

        public IEnumerable<Cenarios> CarregarListaCenarios()
        { 
            return _cenarioRepositorio.CarregarListaCenarios();
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

            ValidarLimiteRequisicoes(finalidades);
                
            novoCenario.ID = _cenarioRepositorio.IncluirCenario(novoCenario);

            return novoCenario;
        }

        private void ValidarLimiteRequisicoes(List<EFinalidade> finalidades)
        {
            ConfiguracoesManipulador configuracoesManipulador = new ConfiguracoesManipulador(_contexto);
            Configuracoes configuracao = configuracoesManipulador.CarregarConfiguracao();
            
            ProdutosManipulador produtosManipulador = new ProdutosManipulador(_contexto);
            IEnumerable<Produtos> listaProdutos = produtosManipulador.PesquisarProdutos(0, "");

            CalculoRequisicoesIMendesServico calculoRequisicoes = new CalculoRequisicoesIMendesServico();

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
