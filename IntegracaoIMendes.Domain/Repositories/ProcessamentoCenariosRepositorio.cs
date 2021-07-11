using Dapper;
using IntegracaoIMendes.Domain.Entities.Infast;
using IntegracaoIMendes.Domain.Mappings;
using System;

namespace IntegracaoIMendes.Domain.Repositories
{
    public class ProcessamentoCenariosRepositorio
    {
        private readonly DataContext.InfastDataContext _context;
        private ProcessamentoCenariosMapping _mapp;

        public ProcessamentoCenariosRepositorio(DataContext.InfastDataContext context)
        {
            _context = context;
            _mapp = new ProcessamentoCenariosMapping();
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

            return Int64.Parse(_context.Connection.ExecuteScalar(insertProcesamentoCenario, _mapp.Mapp(processamentoCenario)).ToString());
        }
    }
}
