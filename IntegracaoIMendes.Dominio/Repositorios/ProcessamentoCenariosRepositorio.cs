using Dapper;
using IntegracaoIMendes.Dominio.ContextoDados;
using IntegracaoIMendes.Dominio.Entidades.Infast;
using IntegracaoIMendes.Dominio.Mapeamentos;
using IntegracaoIMendes.Dominio.Repositorios.Interfaces;
using System;
using System.Data;
using System.Linq;

namespace IntegracaoIMendes.Dominio.Repositorios
{
    public class ProcessamentoCenariosRepositorio : IProcessamentoCenariosRepositorio
    {
        private readonly InfastContextoDados _contexto;
        private ProcessamentoCenariosMapeamento _mapp;

        public ProcessamentoCenariosRepositorio(InfastContextoDados contexto)
        {
            _contexto = contexto;
            _mapp = new ProcessamentoCenariosMapeamento();
        }

        public Int64 IncluirProcessamentoCenario(ProcessamentoCenarios processamentoCenario)
        {
            string insertProcesamentoCenario = "Insert Into Tb_IMendes_LogProcessamentoCenario " +
                                    "(ILG_Empresa_ID, " +
                                    "ILG_Filial_ID, " +
                                    "ILG_Data, " +
                                    "ILG_Cenario_ID, " +
                                    "ILG_Finalidades, " +
                                    "ILG_CaracteristicasTributarias, " +
                                    "ILG_UFs, " +
                                    "ILG_QtdProdutos, " +
                                    "ILG_QtdOrigensProdutos, " +
                                    "ILG_QtdRequisicoesRealizadas, " +
                                    "ILG_Mensagem) " +
                                    "Values " +
                                    "(@EmpresaID, " +
                                    "@FilialID, " +
                                    "@Data, " +
                                    "@CenarioID, " +
                                    "@Finalidades, " +
                                    "@CaracteristicasTributarias, " +
                                    "@UFs, " +
                                    "@QtdProdutos, " +
                                    "@QtdOrigensProdutos, " +
                                    "@QtdRequisicoesRealizadas, " +
                                    "@Mensagem);" +
                                    "SELECT CAST(SCOPE_IDENTITY() as BIGINT);";

            return Int64.Parse(_contexto.Connection.ExecuteScalar(insertProcesamentoCenario, _mapp.Mapp(processamentoCenario)).ToString());
        }

        public Int64 RetornarNumeroRequisicoesConsumidas(DateTime data)
        {
            return _contexto
                  .Connection
                  .Query<Int64>(
                  "Select ISNULL(SUM(ILG_QtdRequisicoesRealizadas),0) As requisicoes From Tb_IMendes_LogProcessamentoCenario Where CAST(ILG_Data As Date) = @Data ",
                      new { Data = data.ToShortDateString() },
                      commandType: CommandType.Text)
                  .FirstOrDefault();
        }
    }
}
