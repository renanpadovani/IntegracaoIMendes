using IntegracaoIMendes.Domain.Enums;
using System;
using System.Collections.Generic;

namespace IntegracaoIMendes.Domain.Entities.Infast
{
    public class Cenarios : Entidade
    {
        public Int64 ID { get; set; }
        public string UfCliente { get; set; }
        public string CFOP { get; set; }
        public ECodRegimeTributario CodRegimeTributario { get; set; }
        public string RegimeTributario { get; set; }
        public List<EFinalidade> Finalidades { get; set; }
        public List<ECaracteristicaTributaria> CaracteristicasTributarias { get; set; }
        public List<string> UFs { get; set; }
        public bool Inativo { get; private set; }
        public string TipoProduto { get; set; }
        public Int16 IntervaloDeBuscaEmDias { get; set; }
        public DateTime DataHoraUltimoProcessamento { get; private set; }

        public override void Validar()
        {
            string errosValidacao = "";

            if (UfCliente.Trim().Length != 2)
                errosValidacao += "UF do emitente inválida; ";

            if (CodRegimeTributario == ECodRegimeTributario.RegimeNormal && RegimeTributario.Trim().Length == 0)
                errosValidacao += "Tipo regime normal inválido; ";

            if (CFOP.Trim().Length == 0)
                errosValidacao += "CFOP de destino inválida; ";

            if (CaracteristicasTributarias.Count == 0)
                errosValidacao += "Características tributárias do destinário invalidas; ";

            if (Finalidades.Count == 0)
                errosValidacao += "Finalidade(s) destinação inválida; ";

            if (UFs.Count == 0)
                errosValidacao += "UF's de destino inválidos; ";

            if (IntervaloDeBuscaEmDias == 0)
                errosValidacao += "O intervalo de busca de produtos em dias deve ser maior que zero; ";

            if (errosValidacao.Trim().Length > 0)
                throw new Exception("A inclusão do cenário não pode ser realizada, verifique os erros e tente novamente: " + errosValidacao);
        }

        public void AtualizarDataProcessamento()
        {
            DataHoraUltimoProcessamento = System.DateTime.Now;
        }

        public void InativarCenario()
        {
            Inativo = true;
        }
    }
}
