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

        public ProcessamentoCenariosManipulador(IProcessamentoCenariosRepositorio repositorioProcessamentoCenario)
        {
            _repositorioProcessamento = repositorioProcessamentoCenario;
        }

        public void CriarLogProcessamentoCenario(Cenarios cenario, List<Produtos> listaProdutos, int qtdRequisicoesRealizadas, string mensagem)
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
