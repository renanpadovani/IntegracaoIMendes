using System;
using System.Collections.Generic;

namespace IntegracaoIMendes.Dominio.Entidades.Infast
{
    public class TributacaoProdutoGrupo
    {
        public TributacaoProdutoGrupo()
        {
            regras = new List<TributacaoProdutoGrupoLista>();
        }

        public Int64 ID { get; set; }
        public int EmpresaID { get; set; }
        public int FilialID { get; set; }
        public Int64 CabecalhoID { get; set; }
        public Int64 ProdutoDerivadoID { get; set; }
        public string Codigo { get; set; }
        public string NCM { get; set; }
        public string CEST { get; set; }
        public string Lista { get; set; }
        public string Tipo { get; set; }
        public string CodigoANP { get; set; }
        public string PassivelPMC { get; set; }
        public decimal ImpostoImportacao { get; set; }
        public string PisCofinsCSTEntrada { get; set; }
        public string PisCofinsCSTSaida { get; set; }
        public decimal PisCofinsAliquotaPis { get; set; }
        public decimal PisCofinsAliquotaCofins { get; set; }
        public string NRI { get; set; }
        public string AmparoLegal { get; set; }
        public string IpiCSTEntrada { get; set; }
        public string IpiCSTSaida { get; set; }
        public decimal IpiAliquota { get; set; }
        public string IpiCodEnquadramento { get; set; }
        public string IpiEx { get; set; }

        public List<TributacaoProdutoGrupoLista> regras { get; set; }

    }
}
