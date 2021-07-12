using IntegracaoIMendes.Dominio.Entidades.Infast;
using IntegracaoIMendes.Dominio.Enums;
using IntegracaoIMendes.Dominio.Modelos;

namespace IntegracaoIMendes.Dominio.Mapeamentos
{
    public class CenariosMapeamento
    {
        UFsMapeamento _ufMapp;
        EnumFinalidadesMapeamento _finalidadeMapp;
        EnumCaracteristicasTributariasMapeamento _caracteristicaMapp;

        public CenariosMapeamento()
        {
            _ufMapp = new UFsMapeamento();
            _finalidadeMapp = new EnumFinalidadesMapeamento();
            _caracteristicaMapp = new EnumCaracteristicasTributariasMapeamento();
        }

        public Cenarios Mapp(CenariosModelo cenarioModelo)
        {
            Cenarios cenario = null;

            if (cenarioModelo != null)
            {
                cenario = new Cenarios();

                cenario.ID = cenarioModelo.ID;
                cenario.UfCliente = cenarioModelo.UfCliente;
                cenario.CFOP = cenarioModelo.CFOP;
                cenario.CodRegimeTributario = (ECodRegimeTributario)int.Parse(cenarioModelo.CodRegimeTributario);
                cenario.RegimeTributario = cenarioModelo.RegimeTributario;
                cenario.Finalidades = _finalidadeMapp.Mapp(cenarioModelo.Finalidades);
                cenario.CaracteristicasTributarias = _caracteristicaMapp.Mapp(cenarioModelo.CaracteristicasTributarias);
                cenario.UFs = _ufMapp.Mapp(cenarioModelo.UFs);
                cenario.Inativo = cenarioModelo.Inativo;
                cenario.TipoProduto = cenarioModelo.TipoProduto;
                cenario.IntervaloDeBuscaEmDias = cenarioModelo.IntervaloDeBuscaEmDias;
                cenario.DataHoraUltimoProcessamento = cenarioModelo.DataHoraUltimoProcessamento;
            }

            return cenario;
        }

        public CenariosModelo Mapp(Cenarios cenario)
        {
            CenariosModelo cenarioModelo = null;

            if (cenario != null)
            {
                cenarioModelo = new CenariosModelo();

                cenarioModelo.ID = cenario.ID;
                cenarioModelo.UfCliente = cenario.UfCliente;
                cenarioModelo.CFOP = cenario.CFOP;
                cenarioModelo.CodRegimeTributario = ((int)cenario.CodRegimeTributario).ToString();
                cenarioModelo.RegimeTributario = cenario.RegimeTributario;
                cenarioModelo.Finalidades = _finalidadeMapp.Mapp(cenario.Finalidades);
                cenarioModelo.CaracteristicasTributarias = _caracteristicaMapp.Mapp(cenario.CaracteristicasTributarias);
                cenarioModelo.UFs = _ufMapp.Mapp(cenario.UFs);
                cenarioModelo.Inativo = cenario.Inativo;
                cenarioModelo.TipoProduto = cenario.TipoProduto;
                cenarioModelo.IntervaloDeBuscaEmDias = cenario.IntervaloDeBuscaEmDias;
                cenarioModelo.DataHoraUltimoProcessamento = cenario.DataHoraUltimoProcessamento;
            }

            return cenarioModelo;
        }
    }
}
