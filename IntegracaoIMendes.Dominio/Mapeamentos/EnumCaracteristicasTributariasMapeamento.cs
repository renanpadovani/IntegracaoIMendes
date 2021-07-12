using IntegracaoIMendes.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntegracaoIMendes.Dominio.Mapeamentos
{
    public class EnumCaracteristicasTributariasMapeamento
    {
        public List<ECaracteristicaTributaria> Mapp(string stringCaracteristicas)
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

        public string Mapp(List<ECaracteristicaTributaria> listaCaracteristiscas)
        {
            string strCaracateristicas = "";

            foreach (ECaracteristicaTributaria caracteristica in listaCaracteristiscas)
                strCaracateristicas += (int)caracteristica + ",";

            return strCaracateristicas.Substring(0, (strCaracateristicas.Length > 0 ? strCaracateristicas.ToString().Length - 1 : 0));
        }
    }
}
