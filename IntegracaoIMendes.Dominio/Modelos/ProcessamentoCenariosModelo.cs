using System;

namespace IntegracaoIMendes.Dominio.Modelos
{
    public class ProcessamentoCenariosModelo
    {
        public Int64 ID { get; set; }
        public int EmpresaID { get; set; }
        public int FilialID{ get; set; }
        public DateTime Data { get; set; }
        public Int64 CenarioID { get; set; }
        public string Finalidades { get; set; }
        public string CaracteristicasTributarias { get; set; }
        public string UFs { get; set; }
        public int QtdProdutos { get; set; }
        public int QtdOrigensProdutos { get; set; }
        public int QtdRequisicoesRealizadas { get; set; }
        public string Mensagem { get; set; }
    }
}
