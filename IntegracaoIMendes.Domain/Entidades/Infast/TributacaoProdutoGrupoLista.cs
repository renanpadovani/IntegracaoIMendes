using System;

namespace IntegracaoIMendes.Dominio.Entidades.Infast
{
    public class TributacaoProdutoGrupoLista
    {
        public Int64 ID { get; set; }
        public int EmpresaID { get; set; }
        public int FilialID { get; set; }
        public Int64 ProdutoGrupoID { get; set; }
        public Int64 ProdutoDerivadoID { get; set; }
        public string UF { get; set; }
        public string CFOP { get; set; }
        public string CodigoCaracteristicaTributaria { get; set; }
        public Int16 Finalidade { get; set; }
        public string CfopInterno { get; set; }
        public string CfopInterestadual { get; set; }
        public string Cst { get; set; }
        public string Csosn { get; set; }
        public decimal AliquotaInterna { get; set; }
        public decimal AliquotaInterestadual { get; set; }
        public decimal AliquotaReducao { get; set; }
        public decimal AliquotaReducaoST { get; set; }
        public decimal AliquotaST { get; set; }
        public decimal AliquotaIVA { get; set; }
        public decimal AliquotaFCP { get; set; }
        public string CodBeneficio { get; set; }
        public decimal AliquotaDiferimento { get; set; }
        public string Antecipado { get; set; }
        public string Desonerado { get; set; }
        public string Isento { get; set; }
        public string AmparoLegal { get; set; }
        public decimal AliquotaIsencao { get; set; }
	}
}
