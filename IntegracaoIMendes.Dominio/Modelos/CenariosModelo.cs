using System;

namespace IntegracaoIMendes.Dominio.Modelos
{
    public class CenariosModelo
    {
        public Int64 ID { get; set; }
        public string UfCliente { get; set; }
        public string CFOP { get; set; }
        public string CodRegimeTributario { get; set; }
        public string RegimeTributario { get; set; }
        public string Finalidades { get; set; }
        public string CaracteristicasTributarias { get; set; }
        public string UFs { get; set; }
        public bool Inativo { get; set; }
        public string TipoProduto { get; set; }
        public Int16 IntervaloDeBuscaEmDias { get; set; }
        public DateTime DataHoraUltimoProcessamento { get; set; }
    }
}
