using Dapper;
using IntegracaoIMendes.Domain.Entities.Infast;
using IntegracaoIMendes.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace IntegracaoIMendes.Domain.Repositories
{
    public class CenariosRepositorio : Repository
    {
        private readonly DataContext.InfastDataContext _context;

        public CenariosRepositorio(DataContext.InfastDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Cenarios> CarregarListaCenarios()
        {
            return _context
                .Connection
                .Query<Cenarios>(
                            "Select IMC_ID ID, " +
                            "IMC_UfCliente UfCliente, " +
                            "IMC_CFOP CFOP, " +
                            "IMC_CodRegimeTributario CodRegimeTributario, " +
                            "IMC_RegimeTributario RegimeTributario, " +
                            "IMC_Finalidade Finalidade, " +
                            "IMC_CaracteristicasTributarias CaracteristicasTributarias, " +
                            "IMC_UFs UFs, " +
                            "IMC_Inativo Inativo, " +
                            "IMC_TipoProduto TipoProduto, " +
                            "IMC_IntervaloDeBuscaEmDias IntervaloDeBuscaEmDias, " +
                            "ISNULL(IMC_DataHoraUltimoProcessamento,'01/01/1900') DataHoraUltimoProcessamento " +
                            "From Tb_IMendes_Cenarios " +
                            "Where IMC_Inativo = 0 " + 
                            "Order By IMC_ID",
            commandType: CommandType.Text);
        }

        public Cenarios CarregarCenario(Int64 Id)
        {
            return _context
                .Connection
                .QueryFirst<Cenarios>(
                            "Select IMC_ID ID, " +
                            "IMC_UfCliente UfCliente, " +
                            "IMC_CFOP CFOP, " +
                            "IMC_CodRegimeTributario CodRegimeTributario, " +
                            "IMC_RegimeTributario RegimeTributario, " +
                            "IMC_Finalidade Finalidade, " +
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
                                    "@Finalidade, " +
                                    "@Inativo, " +
                                    "@TipoProduto, " +
                                    "@IntervalorDeBuscaEmDias); " +
                                    "SELECT CAST(SCOPE_IDENTITY() as BIGINT);";

            return Int64.Parse(_context.Connection.ExecuteScalar(insertCenario,
                new
                {
                    UfCliente = cenario.UfCliente,
                    CodRegimeTributario = cenario.CodRegimeTributario,
                    RegimeTributario = cenario.RegimeTributario,
                    CaracteristicasTributarias = cenario.CaracteristicasTributarias,
                    UFs = "",
                    CFOP = cenario.CFOP,
                    Finalidade = "",
                    Inativo = cenario.Inativo,
                    TipoProduto = cenario.TipoProduto,
                    IntervalorDeBuscaEmDias = cenario.IntervaloDeBuscaEmDias
                }
            ).ToString());
        }

        private string RetornarStringCaracteristicasTributarias(List<ECaracteristicaTributaria> listaCaracteristiscas)
        {
            string strCaracateristicas = "";

            foreach (ECaracteristicaTributaria caracteristica in listaCaracteristiscas)
                strCaracateristicas += caracteristica.ToString();


            return strCaracateristicas;

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
                                    "IMC_Finalidade = @Finalidade, " +
                                    "IMC_Inativo = @Inativo, " +
                                    "IMC_TipoProduto = @TipoProduto, " +
                                    "IMC_IntervaloDeBuscaEmDias = @IntervaloDeBuscaEmDias, " +
                                    "IMC_DataHoraUltimoProcessamento = @DataHoraUltimoProcessamento " +
                                    "Where IMC_ID = " + cenario.ID.ToString();

            return _context.Connection.Execute(updateCenario, cenario);
        }

        private List<EFinalidade> RetornarListaFinalidades(string stringFinalidades)
        {
            List<EFinalidade> finalidades = new List<EFinalidade>();

            List<string> strFinalidades = stringFinalidades.Split(',').ToList();

            foreach (string caract in strFinalidades)
                finalidades.Add((EFinalidade)int.Parse(caract));

            return finalidades;
        }

        private List<string> RetornarListaUFs(string stringUFs)
        {
            return stringUFs.Split(',').ToList();
        }

        private List<ECaracteristicaTributaria> RetornarListaCaracteristicas(string stringCaracteristicas)
        {
            List<ECaracteristicaTributaria> caracteristicas = new List<ECaracteristicaTributaria>();

            List<string> strCaracteristicas = stringCaracteristicas.Split(',').ToList();

            foreach (string caract in strCaracteristicas)
                caracteristicas.Add((ECaracteristicaTributaria)int.Parse(caract));

            return caracteristicas;
        }
    }
}
