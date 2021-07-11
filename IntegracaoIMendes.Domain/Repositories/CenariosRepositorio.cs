using Dapper;
using IntegracaoIMendes.Domain.Entities.Infast;
using IntegracaoIMendes.Domain.Mappings;
using IntegracaoIMendes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace IntegracaoIMendes.Domain.Repositories
{
    public class CenariosRepositorio 
    {
        private readonly DataContext.InfastDataContext _context;
        private CenariosMapping _mapp;

        public CenariosRepositorio(DataContext.InfastDataContext context)
        {
            _context = context;
            _mapp = new CenariosMapping();
        }

        public IEnumerable<Cenarios> CarregarListaCenarios()
        {
            List<Cenarios> listaCenarios = new List<Cenarios>();

            List<CenariosModelo> listaCenariosModel =  _context
                .Connection
                .Query<CenariosModelo>(
                            "Select IMC_ID ID, " +
                            "IMC_UfCliente UfCliente, " +
                            "IMC_CFOP CFOP, " +
                            "IMC_CodRegimeTributario CodRegimeTributario, " +
                            "IMC_RegimeTributario RegimeTributario, " +
                            "IMC_Finalidade Finalidades, " +
                            "IMC_CaracteristicasTributarias CaracteristicasTributarias, " +
                            "IMC_UFs UFs, " +
                            "IMC_Inativo Inativo, " +
                            "IMC_TipoProduto TipoProduto, " +
                            "IMC_IntervaloDeBuscaEmDias IntervaloDeBuscaEmDias, " +
                            "ISNULL(IMC_DataHoraUltimoProcessamento,'01/01/1900') DataHoraUltimoProcessamento " +
                            "From Tb_IMendes_Cenarios " +
                            "Where IMC_Inativo = 0 " + 
                            "Order By IMC_ID",
            commandType: CommandType.Text).ToList();

            if (listaCenariosModel.Count > 0)
            {
                foreach (CenariosModelo cenarioModel in listaCenariosModel)
                    listaCenarios.Add(_mapp.Mapp(cenarioModel));
            }

            return listaCenarios;
        }

        public Cenarios CarregarCenario(Int64 Id)
        {
            CenariosModelo cenarioModel = _context
                .Connection
                .QueryFirst<CenariosModelo>(
                            "Select IMC_ID ID, " +
                            "IMC_UfCliente UfCliente, " +
                            "IMC_CFOP CFOP, " +
                            "IMC_CodRegimeTributario CodRegimeTributario, " +
                            "IMC_RegimeTributario RegimeTributario, " +
                            "IMC_Finalidade Finalidades, " +
                            "IMC_CaracteristicasTributarias CaracteristicasTributarias, " +
                            "IMC_UFs UFs, " +
                            "IMC_Inativo Inativo, " +
                            "IMC_TipoProduto TipoProduto, " +
                            "IMC_IntervaloDeBuscaEmDias IntervaloDeBuscaEmDias, " +
                            "ISNULL(IMC_DataHoraUltimoProcessamento,'01/01/1900') DataHoraUltimoProcessamento " +
                            "From Tb_IMendes_Cenarios " +
                            "Where IMC_ID = " + Id.ToString() + " " +
                            "Order By IMC_ID",
                    commandType: CommandType.Text);

            return _mapp.Mapp(cenarioModel);
        }

        public Int64 IncluirCenario(Cenarios cenario)
        {
            string insertCenario = "Insert Into Tb_Imendes_Cenarios " +
                                    "(IMC_UfCliente, " +
                                    "IMC_CodRegimeTributario, " +
                                    "IMC_RegimeTributario, " +
                                    "IMC_CaracteristicasTributarias, " +
                                    "IMC_UFs, " +
                                    "IMC_CFOP, " +
                                    "IMC_Finalidade, " +
                                    "IMC_Inativo, " +
                                    "IMC_TipoProduto, " +
                                    "IMC_IntervaloDeBuscaEmDias) " +
                                    "Values " +
                                    "(@UfCliente, " +
                                    "@CodRegimeTributario, " +
                                    "@RegimeTributario, " +
                                    "@CaracteristicasTributarias, " +
                                    "@UFs, " +
                                    "@CFOP, " +
                                    "@Finalidades, " +
                                    "@Inativo, " +
                                    "@TipoProduto, " +
                                    "@IntervaloDeBuscaEmDias); " +
                                    "SELECT CAST(SCOPE_IDENTITY() as BIGINT);";

            return Int64.Parse(_context.Connection.ExecuteScalar(insertCenario, _mapp.Mapp(cenario)).ToString()); 
        }

        public Int64 AlterarCenario(Cenarios cenario)
        {
            string updateCenario = "Update Tb_Imendes_Cenarios Set " +
                                    "IMC_UfCliente = @UfCliente, " +
                                    "IMC_CodRegimeTributario = @CodRegimeTributario, " +
                                    "IMC_RegimeTributario = @RegimeTributario, " +
                                    "IMC_CaracteristicasTributarias = @CaracteristicasTributarias, " +
                                    "IMC_UFs = @UFs, " +
                                    "IMC_CFOP = @CFOP, " +
                                    "IMC_Finalidade = @Finalidades, " +
                                    "IMC_Inativo = @Inativo, " +
                                    "IMC_TipoProduto = @TipoProduto, " +
                                    "IMC_IntervaloDeBuscaEmDias = @IntervaloDeBuscaEmDias, " +
                                    "IMC_DataHoraUltimoProcessamento = @DataHoraUltimoProcessamento " +
                                    "Where IMC_ID = " + cenario.ID.ToString();

            return _context.Connection.Execute(updateCenario, _mapp.Mapp(cenario));
        }
    }
}
