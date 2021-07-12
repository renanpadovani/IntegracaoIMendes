using IntegracaoIMendes.Dominio.Entidades.Infast;
using IntegracaoIMendes.Dominio.Enums;
using IntegracaoIMendes.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntegracaoIMendes.Dominio.Mapeamentos
{
    public class CenariosMapeamento
    {
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
                cenario.Finalidades = RetornarListaFinalidades(cenarioModelo.Finalidades);
                cenario.CaracteristicasTributarias = RetornarListaCaracteristicas(cenarioModelo.CaracteristicasTributarias);
                cenario.UFs = RetornarListaUFs(cenarioModelo.UFs);
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
                cenarioModelo.Finalidades = RetornarStringFinalidades(cenario.Finalidades);
                cenarioModelo.CaracteristicasTributarias = RetornarStringCaracteristicasTributarias(cenario.CaracteristicasTributarias);
                cenarioModelo.UFs = RetornarStringUFs(cenario.UFs);
                cenarioModelo.Inativo = cenario.Inativo;
                cenarioModelo.TipoProduto = cenario.TipoProduto;
                cenarioModelo.IntervaloDeBuscaEmDias = cenario.IntervaloDeBuscaEmDias;
                cenarioModelo.DataHoraUltimoProcessamento = cenario.DataHoraUltimoProcessamento;
            }

            return cenarioModelo;
        }

        private string RetornarStringCaracteristicasTributarias(List<ECaracteristicaTributaria> listaCaracteristiscas)
        {
            string strCaracateristicas = "";

            foreach (ECaracteristicaTributaria caracteristica in listaCaracteristiscas)
                strCaracateristicas += (int)caracteristica + ",";

            return strCaracateristicas.Substring(0, (strCaracateristicas.Length > 0 ? strCaracateristicas.ToString().Length - 1 : 0));
        }

        private string RetornarStringUFs(List<string> listaUFs)
        {
            string strUFs = "";

            foreach (string uf in listaUFs)
                strUFs += uf.ToString() + ",";

            return strUFs.Substring(0, (strUFs.Length > 0 ? strUFs.ToString().Length - 1 : 0));
        }

        private string RetornarStringFinalidades(List<EFinalidade> listaFinalidades)
        {
            string strFinalidades = "";

            foreach (EFinalidade finalidade in listaFinalidades)
                strFinalidades += (int)finalidade + ",";

            return strFinalidades.Substring(0, (strFinalidades.Length > 0 ? strFinalidades.ToString().Length - 1 : 0));
        }

        private List<EFinalidade> RetornarListaFinalidades(string stringFinalidades)
        {
            List<EFinalidade> finalidades = new List<EFinalidade>();

            if (!String.IsNullOrEmpty(stringFinalidades))
            {
                List<string> strFinalidades = stringFinalidades.Split(',').ToList();

                if (stringFinalidades.Length > 0)
                {
                    foreach (string caract in strFinalidades)
                        finalidades.Add((EFinalidade)int.Parse(caract));
                }
            }

            return finalidades;
        }

        private List<string> RetornarListaUFs(string stringUFs)
        {
            List<string> listaUFs = new List<string>();

            if (!String.IsNullOrEmpty(stringUFs))
            {
                listaUFs = stringUFs.Split(',').ToList();
            }

            return listaUFs;
        }

        private List<ECaracteristicaTributaria> RetornarListaCaracteristicas(string stringCaracteristicas)
        {
            List<ECaracteristicaTributaria> listaCaracteristicas = new List<ECaracteristicaTributaria>();

            if (!String.IsNullOrEmpty(stringCaracteristicas))
            {
                List<string> strCaracteristicas = stringCaracteristicas.Split(',').ToList();

                foreach (string caract in strCaracteristicas)
                    listaCaracteristicas.Add((ECaracteristicaTributaria)int.Parse(caract));
            }

            return listaCaracteristicas;
        }
    }
}
