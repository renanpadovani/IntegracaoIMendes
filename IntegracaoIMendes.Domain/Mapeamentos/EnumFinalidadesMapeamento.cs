using IntegracaoIMendes.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoIMendes.Dominio.Mapeamentos
{
    public class EnumFinalidadesMapeamento
    {
        public string Mapp(List<EFinalidade> listaFinalidades)
        {
            string strFinalidades = "";

            foreach (EFinalidade finalidade in listaFinalidades)
                strFinalidades += (int)finalidade + ",";

            return strFinalidades.Substring(0, (strFinalidades.Length > 0 ? strFinalidades.ToString().Length - 1 : 0));
        }

        public List<EFinalidade> Mapp(string stringFinalidades)
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
    }
}
